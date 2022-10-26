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
    }
}