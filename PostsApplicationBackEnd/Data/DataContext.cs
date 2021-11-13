using Microsoft.EntityFrameworkCore;
using PostsApplicationBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsApplicationBackEnd.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcel>()
                .HasOne(r => r.Post)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
