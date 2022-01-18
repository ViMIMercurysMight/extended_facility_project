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

        public delegate T Mapper(K arg);

        
        public List<T> PageItems { set; get; }
        public int Page { set; get; }
        public int PageSize { set; get; }
        public int PageCount { set; get; }
        public int Total { set; get; }

        public PaginatedList(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }



        public static async Task<PaginatedList<T,K,N>> SetCount(DbSet<K> query, PaginatedList<T, K, N> page)
        {
            int count = await query.CountAsync();

            page.Total = count; 

            page.PageCount = count != 0 ?
              count % page.PageSize == 0 ? (count / page.PageSize) - 1 : (count / page.PageSize)
               : 0;

            return page;
        }



        public static async Task<PaginatedList<T,K,N>> SetPageItems( 
             DbSet<K> query
            ,PaginatedList<T, K, N> page
            ,Mapper mapper
            ,System.Linq.Expressions.Expression<Func<K, N>> includedNavProp = null)
        {
            page.PageItems = includedNavProp == null ? await query
                           .Skip(page.Page * page.PageSize)
                           .Take(page.PageSize)
                           .Select(p => mapper(p))
                           .ToListAsync()
                            : await query
                                       .Skip(page.Page * page.PageSize)
                                       .Take(page.PageSize)
                                       .Include(includedNavProp)
                                       .Select(p => mapper(p))
                                       .ToListAsync()
                                       ;


            return page;
        }
    }
}
