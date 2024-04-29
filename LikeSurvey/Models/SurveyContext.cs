using Microsoft.EntityFrameworkCore;

namespace LikeSurvey.Models
{
    public class SurveyContext: DbContext
    {
        public DbSet<Survey> Surveys { get; set; }

        public SurveyContext(DbContextOptions options) : base(options) 
        {

        }
    }
}
