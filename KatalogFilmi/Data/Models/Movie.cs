using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogFilmi
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]

        public string Title { get; set; }
        public int Year { get; set; }
        public int GanreId { get; set; }
        public Ganre Ganre { get; set; }
        public ICollection<MovieAuthor> MovieAuthors { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
