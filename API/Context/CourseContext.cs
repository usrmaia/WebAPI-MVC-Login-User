using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context.Mappings;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Context
{
    public class CourseContext : DbContext
    {
         public CourseContext(DbContextOptions<CourseContext> options) : base(options)
         {
            
         }

         public DbSet<User> User { get; set; }
         public DbSet<Course> Course { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
         } 
    }
}