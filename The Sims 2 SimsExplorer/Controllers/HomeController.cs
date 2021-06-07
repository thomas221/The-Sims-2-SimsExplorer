using FileHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using The_Sims_2_SimsExplorer.Models;
using The_Sims_2_SimsExplorer.Utilities;

namespace The_Sims_2_SimsExplorer.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

                var engine = new FileHelperEngine<Sim>(Encoding.UTF8);
                var records = engine.ReadFile(filePath);

                
                foreach (var record in records)
                {
                    Debug.WriteLine("-----------------------------");
                    Debug.WriteLine(DisplayObjectInfo.ShowDisplayObjectInfo(record));
                }

                ViewBag.SimList = "testit";



            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.


            return View();
            //return Ok(new { count = 1, size = file.Length });
        }

        
    }
}
