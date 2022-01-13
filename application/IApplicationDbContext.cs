using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IApplicationDbContext 
    {
        DbSet<Domain.Entities.Facility> Facilities { set; get; }
        DbSet<Domain.Entities.Patient>  Patients   { set; get; }

        Task<int> SaveChanges();

    }
}
