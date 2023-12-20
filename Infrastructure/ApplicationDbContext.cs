using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder) =>
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
       
    }
}
