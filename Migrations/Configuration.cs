using Candidates.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Candidates.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Candidates.Models.CandidatesDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Candidates.Models.CandidatesDBContext context)
        {
           

        }
    }
}
