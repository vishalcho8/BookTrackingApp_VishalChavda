using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTrackingApp_VishalChavda.Models
{
    public class Category
    {
        [Key] //Primary Key
        public string NameToken { get; set; }

        public int Type { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
