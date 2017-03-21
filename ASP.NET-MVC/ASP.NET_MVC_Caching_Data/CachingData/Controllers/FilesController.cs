using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace CachingData.Controllers
{
    public class FilesController : Controller
    {
        public ActionResult Index()
        {
            // directory of files
            var folderPath = @"C:\Users\NikolaiD\Desktop\HW_CachingDataMVC\CachingData\App_Data";
            var files = Directory.GetFiles(folderPath, "*.txt")
                .Select(path => Path.GetFileName(path))
                .ToArray();

            if (this.HttpContext.Cache["files"] == null)
            {
                this.HttpContext.Cache.Insert(
                    "files",
                    files,
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            };
            return View(files);
        }
    }
}