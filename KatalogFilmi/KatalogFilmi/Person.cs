using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogFilmi
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Personality { get; set; }
    }
}
