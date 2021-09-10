using System.IO;
using System.Reflection;
using Custom.AspNet.Filesystem.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class FileController : Controller
    {
        [HttpPost]
        [Route("/file")]
        public IActionResult Index([FromForm]IFormFile image)
        {
            var path = new PublicFile(image).Save();
            
            // Inside specified folder
            // var path = new PublicFile(image, "fuck").Save();

            return View((object)path);
        }
        
        [HttpGet]
        [Route("/file")]
        public IActionResult Index()
        {
            return View();
        }
    }
}