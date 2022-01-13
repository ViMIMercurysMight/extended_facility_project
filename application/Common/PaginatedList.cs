using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Application.Common
{
    public class PaginatedList<T, K, N> where K : class
    {

        public delegate T Mapper( K arg );
        
        public delegate System.Linq.Expressions.Expression<Func<K, N>> Includer( K arg );

        public List<T> PageItems { set; get; }
        public int Page      { set; get; }
        public int PageSize  { set; get; }
        public int PageCount { set; get; }
            

        public PaginatedList( int page, int pageSize, DbSet<K> query, Mapper mapper, System.Linq.Expressions.Expression<Func<K, N>> includedNavProp = null )
        {
            Page = page;
            PageSize = pageSize;

            int total = query.Count();
            PageCount = total != 0 ? 
                total % pageSize == 0  ? (total / pageSize) - 1 : ( total / pageSize )  
                 : 0;
        

            PageItems = includedNavProp == null ? query
                           .Skip(Page * PageSize)
                           .Take(PageSize)
                           .Select(p => mapper(p))
                           .ToListAsync()
                           .Result : query
                                       .Skip(Page * PageSize)
                                       .Take(PageSize)
                                       .Include( includedNavProp )
                                       .Select(p => mapper(p))  
                                       .ToListAsync()
                                       .Result;
        }
 

    }
}
