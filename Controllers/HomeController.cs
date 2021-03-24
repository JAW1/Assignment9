using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment9.Models.ViewModels;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }

        //constructor
        public HomeController(MovieContext movieCon)
        {
            context = movieCon;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //This is where the movie page is called
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        //This is where a movie is added
        [HttpPost]
        public IActionResult AddMovie(AddMovie addMovie)
        {
            context.Movies.Add(addMovie);

            context.SaveChanges();
            return View("Confirmed", addMovie);
        }
        //This is where the movies are listed out
        public IActionResult ListMovies()
        {
            return View(context.Movies);
        }
        //confirmation page for adding files
        public IActionResult Confirmed()
        {
            return View();
        }
        //show podcast page
        public IActionResult MyPodcasts()
        {
            return View();
        }
        //Edit
        public IActionResult Edit(int movieId)
        {
            AddMovie movie = context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault();
            
            return View(movie);
        }
        //this is where it assigns all the new edits
        [HttpPost]
        public IActionResult Edit(AddMovie movie, int movieId)
        {
            context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault().Category = movie.Category;
            context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault().Title = movie.Title;
            context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault().Director = movie.Director;
            context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault().Edited = movie.Edited;
            context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault().Year = movie.Year;
            context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault().Rating = movie.Rating;
            context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault().LentTo = movie.LentTo;
            context.Movies.Where(e => e.MovieID == movieId).FirstOrDefault().Notes = movie.Notes;

            context.SaveChanges();
            return RedirectToAction("ListMovies");
        }
        //this is where a record is deleted
        [HttpPost]
        public IActionResult Delete(int movieID)
        {
            AddMovie movie = context.Movies.Where(e => e.MovieID == movieID).FirstOrDefault();
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("ListMovies");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
