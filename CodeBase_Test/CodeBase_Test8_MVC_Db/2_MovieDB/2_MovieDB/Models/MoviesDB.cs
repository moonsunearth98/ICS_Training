using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _2_MovieDB.Models
{
    public class MoviesDB : DbContext
    {
        public MoviesDB() : base("MoviesDB")

        {

        }
        public DbSet<Movies> Movie { get; set; }

    }
}