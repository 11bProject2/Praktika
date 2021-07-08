using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogFilmi
{
    public class MovieAuthor
    {
        public int MovieId { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public Movie Movie { get; set; }
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public Author Author { get; set; }
    }
}
