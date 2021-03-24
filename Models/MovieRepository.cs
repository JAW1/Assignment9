using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class MovieRepository
    {
        private static List<AddMovie> allMovies = new List<AddMovie>();
        public static IEnumerable<AddMovie> AllMovies
        {
            get { return allMovies; }
        }
        public static void Create(AddMovie movie)
        {
            allMovies.Add(movie);
        }
        public static void Delete(AddMovie movie)
        {
            allMovies.Remove(movie);
        }
    }
}
