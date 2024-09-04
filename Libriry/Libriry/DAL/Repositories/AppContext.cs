using Library.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    internal class AppContext : DbContext
    {
         
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-38FCAKT\SQLEXPRESS;Database=Library;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
