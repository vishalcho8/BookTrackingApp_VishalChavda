using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTrackingApp_VishalChavda.Models
{
    public class Book
    {
        [Key, StringLength(13, MinimumLength = 13)] //Primary Key of length 13
        public string ISBN { get; set; }

        [StringLength(35, MinimumLength = 3)]
        public string Title { get; set; }
       
        public string Author { get; set; }

        //public string NameToken { get; set; }

        //public Category Category { get; set; }

        [ForeignKey("PrimaryCatT")]
        public string Category { get; set; }

        public Category PrimaryCatT { get; set; }

        public ICollection<CategoryType> CategoryTypes { get; set; }
    }
}
