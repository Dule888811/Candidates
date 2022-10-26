using Candidates.Models;
using Candidates.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = this._candidatesRepository.GetById((int)id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Edit([Bind(Include = "id,JMGB,FirstName,LastName,Email,MobilePhone,Note,employed")] Candidate candidate)
        {
            candidate.changes = DateTime.Now;
            if (ModelState.IsValid)
            {
                this._candidatesRepository.EditCandidate(candidate);
                return RedirectToAction("Index");
            }
            return View(candidate);

        }
        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate Candidate = this._candidatesRepository.GetById((int)id);
            if (Candidate == null)
            {
                return HttpNotFound();
            }
            return View(Candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            this._candidatesRepository.DeleteCandidate(id);

            return RedirectToAction("Index");
        }

        public ActionResult SearchCandidates(string searchBy, string search)
        {
            List<Candidate> candidates = this._candidatesRepository.SearchCandidates(searchBy, search);
            if (candidates.Count() == 0) 
            {
                return Content("No rsult");
            }
            
            else
            {
                return View(candidates);
            }
         }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                this._candidatesRepository.Dispose(disposing);
                }
                base.Dispose(disposing);
            }
        } 
        }
   