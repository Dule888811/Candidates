using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Candidates.Models;
using Candidates.Repository.IRepository;

namespace Candidates.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidatesRepository _candidatesRepository;
        // GET: Candidates

        public CandidatesController(ICandidatesRepository candidatesRepository)
        {
            this._candidatesRepository = candidatesRepository;
        }
        public ActionResult Index()
        {
            List<Candidate> candidates = this._candidatesRepository.Get().ToList();
            return View(candidates);
        }




        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,JMGB,FirstName,LastName,Email,MobilePhone,Note,employed")] Candidate candidate)
        {
            candidate.changes = DateTime.Now;
            if (ModelState.IsValid)
            {
                this._candidatesRepository.AddCandidate(candidate);
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        // GET: Candidates/Edit/5
  /*      public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        };

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*     [HttpPost]
             [ValidateAntiForgeryToken]
             public ActionResult Edit([Bind(Include = "id,JMGB,FirstName,LastName,Email,MobilePhone,Note,employed,changes")] Candidate candidate)
             {
                 if (ModelState.IsValid)
                 {
                     //  db.Entry(candidate).State = EntityState.Modified;
                     // db.SaveChanges();
                     return RedirectToAction("Index");
                 }
                 return View(candidate);
             };

             // GET: Candidates/Delete/5
             /*   public ActionResult Delete(int? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                  ///  Candidate candidate = db.Candidate.Find(id);
                    if (candidate == null)
                    {
                        return HttpNotFound();
                    }
                    return View(candidate); 
         }

         // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
             [ValidateAntiForgeryToken]
             public ActionResult DeleteConfirmed(int id)
             {
                 Candidate candidate = db.Candidate.Find(id);
                 db.Candidate.Remove(candidate);
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
         } */
    }
}
