using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Searcher.Models;
using System.IO;

namespace Searcher.Controllers
{
    public class PeopleController : Controller
    {
        private PersonDBContext db = new PersonDBContext();
        // GET: People
       // public ActionResult Index()
       // {
       //     return View();
       // }
        public ActionResult Index(string searchLast, string searchFirst)
        {   
 
            var people = from p in db.People select p;
            
            if (!String.IsNullOrEmpty(searchLast))
            {
               people = people.Where(s => s.lastName.Contains(searchLast));
            }
            if (!String.IsNullOrEmpty(searchFirst))
            {
               people = people.Where(s => s.firstName.Contains(searchFirst));
            }
            return View("Index",people);

        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View("Details",person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Person person,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string filename = "";
                byte[] bytes;
                int bytesToRead;
                int numBytesRead;
                
                if (file != null)
                {
                    filename = Path.GetFileName(file.FileName);
                    bytes = new byte[file.ContentLength];
                    bytesToRead = (int) file.ContentLength;
                    numBytesRead = 0;
                    
                    while (bytesToRead > 0)
                    {
                        int n = file.InputStream.Read(bytes,numBytesRead,bytesToRead);
                        
                        if (n == 0)
                        {
                           break;
                        }
                        numBytesRead += n;
                        bytesToRead -= n;
                    }
                    person.Image = bytes;
                }

                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create",person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {   
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult MyImage(int id)
        {
           Person person = db.People.Find(id);
           return PartialView(person);
        }
    }
}
