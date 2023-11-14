using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2_MovieDB.Models;
using System.Data.Entity;
using System.Net;

namespace _2_MovieDB.Controllers
{
    public class MovieController : Controller
    {
        private MoviesDB dbContext = new MoviesDB();
        // GET: Movie
        public ActionResult Index()
        {
            return View(dbContext.Movie.ToList());
        }

        // Details of Movie
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = dbContext.Movie.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


        // Create a new movie
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movies movie)
        {
            dbContext.Movie.Add(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Edit an existing movie

        public ActionResult Edit(int id)
        {
            var movie = dbContext.Movie.Find(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movies movie)
        {
            dbContext.Entry(movie).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete a movie
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var movie = dbContext.Movie.Find(id);
            dbContext.Movie.Remove(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Display movies released in a given year
        public ActionResult MoviesByYear(int year)
        {
            var moviesInYear = dbContext.Movie.Where(m => m.DateofRelease.Year == year).ToList();
            return View(moviesInYear);
        }
    }
}