using Candidates.Repository.IRepository;
using CandidatesDBContext.Repository;
using Intercom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidates.Repository
{
    public class CandidatesRepository : BaseRepository, ICandidatesRepository
    {
        public  CandidatesRepository(Candidates.Models.CandidatesDBContext context) : base(context)
            {
                
            }
    }
}