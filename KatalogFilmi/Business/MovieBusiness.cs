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
        public void AddMovieAndAuthors(Movie movie,Ganre ganre, List<Person> authors)
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
        public void EditMovie(int id, string title, int year, int ganreid)
        {
            using (movieContext = new MovieContext())
            {
                var movie = movieContext.Movies.Find(id);

                if (movie != null)
                {
                    var searchedItem = movieContext.Movies.FirstOrDefault(x => x.Id == id);
                    Movie movie1 = new Movie();

                    if (searchedItem == null)
                    {
                        movie1.Title = title;
                        movie1.Year = year;
                        movie1.GanreId = ganreid;
                        movie1.Ganre = movieContext.Ganres.Find(ganreid);

                        movieContext.Movies.Add(movie1);
                        movieContext.SaveChanges();
                    }
                    else
                    {
                        movie1.Title = title;
                        movie1.Year = year;
                        movie1.GanreId = ganreid;
                        movie1.Ganre = movieContext.Ganres.Find(ganreid);

                        movieContext.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine("Eror 404: Movie not found!");
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

    }
}
