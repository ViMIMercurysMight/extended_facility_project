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
        DbSet<Domain.Entities.Facility> Facility { set; get; }
        DbSet<Domain.Entities.Patient>  Patient { set; get; }

        void SaveChanges();

    }
}
