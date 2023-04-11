
using Data.Interface.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql
{
    public class WebContext: DbContext
    {
        public WebContext() { }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments{ get; set; }

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        
            modelBuilder.Entity<Image>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Image);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Gallery;Trusted_Connection=True;");
        }

    }
}
