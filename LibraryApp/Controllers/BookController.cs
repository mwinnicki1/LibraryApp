using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryApp.DAL;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private LibraryAppContext db = new LibraryAppContext();

        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Reader);
            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.ReaderId = new SelectList(db.Readers, "ID", "Name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Author,Title,Publisher,PublishingDate,Isbn,BorrowDate,ReaderId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReaderId = new SelectList(db.Readers, "ID", "Name", book.ReaderId);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReaderId = new SelectList(db.Readers, "ID", "Name", book.ReaderId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Author,Title,Publisher,PublishingDate,Isbn,BorrowDate,ReturnDate,ReaderId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReaderId = new SelectList(db.Readers, "ID", "Name", book.ReaderId);
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ReturnBook(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            Book book = db.Books.Find(id);
            if(book == null)
            {
                return HttpNotFound();
            }
            if(book.ReaderId == null)
            {
                TempData["sErrMsg"] = "Testowa wartosc";
                return RedirectToAction("Index");
            }
            if(book.ReturnDate == null)
            {
                TempData["sErrMsg"] = "Testowa wartosc2";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost, ActionName("ReturnBook")]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnConfirmed(int id)
        {
            var book = db.Books.Where(b => b.Id == id).Single();
            book.ReaderId = null;
            book.BorrowDate = null;
            book.ReturnDate = null;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult ShowError(String sErrorMessage)
        {
            return PartialView("ErrorMessageView");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
