using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IApplicationDbContext
    {
        DbSet<Facility> Facility { set; get; }
        DbSet<Patient>  Patient { set; get; }

        void SaveChanges();

    }
}
