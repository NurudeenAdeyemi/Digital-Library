using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LibraryContext : DbContext 
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);
                u.HasIndex(u => u.Email).IsUnique();
            });
        }


        public DbSet<User> Users { get; set; }

    }
}
