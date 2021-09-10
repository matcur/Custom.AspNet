using System.Collections.Generic;
using Custom.AspNet.Filesystem.FileCollections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class FilesController : Controller
    {
        [HttpGet]
        [Route("/files")]
        public IActionResult Index()
        {
            return View(new List<string>());
        }
        
        [HttpPost]
        [Route("/files")]
        public IActionResult Index([FromForm]IFormFileCollection images)
        {
            var paths = new PublicFiles(images, "fuck").Save();

            return View(paths);
        }
    }
}