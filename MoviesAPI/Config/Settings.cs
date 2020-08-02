using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MoviesAPI.Config
{
    public class Settings
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = WebConfigurationManager.ConnectionStrings["MoviesDB"].ConnectionString;
                }

                return _connectionString;
            }
        }
    }
}