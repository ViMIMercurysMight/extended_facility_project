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
    public class ApplicationContext : IApplicationDbContext
    {
        public DbSet<Facility> Facility { get; set; }
        public DbSet<Patient> Patient { get; set; }

        public void SaveChanges()
        {

        }

    }
}
