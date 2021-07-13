using Data;
using KatalogFilmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MovieBusiness
    {

        private MovieContext movieContext;

        public void AddGanre(Ganre ganre)
        {
            using (movieContext = new MovieContext())
            {
                if (ganre != null)
                {
                    movieContext.Ganres.Add(ganre);
                    movieContext.SaveChanges();
                }
            }
        }
        public void AddMovieAndAuthors(Movie movie,Ganre ganre, List<Person> authors,List<Person> actors)
        {
            using (movieContext = new MovieContext())
            {
                var ganreSearch = movieContext.Ganres.FirstOrDefault(c => c.Name == ganre.Name);
                if (ganreSearch == null)
                {
                    movieContext.Ganres.Add(ganre); //добавяме категорията
                    movieContext.SaveChanges();
                    movie.GanreId = ganre.Id;
                }
                else
                {
                    movie.GanreId = ganre.Id; //записваме id на категорията в продукта
                }
                movieContext.Movies.Add(movie);
                movieContext.SaveChanges();
                MovieAuthor movieAuthor = new MovieAuthor();
                MovieActor movieActor = new MovieActor();
                foreach (var author in authors)
                {
                    var itemAuthor = movieContext.Persons.FirstOrDefault(x => x.FirstName == author.FirstName && x.LastName == author.LastName);
                    if (itemAuthor == null)
                    {
                        movieContext.Persons.Add(author);
                        movieContext.SaveChanges();
                        itemAuthor = movieContext.Persons.OrderBy(a => a.Id).Last();

                    }
                    movieAuthor.AuthorId = itemAuthor.Id;
                    movieAuthor.MovieId = movie.Id;

                    movieContext.MoviesAuthors.Add(movieAuthor);
                    movieContext.SaveChanges();
                }

                foreach (var actor in actors)
                {
                    var itemActor = movieContext.Persons.FirstOrDefault(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName);
                    if (itemActor == null)
                    {
                        movieContext.Persons.Add(actor);
                        movieContext.SaveChanges();
                        itemActor = movieContext.Persons.OrderBy(a => a.Id).Last();

                    }
                    movieActor.ActorId = itemActor.Id;
                    movieActor.MovieId = movie.Id;

                    movieContext.MoviesActors.Add(movieActor);
                    movieContext.SaveChanges();
                }
                


            }
        }
        public void AddPerson(Person person)
        {
            using (movieContext = new MovieContext())
            {
                if (person != null)
                {
                    movieContext.Persons.Add(person);
                    movieContext.SaveChanges();
                }
            }
        }
        public void AddActor(MovieActor movieActor, MovieAuthor movieAuthor)
        {
            using (movieContext = new MovieContext())
            {
                if (movieActor != null && movieAuthor != null)
                {
                    movieContext.MoviesActors.Add(movieActor);
                    movieContext.MoviesAuthors.Add(movieAuthor);
                    movieContext.SaveChanges();
                }
            }
        }
        public void EditMovie(Movie movie)
        {
            using (movieContext = new MovieContext())
            {
                var searchedMovie = movieContext.Movies.Find(movie.Id);

                if (movie != null)
                {
                    var searchedItem = movieContext.Movies.FirstOrDefault(x => x.Id == movie.Id);
                    Movie movie1 = new Movie();

                    if (searchedItem == null)
                    {
                        movie1.Title = movie.Title;
                        movie1.Year = movie.Year;
                        movie1.GanreId = movie.GanreId;
                        movie1.Ganre = movieContext.Ganres.Find(movie.GanreId);

                        movieContext.Movies.Add(movie1);
                        movieContext.SaveChanges();
                    }
                    else
                    {
                        movie1.Title = movie.Title;
                        movie1.Year = movie.Year;
                        movie1.GanreId = movie.GanreId;
                        movie1.Ganre = movieContext.Ganres.Find(movie.GanreId);

                        movieContext.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine("Error 404: Movie not found!");
                }
            }
        }

        public void DeletedMovie(int id)
        {
            using (movieContext = new MovieContext())
            {
                var deletedMovie = movieContext.Movies.Find(id);

                if (deletedMovie != null)
                {
                    movieContext.Movies.Remove(deletedMovie);
                    movieContext.SaveChanges();
                }
            }
        }
        public string GetMovies()
        {
            using (movieContext = new MovieContext())
            {
                var movie = movieContext.Movies.Select(x => new { x.Id, x.Title, x.Year, x.GanreId }).ToList();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in movie)
                {
                    stringBuilder.AppendLine($"{item.Id} {item.Title} {item.Year} {item.GanreId}");
                }
                return stringBuilder.ToString();
            }
        }
        public string GetAllMovieAndAuthors()
        {
            using (movieContext = new MovieContext())
            {
                var movies = movieContext.Movies
                    .Select(m => new
                    {
                        m.Title,
                        m.Year,

                    }).ToList();
                var sb = new StringBuilder();
                foreach (var movie in movies)
                {
                    sb.AppendLine($"{movie.Title} {movie.Year}");
                }

                return sb.ToString().TrimEnd();
            }
        }

        public string GetAllMovieAndActors()
        {
            using (movieContext = new MovieContext())
            {
                var movies = movieContext.Movies
                    .Select(m => new
                    {
                        m.Title,
                        m.Year,

                    }).ToList();
                var sb = new StringBuilder();
                foreach (var movie in movies)
                {
                    sb.AppendLine($"{movie.Title} {movie.Year}");
                }

                return sb.ToString().TrimEnd();
            }
        }


    }
}
