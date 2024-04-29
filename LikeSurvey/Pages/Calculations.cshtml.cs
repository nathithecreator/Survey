using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace LikeSurvey.Pages
{
    public class CalculationsModel : PageModel
    {
        public List<Surveyy> listSurvey = new List<Surveyy>();
        public int NetAmount { get; set; }

        public int TotalSurveys { get; set; }
        public int AverageAge { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public decimal PercentagePizza { get; set; }
        public decimal PercentagePasta { get; set; }
        public decimal PercentagePap { get; set; }
        public int AvgWatchMovie { get; set; }
        public int AvgListenRadio { get; set; }
        public int AvgEatOut { get; set; }
        public int AvgWatchTV { get; set; }

        public void OnGet()
        {
            LoadSurveyData();
        }

        public void LoadSurveyData()
        {
            
            // Calculate the NetAmount
            TotalSurveys = CalculateTotalSurveys();

            AverageAge = CalculateAverageAge();
            MaxAge = CalculateMaxAge();
            MinAge = CalculateMinAge();
            PercentagePizza = CalculatePercentagePizza();
            PercentagePasta = CalculatePercentagePasta();
            PercentagePap = CalculatePercentagePap();
            AvgWatchMovie = CalculateAvgWatchMovie();
            AvgListenRadio = CalculateAvgListenRadio();
            AvgEatOut = CalculateAvgEatOut();
            AvgWatchTV = CalculateAvgWatchTV();
        }
        public int CalculateTotalSurveys()
        {
            int totalSurveys = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) AS TotalEntries FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                totalSurveys = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            return totalSurveys;
        }

        public int CalculateAverageAge()
        {
            int averageAge = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT AVG(DATEDIFF(YEAR, DateOfBirth, GETDATE())) AS AverageAge FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                averageAge = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            return averageAge;
        }

        public int CalculateMaxAge()
        {
            int maxAge = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT MAX(YEAR(GETDATE()) - YEAR(DateOfBirth)) AS OldestAge FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                maxAge = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            return maxAge;
        }

        public int CalculateMinAge()
        {
            int minAge = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT MIN(DATEDIFF(YEAR, DateOfBirth, GETDATE())) AS MinimumAge FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                minAge = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            return minAge;
        }

        public decimal CalculatePercentagePizza()
        {
            decimal percentagePizza = 0;

            // Perform your SQL query to calculate the percentage here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT ROUND((COUNT(CASE WHEN FavFood = 'Pizza' THEN 1 END) * 100.0 / COUNT(*)), 2) AS PercentagePizza FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                percentagePizza = reader.GetDecimal(0);
                            }
                        }
                    }
                }
            }

            return percentagePizza;
        }


        public decimal CalculatePercentagePasta()
        {
            decimal percentagePasta = 0;

            // Perform your SQL query to calculate the percentage here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT ROUND((COUNT(CASE WHEN FavFood = 'Pasta' THEN 1 END) * 100.0 / COUNT(*)), 2) AS PercentagePizza FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                percentagePasta = reader.GetDecimal(0);
                            }
                        }
                    }
                }
            }

            return percentagePasta;
        }


        public decimal CalculatePercentagePap()
        {
            decimal percentagePap = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT ROUND((COUNT(CASE WHEN FavFood = 'PapandWors' THEN 1 END) * 100.0 / COUNT(*)), 2) AS PercentagePizza FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                percentagePap = reader.GetDecimal(0);
                            }
                        }
                    }
                }
            }

            return percentagePap;
        }

        public int CalculateAvgWatchMovie()
        {
            int avgWatchMovie = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT ROUND(AVG(LikeMovies), 0) AS AverageLikeMovies FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                avgWatchMovie = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            return avgWatchMovie;
        }

        public int CalculateAvgListenRadio()
        {
            int avgListenRadio = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT ROUND(AVG(LikeRadio), 0) AS AverageLikeRadio FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                avgListenRadio = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            return avgListenRadio;
        }

        public int CalculateAvgEatOut()
        {
            int avgEatOut = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT ROUND(AVG(LikeEatOut), 0) AS AverageLikeEatOut FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                avgEatOut = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            return avgEatOut;
        }

        public int CalculateAvgWatchTV()
        {
            int avgWatchTV = 0;

            // Perform your SQL query to calculate the NetAmount here
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"))
            {
                connection.Open();
                string sql = "SELECT ROUND(AVG(LikeWatchOut), 0) AS AverageLikeWatchOut FROM Surveys;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                avgWatchTV = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            return avgWatchTV;
        }


    }

    public class Surveyy
    {
        public int Id { get; set; }
        public string FullNames { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string FavFood { get; set; }
        public int LikeMovies { get; set; }
        public int LikeRadio { get; set; }
        public int LikeEatOut { get; set; }
        public int LikeWatchOut { get; set; }
    }
}

