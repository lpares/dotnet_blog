using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comments.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Content,CreatedDate,UpdatedDate,DeletedDate,IdUser,IdArticle,IdComment")] Comment comment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(comment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(comment);
        //}
        public async Task<IActionResult> Create([Bind("Content,IdArticle,IdComment")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                // Récupérer le GUID de l'utilisateur connecté
                var userIdentityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                Console.WriteLine($"userIdentityId: {userIdentityId}");

                // Trouver l'utilisateur dans la base de données pour obtenir son Id entier
                var user = await _context.Users.FirstOrDefaultAsync(u => u.IdentityId == userIdentityId);

                if (user == null)
                {
                    return BadRequest("Utilisateur non trouvé.");
                }

                comment.IdUser = user.Id;
                comment.CreatedDate = DateTime.Now;
                comment.UpdatedDate = DateTime.Now;

                _context.Add(comment);
                await _context.SaveChangesAsync();

                // Rediriger vers la page de l'article
                //return RedirectToAction("Article", "Pages", new { id = comment.IdArticle });
            }

            // Si le modèle n'est pas valide, retourner à la vue de l'article avec les erreurs
            TempData["Error"] = "Le contenu du commentaire ne peut pas être vide.";
            return RedirectToAction("Article", "Pages", new { id = comment.IdArticle });
        }

        // GET: Comments/Edit/5
        [Authorize("AdminOnly")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("AdminOnly")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,CreatedDate,UpdatedDate,DeletedDate,IdUser,IdArticle,IdComment")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
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
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize("AdminOnly")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("AdminOnly")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
