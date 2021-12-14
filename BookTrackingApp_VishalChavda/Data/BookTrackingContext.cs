using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrackingApp_VishalChavda.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApp_VishalChavda.Data
{
    public class BookTrackingContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }

        public BookTrackingContext(DbContextOptions<BookTrackingContext> options)
           : base(options)
        {
        }
    }
}
