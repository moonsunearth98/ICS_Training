// Controllers/MovieController.cs
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Question_2.Models; // Replace YourNamespace with your actual namespace

public class MovieController : Controller
{
    private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public ActionResult Index()
    {
        List<Movie> movies = GetMovies();
        return View(movies);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Movie movie)
    {
        InsertMovie(movie);
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        Movie movie = GetMovieById(id);
        return View(movie);
    }

    [HttpPost]
    public ActionResult Edit(Movie movie)
    {
        UpdateMovie(movie);
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Movie movie = GetMovieById(id);
        return View(movie);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        DeleteMovie(id);
        return RedirectToAction("Index");
    }

    public ActionResult MoviesByYear(int year)
    {
        List<Movie> movies = GetMoviesByYear(year);
        return View(movies);
    }

    private List<Movie> GetMovies()
    {
        List<Movie> movies = new List<Movie>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Movie";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Movie movie = new Movie
                        {
                            Mid = Convert.ToInt32(reader["Mid"]),
                            Moviename = reader["Moviename"].ToString(),
                            DateofRelease = Convert.ToDateTime(reader["DateofRelease"])
                        };
                        movies.Add(movie);
                    }
                }
            }
        }

        return movies;
    }

    private Movie GetMovieById(int id)
    {
        Movie movie = new Movie();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Movie WHERE Mid = @Mid";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Mid", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movie.Mid = Convert.ToInt32(reader["Mid"]);
                        movie.Moviename = reader["Moviename"].ToString();
                        movie.DateofRelease = Convert.ToDateTime(reader["DateofRelease"]);
                    }
                }
            }
        }

        return movie;
    }

    private void InsertMovie(Movie movie)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Movie (Moviename, DateofRelease) VALUES (@Moviename, @DateofRelease)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Moviename", movie.Moviename);
                command.Parameters.AddWithValue("@DateofRelease", movie.DateofRelease);
                command.ExecuteNonQuery();
            }
        }
    }

    private void UpdateMovie(Movie movie)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE Movie SET Moviename = @Moviename, DateofRelease = @DateofRelease WHERE Mid = @Mid";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Moviename", movie.Moviename);
                command.Parameters.AddWithValue("@DateofRelease", movie.DateofRelease);
                command.Parameters.AddWithValue("@Mid", movie.Mid);
                command.ExecuteNonQuery();
            }
        }
    }

    private void DeleteMovie(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Movie WHERE Mid = @Mid";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Mid", id);
                command.ExecuteNonQuery();
            }
        }
    }

    private List<Movie> GetMoviesByYear(int year)
    {
        List<Movie> movies = new List<Movie>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Movie WHERE YEAR(DateofRelease) = @Year";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Year", year);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Movie movie = new Movie
                        {
                            Mid = Convert.ToInt32(reader["Mid"]),
                            Moviename = reader["Moviename"].ToString(),
                            DateofRelease = Convert.ToDateTime(reader["DateofRelease"])
                        };
                        movies.Add(movie);
                    }
                }
            }
        }

        return movies;
    }
}
