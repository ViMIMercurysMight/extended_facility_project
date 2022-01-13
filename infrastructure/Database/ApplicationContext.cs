using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;


namespace Infrastructure
{
    public class ApplicationContext 
        : DbContext
        , IApplicationDbContext
    
    {
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Patient>  Patients  { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Database.Configurations.FaclityConfiguration).Assembly);

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                    : base(options) { };
 
        public ApplicationContext() { }

        public async Task<int> SaveChanges()
            => await base.SaveChangesAsync();

    }
}
