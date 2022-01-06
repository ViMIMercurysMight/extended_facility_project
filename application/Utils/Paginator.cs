using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Utils
{
    internal class Paginator
    {

        public Paginator()
        {

        }


        public async Task<IEnumerable<T>> GetPage<T>( int page, int pageSize, DbSet<T> db )
        {

        }

    }
}
