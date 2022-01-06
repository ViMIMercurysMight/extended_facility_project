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
        public DbSet<Facility> Facility { get; set; }
        public DbSet<Patient>  Patient  { get; set; }



        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.\\SQLEXPRESS;Initial Catalog=facilityDB;Integrated Security=True");
        }



        public override int SaveChanges()
            => base.SaveChanges();

    }
}
