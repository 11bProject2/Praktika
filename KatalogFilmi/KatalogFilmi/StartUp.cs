using Data;
using System;

namespace KatalogFilmi
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MovieContext db = new MovieContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
