using BincomSecondAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace BincomSecondAssignment.Controllers
{
    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;

        public GalleryController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("uploadphotos")]
        public async Task<IActionResult> Upload(IFormFile file, string contentTitle)
        {
            if (file != null && file.Length > 0)  
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    var gallery = new Gallery
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        Name = contentTitle,
                        Content = memoryStream.ToArray()
                    };

                    _context.Galleries.Add(gallery);
                    await _context.SaveChangesAsync();
                } 
                return RedirectToAction(nameof(GetAllGalleries));
            }
            return View();
        }

        [HttpGet("viewphotos")]
        public async Task<IActionResult> GetAllGalleries()
        {
            var photos = await _context.Galleries.AsNoTracking().ToListAsync();
            if(photos == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(photos);
        }

        [HttpGet("viewphoto-byid/{id}")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photo = await _context.Galleries.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            Response.Headers.Append("Content-Disposition", $"inline; filename=\"{photo.FileName}\"");

            return File(photo.Content, photo.ContentType);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var photo = await _context.Galleries.FindAsync(id);
            if (photo == null)
            {
                return NotFound();  
            }

            _context.Galleries.Remove(photo);  
            await _context.SaveChangesAsync(); 

            return RedirectToAction("GetAllGalleries");  
        }
    }
}