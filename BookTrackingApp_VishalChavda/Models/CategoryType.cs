using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTrackingApp_VishalChavda.Models
{
    public class CategoryType
    {
        [Key]
        public string Type { get; set; }

        [StringLength(32, MinimumLength = 3)]
        public string Name { get; set; }


        public ICollection<Book> Books { get; set; }
        public ICollection<Category> Categorys { get; set; }
       
    }
}
