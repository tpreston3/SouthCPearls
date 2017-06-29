using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SouthSea.Models;
using SouthSea.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SouthSea.Controllers
{
    public class MerchandisesController : Controller
    {
        private readonly SouthSeaContext _context;
        IHostingEnvironment environment;

        public MerchandisesController(SouthSeaContext context, IHostingEnvironment env)
        {
            _context = context;
            environment = env; 
        }

        // GET: Merchandises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merchandise.ToListAsync());
        }

        // GET: Merchandises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchandise = await _context.Merchandise
                .SingleOrDefaultAsync(m => m.ID == id);
            if (merchandise == null)
            {
                return NotFound();
            }

            return View(merchandise);
        }

        // GET: Merchandises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merchandises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ItemName,Description,Type,GemStones,Image,Date,Length,Weight,Price")]
                                                Merchandise merchandise, ICollection<IFormFile> ImageFiles)
        {

            foreach (var file in ImageFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                fileName = "\\images\\Merchandise\\" + fileName;
                var path = Path.Combine(environment.WebRootPath, fileName);
                //merchandise.Image = (Uri.TryCreate(path, UriKind.RelativeOrAbsolute,new Uri is fileName);
            }


            if (ModelState.IsValid)
               
                {
                if (ImageFiles != null)

                {
                    await Services.Upload.UploadFile(ImageFiles, environment);
                    
                    merchandise.Image = Services.Upload.UploadFile(ImageFiles);
                }

                _context.Add(merchandise);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }

        // GET: Merchandises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

          var merchandise = await _context.Merchandise.SingleOrDefaultAsync(m => m.ID == id);
            if (merchandise == null)
            {
                return NotFound();
            }
            return View(merchandise);
        }

        // POST: Merchandises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ICollection<IFormFile> files, [Bind("ID,ItemName,Description,Type,GemStones,Image,Date,Length,Weight,Price")] Merchandise merchandise)
        {
            var uploadLoaction = Path.Combine(environment.ContentRootPath, "wwwroot\\images\\Merchandise\\");

            if (id != merchandise.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchandise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchandiseExists(merchandise.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }

        // GET: Merchandises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var merchandise = await _context.Merchandise
                .SingleOrDefaultAsync(m => m.ID == id);
            if (merchandise == null)
            {
                return NotFound();
            }

            return View(merchandise);
        }

        // POST: Merchandises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merchandise = await _context.Merchandise.SingleOrDefaultAsync(m => m.ID == id);
            _context.Merchandise.Remove(merchandise);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<String> Upload(ICollection<IFormFile> files, Merchandise merchandise)
        {
            var uploadLoaction = Path.Combine(environment.ContentRootPath, "wwwroot\\images\\Merchandise\\");
            var _modelForFile = new FileModel();

            foreach (var file in files)
            {
                var _fileName = new FileInfo(file.FileName).Name;
                _modelForFile.fileName = _fileName;
                string ext = Path.GetExtension(uploadLoaction + _fileName);

                if (!ext.Equals("jpg") || !ext.Equals("png"))
                {
                    _modelForFile.ErrorMessage = "File must be a .jpg or .png";
                    return _modelForFile.ErrorMessage;
                }
                else if (file.Length > 0)
                {
                    var existingFile = new FileInfo($"{uploadLoaction}{_fileName}");
                    if (existingFile.Exists)
                    {
                        _modelForFile.ErrorMessage = "File already exists";
                        return _modelForFile.ErrorMessage;
                    }
                    else
                    {
                        using (var fileStream = new FileStream($"{uploadLoaction}{_fileName}", FileMode.Create))
                        {
                            merchandise.Image = $"{uploadLoaction}{_fileName}";
                            await file.CopyToAsync(fileStream);
                            return $"{_fileName}";
                        }
                                               
                    }
                                        
                }
                return "File Length was 0, Enter another file";
            }
             return "No Files Recieved";
        }

            private bool MerchandiseExists(int id)
        {
            return _context.Merchandise.Any(e => e.ID == id);
        }
    }
}
