using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Candidates.Models
{
    public class CandidatesDBContext : DbContext
    {
        internal object candidate;

        public DbSet<Candidate> Candidate { get; set; }
        
    }
}