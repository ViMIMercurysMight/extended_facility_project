using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class QueryResult<T>
    {

        public string ErrorString { get; set; }
        public Boolean IsSucced { get; set; }
        public T       Data     { get; set; }


    }
}
