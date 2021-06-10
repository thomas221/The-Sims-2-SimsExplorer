using FileHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using The_Sims_2_SimsExplorer.Data;
using The_Sims_2_SimsExplorer.Models;
using The_Sims_2_SimsExplorer.Utilities;

namespace The_Sims_2_SimsExplorer.Controllers
{


    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult SimList()
        {

            ViewBag.SimList = _context.Sims.ToList();

            return View();
        }

        [Route("sim/{id:int}")]
        public IActionResult GetById(int id)
        {
            Sim sim = _context.Sims.Find(""+id);
            
            if (sim == null)
            {
                return NotFound();
            }

            ViewBag.Sim = sim;

            return View("Sim");
        }
        
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                var unzippedFolder = Path.ChangeExtension(filePath, null);
                ZipFile.ExtractToDirectory(filePath, unzippedFolder);


                var engine = new FileHelperEngine<Sim>(Encoding.UTF8);
                var records = engine.ReadFile(unzippedFolder+"/ExportedSims.txt");

                foreach (var record in records)
                {
                    string imageFileLocation = unzippedFolder + "\\SimImage\\" + record.Hood + "_" + record.SimId + ".png";

                    if (System.IO.File.Exists(imageFileLocation))
                    {
                        record.Image = Convert.ToBase64String(System.IO.File.ReadAllBytes(imageFileLocation));
                    }
                    Debug.WriteLine(DisplayObjectInfo.ShowDisplayObjectInfo(record));

                }

                

                _context.Sims.AddRange(records);
                _context.SaveChanges();

                //All sims are known now, so now we can find spouses etc
                /*
                foreach(var record in _context.Sims.ToList())
                {
                    Sim spouse = _context.Sims.Find(record.Spouse);
                    if (spouse != null)
                        record.SpouseSim = spouse;

                    Sim parentA = _context.Sims.Find(record.ParentA);
                    if (parentA != null)
                        record.ParentASim = parentA;

                    Sim parentB = _context.Sims.Find(record.ParentB);
                    if (parentB != null)
                        record.ParentBSim = parentB;
                }
                _context.SaveChanges();*/
                ViewBag.SimList = records;



            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.


            return View("SimList");
            //return Ok(new { count = 1, size = file.Length });
        }

        
    }
}
