using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Patient
{
    public class PatientDTO
    {
        public int      Id          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int?     FacilityId  { get; set; }

        public Facility.FacilityDTO Facility { get; set; }

    }
}
