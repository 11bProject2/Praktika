using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogFilmi
{
    public class Ganre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]

        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}