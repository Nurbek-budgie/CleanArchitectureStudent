﻿using Microsoft.EntityFrameworkCore;
using Students.Application.Interfaces;
using Students.Domain;
using Students.Persistence.EntityTypeConfigurations;

namespace Students.Persistence
{
    public class StudentDbContext : DbContext, IStudentsDbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new StudentConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
