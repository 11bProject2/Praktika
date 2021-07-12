using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogFilmi
{
    public class Display
    {
        private int closeOperationId = 8;
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
            Console.WriteLine("1.Add ganre");
            //Console.WriteLine("2. Add new film");
            //Console.WriteLine("3. Add person");
            //Console.WriteLine("4. Fetch product  by ID");
            //Console.WriteLine("5. Delete product  by ID");
            //Console.WriteLine("6. Add new store");
            //Console.WriteLine("7. Update stock by storeId and productId");
            //Console.WriteLine("8. Exit");

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
                    case 2: AddFilm(); break;
                    case 3: AddAuthor(); break;
                    /*case 4: Fetch(); break;
                    case 5: Delete(); break;
                    case 6: AddStore(); break;
                    case 7: UpdateStock(); break;*/

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

        private void AddFilm()
        {
            Movie movie = new Movie();
            Console.WriteLine("Enter name: ");
            movie.Title = Console.ReadLine();
            Ganre ganre = new Ganre(); ;
            Console.WriteLine("Enter name: ");
            ganre.Name = Console.ReadLine();

            movieBusiness.AddFilm(movie, ganre);
        }

        private void AddAuthor()
        {
            MovieAuthor movieAuthor = new MovieAuthor(); ;
            Console.WriteLine("Enter name: ");
            movieAuthor.Author = Console.ReadLine();

            movieBusiness.AddAuthor(movieAuthor);
        }

    }
}
