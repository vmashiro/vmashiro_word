using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using vmashiro_word.Models;

namespace vmashiro_word.Controllers
{
    public class WordsController : Controller
    {
        private ApplicationDbContext _context;

        public WordsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Words
        public IActionResult Index()
        {
            return View(_context.Word.ToList());
        }

        // GET: Words/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Word word = _context.Word.Single(m => m.Id == id);
            if (word == null)
            {
                return HttpNotFound();
            }

            return View(word);
        }

        // GET: Words/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Words/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Word word)
        {
            if (ModelState.IsValid)
            {
                _context.Word.Add(word);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(word);
        }

        // GET: Words/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Word word = _context.Word.Single(m => m.Id == id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: Words/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Word word)
        {
            if (ModelState.IsValid)
            {
                _context.Update(word);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(word);
        }

        // GET: Words/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Word word = _context.Word.Single(m => m.Id == id);
            if (word == null)
            {
                return HttpNotFound();
            }

            return View(word);
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Word word = _context.Word.Single(m => m.Id == id);
            _context.Word.Remove(word);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
