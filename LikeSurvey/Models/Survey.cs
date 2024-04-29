namespace LikeSurvey.Models
{
    public class Survey
    {
        public int Id { get; set; }

        public string FullNames { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }//

        public string ContactNumber { get; set; }

        public string FavFood { get; set; }//

        public int LikeMovies { get; set; }
        public int LikeRadio { get; set; }
        public int LikeEatOut { get; set; }
        public int LikeWatchOut { get; set; }
    }
}
