using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<SeparationSugestion> SeparationSugestion { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<UserMaterialType> UserMaterialTypes { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(c => c.Type)
                .HasConversion<string>();
            modelBuilder.Entity<UserMaterialType>()
                .HasKey(um => new { um.UserId, um.MaterialTypeId });
            



        }
    }
}
