namespace CandidatesDBContext.Repository
{
    public class BaseRepository
    {
        protected readonly Candidates.Models.CandidatesDBContext context;

        public BaseRepository(Candidates.Models.CandidatesDBContext context)
        {
            this.context = context;
        }
          public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}