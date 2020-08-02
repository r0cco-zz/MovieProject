using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MoviesAPI;
using MoviesAPI.Config;
using MoviesAPI.Models;
using Newtonsoft.Json;

namespace MoviesAPI.MoviesDB_Data
{
    public class MoviesRepository
    {
        private SqlConnection _cn;

        public string GetAllMovies()
        {
            List<Movie> movieList = new List<Movie>();

            string queryString =
                @"SELECT [MovieID]
                    ,[MovieTitle]
                    ,[MovieRating]
                    ,[ReleaseYear]
                FROM[MoviesDB].[dbo].[tblMovie]";

            using (SqlConnection connection =
                new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var movie = new Movie();
                        movie.MovieID = (int)reader[0];
                        movie.MovieTitle = (string)reader[1];
                        movie.MovieRating = (string)reader[2];
                        movie.ReleaseYear = (int)reader[3];

                        movieList.Add(movie);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // catch a data exception here
                }
                finally
                {
                    // close
                }
            }
            return JsonConvert.SerializeObject(movieList);
        }

        public Movie GetMovie(int movieID)
        {
            var movie = new Movie();

            string queryString =
                @"SELECT [MovieID]
                    ,[MovieTitle]
                    ,[MovieRating]
                    ,[ReleaseYear]
                FROM[MoviesDB].[dbo].[tblMovie]
                WHERE [MovieID] = @movieID";

            using (SqlConnection connection =
                new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@movieID", movieID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        movie.MovieID = (int)reader[0];
                        movie.MovieTitle = (string)reader[1];
                        movie.MovieRating = (string)reader[2];
                        movie.ReleaseYear = (int)reader[3];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // catch a data exception here
                }
                finally
                {
                    // close
                }
            }
            return movie;
        }
    }
}