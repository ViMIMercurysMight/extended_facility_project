using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Patient
    {

        public string FirstName { set; get; }
        
        public string LastName { set; get; }

        [ DataType( DataType.Date ) ]
        public DateTime DateOfBirth { set; get; }

        
        public Facility Facility { set; get; }

    }
}
