using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MyProject.BL.Entities;
using MyProject.DAL;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;   //26


//24
namespace MyProject.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly MyProjectDbContext _context;
        
        //26
        private readonly IFileProvider fileProvider; 
        private readonly IHostingEnvironment hostingEnvironment;

        public PostsController(MyProjectDbContext context,
            IFileProvider fileprovider, IHostingEnvironment env     //26
            )
        {
            _context = context;

            //26
            fileProvider = fileprovider;
            hostingEnvironment = env;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var myProjectDbContext = _context.Post.Include(p => p.Blog);
            return View(await myProjectDbContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            //var blogs = await _context.Blogs.Where(t => t.Class == null).ToListAsync();
            
            ViewData["BlogId"] = new SelectList(_context.Blog, "BlogId", "Title");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Content,Author,PublishedDateTime,BlogId")] Post post, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();

                //26
                // Code to upload image if not null
                if (file != null || file.Length != 0)
                {
                    // Create a File Info
                    FileInfo fi = new FileInfo(file.FileName);
                    // This code creates a unique file name to prevent duplications stored at the file location
                    var newFilename = post.PostId + "_" + String.Format("{0:d}", (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\Pictures\" + newFilename);

                    // IMPORTANT: The pathToSave variable will be save on the column in the database
                    var pathToSave = @"/Pictures/" + newFilename;

                    // This stream the physical file to the allocate wwwroot/ImageFiles folder
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // This save the path to the record
                    post.PicturePath = pathToSave;
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                //

                    return RedirectToAction(nameof(Index));
            }
            //ViewData["BlogId"] = new SelectList(_context.Blog, "BlogId", "Title", post.BlogId);
            

            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(_context.Blog, "BlogId", "Author", post.BlogId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Content,Author,PublishedDateTime,BlogId")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogId"] = new SelectList(_context.Blog, "BlogId", "Author", post.BlogId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'MyProjectDbContext.Post'  is null.");
            }
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return _context.Post.Any(e => e.PostId == id);
        }
    }
}
