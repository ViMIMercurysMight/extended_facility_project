using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Domain.Entities
{
    public class Facility
    {

        public int    Id            { get; set; }
        public string Name          { get; set; }
        public string Address       { get; set; }
        public string PhoneNumber   { get; set; }
        public string Email         { get; set; }
        public int FacilityStatusId { get; set; }


        public FacilityStatus FacilityStatus { get; set; }
        public List<Patient> Patient { get; set; }
    }
}
