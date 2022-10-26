using Candidates.Models;
using Candidates.Repository.IRepository;
using CandidatesDBContext.Repository;
using Intercom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Candidates.Repository
{
    public class CandidatesRepository : BaseRepository, ICandidatesRepository
    {
      
        public  CandidatesRepository(Candidates.Models.CandidatesDBContext context) : base(context)
            {
                
            }
        public IQueryable<Candidate> Get()
        {

            var candidates = from m in context.Candidate
                             select m;
            if (candidates.Count() == 0)
            {
                return null;
            }
            return candidates;
        }
        public void AddCandidate(Candidate candidate)
        {
          
            context.Candidate.Add(candidate);
            base.SaveChanges();
        }
        public void EditCandidate(Candidate candidate)
        {
            context.Entry(candidate).State = EntityState.Modified;
            base.SaveChanges();
        }
        public Candidate GetById(int id)
        {
            return context.Candidate.Find(id);
        }

        public void DeleteCandidate(int id)
        {
            Candidate cocument = this.GetById(id);
            context.Candidate.Remove(cocument);
            base.SaveChanges();
        }

        public List<Candidate> SearchCandidates(string searchBy, string search)
        {
            if (searchBy == "FirstName")
            {
                return context.Candidate.Where(x => x.FirstName == search).ToList();
            }else if (searchBy == "LastName")
            {
                return context.Candidate.Where(x => x.LastName == search).ToList();
            }else if(searchBy == "JMGB") 
             {
                return context.Candidate.Where(x => x.JMGB.ToString() == search).ToList();
            }else
            {
                return new List<Candidate>();
            }
            
        } 

        public void Dispose(bool disposing)
        {
            context.Dispose();
        }
    }
}