using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    internal class ExeptionFilter<T>
    {
        public delegate Task<Common.QueryResult<T>> TryCallback( );

        public static async Task<Common.QueryResult<T>> TryExecute( TryCallback tryExecute )
        {
            try
            {
                return await tryExecute();

            } catch ( Exception ex)
            {
                return _Filter(ex);
            }
        }


        private static Common.QueryResult<T> _Filter( Exception ex )
        {
            return new()
            {
                IsSucced = false,
                ErrorMessage = ex.InnerException.Message
            };
        }

    }
}
