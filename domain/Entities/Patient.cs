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

        public int    Id            { get; set; }
        public string FirstName     { set; get; }
        public string LastName      { set; get; }

        public DateTime DateOfBirth { set; get; }
        public int?     FacilityId  { get; set; }

        public Facility Facility    { set; get; }

    }
}
