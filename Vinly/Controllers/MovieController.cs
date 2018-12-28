using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vinly.Models;
using Vinly.ViewModels;

namespace Vinly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _contex;

        public MovieController()
        {

            _contex = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ViewResult Index()
        {
            var movies = _contex.Movies.Include(c => c.MovieGenre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
                var movie = _contex.Movies.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);

                if (movie == null)
                    return HttpNotFound();

                return View(movie);
            
        }

        public ActionResult New()
        {
            var genra = _contex.MovieGenres.ToList();
            var viewModel = new NewMovieViewModel(){
                Genre = genra
            };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid) {

                var movieCheck = new NewMovieViewModel(movie)
                {
                    Genre = _contex.MovieGenres.ToList()
                };

                return View ("MovieForm",movieCheck);
            }
            if (movie.Id == 0)
                _contex.Movies.Add(movie);

            else
            {
                var MovieInDb = _contex.Movies.Single(c => c.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.MovieGenreId = movie.MovieGenreId;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }

            _contex.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _contex.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel(movie)
            {
                Genre = _contex.MovieGenres .ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}
