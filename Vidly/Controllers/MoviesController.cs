using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movieList = new MovieList();
            movieList.Movies = GetRadomMovieList();

            return View(movieList);
        }

        private List<RandomMovieViewModel> GetRadomMovieList()
        {
            List<RandomMovieViewModel> Movies = new List<RandomMovieViewModel>()
            {
                new RandomMovieViewModel
                {
                    Movie = new Movie
                    {
                        Id = 1,
                        Name = "Sherk",
                    },
                    Customers = GetCustomer(3),
                },

                new RandomMovieViewModel
                {
                    Movie = new Movie
                    {
                        Id = 2,
                        Name = "Wall-e",
                    },
                    Customers = GetCustomer(5),
                }
            };

            return Movies;
        }

        private List<Customer> GetCustomer(int num)
        {
            List<Customer> customers = new List<Customer>();
            for (int i = 1; i <= num; i++)
            {
                customers.Add(new Customer { Id = i, Name = "Customer " + i });
            }
            return customers;
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult MovieInfo(int Id)
        {
            var movie = GetRadomMovieList().FirstOrDefault(m => m.Movie.Id == Id);

            if(movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }
    }
}