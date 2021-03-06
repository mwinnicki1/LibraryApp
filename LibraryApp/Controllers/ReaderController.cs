﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryApp.DAL;
using LibraryApp.Models;
using LibraryApp.ViewModel;
using PagedList;

namespace LibraryApp.Controllers
{
    public class ReaderController : Controller
    {
        private LibraryAppContext db = new LibraryAppContext();

        // GET: Reader
        public ActionResult Index(string sortOrder, string currentFilter, int? idcurrentFilter, string searchString, int? idsearchstring, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.SurnameSortParm = sortOrder == "Surname" ? "surname_desc" : "Surname";

            if(searchString != null || idsearchstring != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                idsearchstring = idcurrentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.IdCurrentFilter = idsearchstring;

            var readers = from s in db.Readers
                          select s;
            if(!String.IsNullOrEmpty(searchString))
            {
                readers = readers.Where(s => s.Name.Contains(searchString));
            }
            if(idsearchstring != null)
            {
                readers = readers.Where(s => s.ID == (idsearchstring));
            }
            switch(sortOrder)
            {
                case "id_desc":
                    readers = readers.OrderByDescending(s => s.ID);
                    break;
                case "Name":
                    readers = readers.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    readers = readers.OrderByDescending(s => s.Name);
                    break;
                default:
                    readers = readers.OrderBy(s => s.ID);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(readers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Reader/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // GET: Reader/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reader/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,Street,HouseNumber,ApartmentNumber,PostalCode,City,PhoneNumber,Email")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Readers.Add(reader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reader);
        }

        // GET: Reader/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // POST: Reader/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,Street,HouseNumber,ApartmentNumber,PostalCode,City,PhoneNumber,Email")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reader);
        }

        // GET: Reader/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // POST: Reader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Reader reader = db.Readers.Find(id);
                db.Readers.Remove(reader);
                db.SaveChanges();
            }

            catch(DataException)
            {
                TempData["sErrMsg"] = "You can't delete reader who currently borrows books";
                return RedirectToAction("Delete");
            }
            


            return RedirectToAction("Index");
        }

        public ActionResult BorrowList()
        {
            LibraryAppContext dbContext = new LibraryAppContext();

            DateTime today = DateTime.Today;

            var viewmodelResult = from p in dbContext.Readers
                                  join k in dbContext.Books on p.ID equals k.ReaderId
                                  where k.ReaderId != null && k.ReturnDate < today
                                  select new BorrowIndex { reader = p, book = k };

            return View(viewmodelResult);
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
