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
        /*public string GetAll()
        {
            using (movieContext = new MovieContext())
            {
                var movies = movieContext.Movies
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        category = p.Category.Name,
                    }).ToList();
                var sb = new StringBuilder();
                foreach (var item in movies)
                {
                    sb.AppendLine($"{ item.Name} { item.Price}  {item.category }");
                }
                return sb.ToString().Trim();
            }
        }
        public Movie GetMovie(int id)
        {
            using (movieContext = new MovieContext())
            { return movieContext.Movies.Find(id); }
        }

        public Category GetCategory(int id)
        {
            using (movieContext = new MovieContext())
            { return movieContext.Categories.Find(id); }
        }
        public void AddMovie(Product product, Category category)
        {
            using (movieContext = new MovieContext())
            {

                var categorySearch = movieContext.Categories.FirstOrDefault(c => c.Name == category.Name);
                if (categorySearch == null)
                {
                    movieContext.Categories.Add(category); //добавяме категорията
                    movieContext.SaveChanges();
                    product.CategoryId = category.Id;
                    movieContext.Movies.Add(product);//добавяме продукта
                    movieContext.SaveChanges();
                }
                else
                {
                    product.CategoryId = categorySearch.Id; //записваме id на категорията в продукта
                    movieContext.Movies.Add(product);//добавяме продукта
                    movieContext.SaveChanges();
                }
            }
        }

        public void UpdateProduct(Product product, Category category)
        {
            using (movieContext = new MovieContext())
            {
                var item = movieContext.Products.Find(product.Id);
                var categorySearched = movieContext.Categories.FirstOrDefault(c => c.Name == category.Name);
                if (item != null)
                {
                    var categorySearch = movieContext.Categories.FirstOrDefault(c => c.Name == category.Name);
                    if (categorySearch == null)
                    {
                        movieContext.Categories.Add(category); //добавяме категорията
                        movieContext.SaveChanges();
                        product.CategoryId = category.Id;
                    }
                    else
                    {
                        product.CategoryId = categorySearch.Id; //записваме id на категорията в продукта

                    }
                    movieContext.Entry(item).CurrentValues.SetValues(product);
                    movieContext.SaveChanges();
                }
            }
        }

        public void UpdateStock(int storeId, int productId, int count)
        {
            using (movieContext = new MovieContext())
            {
                var store = productContext.Stores.Find(storeId);
                var product = productContext.Products.Find(productId);
                if (store != null && product != null)
                {
                    var searchedItem = productContext.ProductsStores.FirstOrDefault(x => x.ProductId == productId && x.StoreId == storeId);
                    if (searchedItem == null)
                    {
                        ProductStore item = new ProductStore();
                        item.ProductId = productId;
                        item.StoreId = storeId;
                        item.Stock = count;
                        productContext.ProductsStores.Add(item);
                        movieContext.SaveChanges();
                    }
                    else
                    {
                        searchedItem.Stock = count;
                        movieContext.SaveChanges();
                    }

                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }

        public void Delete(int id)
        {
            using (movieContext = new MovieContext())
            {
                var product = movieContext.Movies.Find(id);
                if (product != null)
                {
                    movieContext.Movies.Remove(product);
                    movieContext.SaveChanges();
                }
            }
        }*/

        public void AddGanre(Ganre ganre)
        {
            using (movieContext = new MovieContext())
            {
                movieContext.Ganres.Add(ganre);
                movieContext.SaveChanges();
            }
        }

        public void AddFilm(Movie movie, Ganre ganre)
        {
            using (movieContext = new MovieContext())
            {

                var categorySearch = movieContext.Ganres.FirstOrDefault(c => c.Name == ganre.Name);
                if (categorySearch == null)
                {
                    movieContext.Ganres.Add(ganre); //добавяме категорията
                    movieContext.SaveChanges();
                    movie.Id = ganre.Id;
                    movieContext.Movies.Add(movie);//добавяме продукта
                    movieContext.SaveChanges();
                }
                else
                {
                    movie.Id = categorySearch.Id; //записваме id на категорията в продукта
                    movieContext.Movies.Add(movie);//добавяме продукта
                    movieContext.SaveChanges();
                }
            }
        }
    }
}
