using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace amusinghoS.App.Controllers
{
    public class FileUploadController : Controller
    {
        private IWebHostEnvironment en;
        public FileUploadController(IWebHostEnvironment en) { this.en = en; }
        public IActionResult Index() { return View(); }
        [HttpPost]
        public async Task<IActionResult> UploadF()
        {
            var files = Request.Form.Files;
            string filename = files[0].FileName;
            string fileExtention = System.IO.Path.GetExtension(files[0].FileName);
            string path = Guid.NewGuid().ToString() + fileExtention; string basepath = en.WebRootPath;
            string path_server = basepath + "\\upfile\\" + path;
            using (FileStream fstream = new FileStream(path_server, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //  using (FileStream fstream = System.IO.File.Create(newFile)) //两种都可以使用
            {
                await files[0].CopyToAsync(fstream);
            }
            return Ok(new { code = 200, msg = "上传成功！" });
        }
    }
}