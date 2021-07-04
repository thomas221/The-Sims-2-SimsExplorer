using FileHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        //private readonly ApplicationDbContext _context; Don't need EF framework for now
        private IHostingEnvironment _hostingEnv;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            //_context = context;
            _hostingEnv = hostingEnvironment;
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

            ViewBag.SimList = ((JArray)JsonConvert.DeserializeObject(HttpContext.Session.GetString("SimList"))).ToObject<List<Sim>>();
            return View();
        }

        [Route("sim/{id:int}")]
        public IActionResult GetById(int id)
        {
            List<Sim> simList = ((JArray)JsonConvert.DeserializeObject(HttpContext.Session.GetString("SimList"))).ToObject<List<Sim>>();
            
            Sim sim = SimHelpers.FindSim(""+id,simList);
            
            if (sim == null)
            {
                return NotFound();
            }
            SimHelpers.InitializeRelatedSims(simList);
            ViewBag.ParentA = sim.ParentA;
            ViewBag.ParentB = sim.ParentB;
            ViewBag.Spouse = sim.Spouse;
            ViewBag.Sim = sim;


            ViewBag.Tree = sim.ConvertUltimateAncestorToHTML();

            return View("Sim");
        }

        [Route("sim/{id:int}/familytree")]
        public IActionResult ShowFamilyTree(int id)
        {
            List<Sim> simList = ((JArray)JsonConvert.DeserializeObject(HttpContext.Session.GetString("SimList"))).ToObject<List<Sim>>();

            Sim sim = SimHelpers.FindSim("" + id, simList);

            if (sim == null)
            {
                return NotFound();
            }
            SimHelpers.InitializeRelatedSims(simList);
            ViewBag.Sim = sim;
            ViewBag.Tree = sim.ConvertToHTML();

            return View("FamilyTree");
        }

        [HttpGet]
        public IActionResult ExamplePlayFile() {

            string unzippedFolder = Path.ChangeExtension(Path.GetTempFileName(),null);
            ZipFile.ExtractToDirectory(_hostingEnv.WebRootPath+"/Genderswapped.zip", unzippedFolder);


            var engine = new FileHelperEngine<Sim>(Encoding.UTF8);
            var records = engine.ReadFile(unzippedFolder + "/ExportedSims.txt");


            foreach (var record in records)
            {
                string imageFileLocation = unzippedFolder + "\\SimImage\\" + record.Hood + "_" + record.SimId + ".png";

                if (System.IO.File.Exists(imageFileLocation))
                {
                    record.Image = Convert.ToBase64String(System.IO.File.ReadAllBytes(imageFileLocation));
                }
            }
            var simList = records.ToList();

            HttpContext.Session.SetString("SimList", JsonConvert.SerializeObject(simList));

            //_context.Sims.AddRange(records); Don't need EF framework for now
            //_context.SaveChanges();
            ViewBag.SimList = records;


            return View("SimList");

        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            if (file != null && file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                //security checks
                Debug.WriteLine("extension: " + file.ContentType);

                //Stop if not zip or file name contains unsafe characters or size is bigger than 25 MB = 26214400

                bool invalid = false;

                if (file.FileName.Contains(".."))
                {
                    ViewBag.ErrorMessage = "The file name contains '..'. This is not allowed.";
                    invalid = true;
                }

                if (file.FileName.Contains("\\"))
                {
                    ViewBag.ErrorMessage = "The file name contains '\\'. This is not allowed.";
                    invalid = true;
                }

                if (file.FileName.Contains("/"))
                {
                    ViewBag.ErrorMessage = "The file name contains '/'. This is not allowed.";
                    invalid = true;
                }

                if (file.FileName.Length > 26214400)
                {
                    ViewBag.ErrorMessage = "The file size is bigger than 25 MB. Try again with a file that is smaller than 25 MB.";
                    invalid = true;
                }

                if (invalid)              
                {
                    return View("Error");
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
                }
                var simList = records.ToList();
                
                HttpContext.Session.SetString("SimList",JsonConvert.SerializeObject(simList));

                //_context.Sims.AddRange(records); Don't need EF framework for now
                //_context.SaveChanges();
                ViewBag.SimList = records;
            }
            else
            {
                ViewBag.ErrorMessage = "File is empty. Did you select a file?";
                return View("Error");
            }


            return View("SimList");
        }

        
    }
}
