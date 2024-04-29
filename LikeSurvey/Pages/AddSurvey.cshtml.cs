using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace LikeSurvey.Pages
{
    public class AddSurveyModel : PageModel
    {
        public Surveyss surv = new Surveyss();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            surv.FullNames = Request.Form["fullnames"];
            surv.Email = Request.Form["email"];
            surv.DateOfBirth = Request.Form["dob"];
            surv.ContactNumber = Request.Form["contactnumber"];
            surv.FavFood = Request.Form["zfavfood"];

            // Parse LikeRadio
            if (!int.TryParse(Request.Form["zradio"], out int likeRadio))
            {
                errorMessage = "Error parsing Like Radio value.";
                return; // Stop further processing
            }
            surv.LikeRadio = likeRadio;

            // Parse LikeEatOut
            if (!int.TryParse(Request.Form["zeat"], out int likeEatOut))
            {
                errorMessage = "Error parsing Like EatOut value.";
                return; // Stop further processing
            }
            surv.LikeEatOut = likeEatOut;

            // Parse LikeWatchOut
            if (!int.TryParse(Request.Form["ztv"], out int likeWatchOut))
            {
                errorMessage = "Error parsing Like WatchOut value.";
                return; // Stop further processing
            }
            surv.LikeWatchOut = likeWatchOut;

            // Parse LikeMovies
            if (!int.TryParse(Request.Form["zmovies"], out int likeMovies))
            {
                errorMessage = "Error parsing Like Movies value.";
                return; // Stop further processing
            }
            surv.LikeMovies = likeMovies;

            // Parse Id
            if (!int.TryParse(Request.Form["id"], out int id))
            {
                errorMessage = "Error parsing Id value.";
                return; // Stop further processing
            }
            surv.Id = id;



            // Save the new survey into the database
            try
            {
                string connectionString = "Data Source=LAPTOP-TBQH7AD8\\MSSQLSERVER01;Initial Catalog=SurveyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                builder.TrustServerCertificate = true;
                connectionString = builder.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Surveys (FullNames, Email, DateOfBirth, ContactNumber, FavFood, LikeMovies, LikeRadio, LikeEatOut, LikeWatchOut) " +
                                 "VALUES (@FullNames, @Email, @DateOfBirth, @ContactNumber, @FavFood, @LikeMovies, @LikeRadio, @LikeEatOut, @LikeWatchOut);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FullNames", surv.FullNames);
                        command.Parameters.AddWithValue("@Email", surv.Email);
                        command.Parameters.AddWithValue("@DateOfBirth", surv.DateOfBirth);
                        command.Parameters.AddWithValue("@ContactNumber", surv.ContactNumber);
                        command.Parameters.AddWithValue("@FavFood", surv.FavFood);
                        command.Parameters.AddWithValue("@LikeMovies", surv.LikeMovies);
                        command.Parameters.AddWithValue("@LikeRadio", surv.LikeRadio);
                        command.Parameters.AddWithValue("@LikeEatOut", surv.LikeEatOut);
                        command.Parameters.AddWithValue("@LikeWatchOut", surv.LikeWatchOut);

                        command.ExecuteNonQuery();
                    }
                }

                successMessage = "New Survey Added Successfully";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            // Redirect to another page after saving data
            Response.Redirect("/Index");
        }

    }

    public class Surveyss
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
