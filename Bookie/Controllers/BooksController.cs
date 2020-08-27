using Bookie.Models;
using Bookie.ViewModels;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Bookie.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageBooks))
                return View();

            return View("ReadOnlyIndex");
            
            
        }
        
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new BookFormViewModel
            {
                Book = new Book(),
                Genres = genres
            };

            return View("BookForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book==null)
            {
                return HttpNotFound();
            }
            var viewModel = new BookFormViewModel()
            {
                Book= book,
                Genres = _context.Genres.ToList()
        };
            return View("BookForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBooks)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel()
                {
                    Book = book,
                    Genres = _context.Genres.ToList()
                };
                return View("BookForm", viewModel);
            }
            if (book.Id==0)
            {
                book.DateAdded = DateTime.Now;
                book.NumberAvailable = book.NumberInStock;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);
                var loaned = _context.Loans.Where(l => l.DateReturned == null && l.Book.Id == book.Id).ToList();
                bookInDb.Name = book.Name;
                bookInDb.Author = book.Author;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.NumberAvailable = (byte)(book.NumberInStock - loaned.Count());
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }
    }
}