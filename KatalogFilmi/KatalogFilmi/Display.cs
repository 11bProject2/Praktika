using Business;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogFilmi
{
    public class Display
    {
        private int closeOperationId = 7;
        private MovieBusiness movieBusiness = new MovieBusiness();

        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add Ganre");
            Console.WriteLine("2. Add Movie");
            Console.WriteLine("3. Add Person");
            Console.WriteLine("4. Edit Movie");
            Console.WriteLine("5. Remove Movie");
            Console.WriteLine("6. Get Movies");
            Console.WriteLine("7. GetAllMovieAndAuthors");
            Console.WriteLine("8. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: AddGanre(); break;
                    case 2: AddMovieAndAuthors(); break;
                    case 3: AddPerson(); break;
                    case 4: EditMovie(); break;
                    case 5: DeleteMovie();break;
                    case 6: GetMovie();break;
                    case 7: GetAllMovieAndAuthors();break;
                   case 8:  break;


                    default:
                        break;
                }
            } while (operation != closeOperationId);

        }

        private void AddGanre()
        {
            Ganre ganre = new Ganre(); ;
            Console.WriteLine("Enter name: ");
            ganre.Name = Console.ReadLine();
            
            movieBusiness.AddGanre(ganre);
        }

        private void AddMovieAndAuthors()
        {
            Movie movie = new Movie();

            Console.WriteLine("Enter Title: ");
            movie.Title = Console.ReadLine();
            Console.WriteLine("Enter Year: ");
            movie.Year = int.Parse(Console.ReadLine());

            Ganre ganre = new Ganre(); ;
            Console.WriteLine("Enter ganre: ");
            ganre.Name = Console.ReadLine();

            var authors = new List<Person>();

            string ans = "Y";
            while (ans == "y" || ans == "Y")
            {
                Person author = new Person();
                Console.WriteLine("Enter author's First Name: ");
                author.FirstName = Console.ReadLine();
                Console.WriteLine("Enter author's Last Name: ");
                author.LastName = Console.ReadLine();
                authors.Add(author);
                Console.WriteLine("Another author (y/n):");
                ans = Console.ReadLine();
            }
            var actors = new List<Person>();

             ans = "Y";
            while (ans == "y" || ans == "Y")
            {
                Person actor = new Person();
                Console.WriteLine("Enter actors's First Name: ");
                actor.FirstName = Console.ReadLine();
                Console.WriteLine("Enter actor's Last Name: ");
                actor.LastName = Console.ReadLine();
                actors.Add(actor);
                Console.WriteLine("Another actor (y/n):");
                ans = Console.ReadLine();
            } 
            movieBusiness.AddMovieAndAuthors(movie, ganre, authors,actors);

        }
        private void AddPerson()
        {
            Person person = new Person();

            Console.WriteLine("Enter person's First Name: ");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Enter person's Last Name : ");
            person.LastName = Console.ReadLine();
            movieBusiness.AddPerson(person);
        }

        private void EditMovie()
        {
            Movie movie1 = new Movie();

            Console.WriteLine("Enter movie's new title: ");
            movie1.Title = Console.ReadLine();
            Console.WriteLine("Enter movie's year: ");
            movie1.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter movie's ganre id: ");
            movie1.GanreId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter movie's new ganre: ");
            movie1.Id = int.Parse(Console.ReadLine());

            movieBusiness.EditMovie(movie1);
        }

        private void DeleteMovie()
        {
            Console.WriteLine("Enter id:");
            int id = int.Parse(Console.ReadLine());
            movieBusiness.DeletedMovie(id);

           
        }
       

        public void GetMovie()
        {
            Console.WriteLine(movieBusiness.GetMovies());
        }

        private void GetAllMovieAndAuthors()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "MOVIES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var movies = movieBusiness.GetAllMovieAndAuthors();
            Console.WriteLine(movies);
        }
    }
}
