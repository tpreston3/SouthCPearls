using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SouthSea.Services
{
    public class Upload
    {
        internal static async Task<string> UploadFile(ICollection<IFormFile> files, IHostingEnvironment environment)
        {

            var uploads = Path.Combine(environment.WebRootPath, "Merchandise");
            string fileNameString = String.Empty;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, System.IO.Path.GetFileName(file.FileName)), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        fileNameString = System.IO.Path.GetFileName(file.FileName);
                    }

                }
            }

            return fileNameString;
        }
        internal static string UploadFile(ICollection<IFormFile> files)
        {
            string fileNameString = String.Empty;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    fileNameString = System.IO.Path.GetFileName(file.FileName);
                }

            }
            return fileNameString;
        }
    }
}
