using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Facility
{
    public class FacilityDTO
    {

        public int    Id          { get; set; }
        public string Name        { get; set; }
        public string PhoneNumber { get; set; }
        public string Email       { get; set; }
        public string Address     { get; set; }

        public int   FacilityStatusId { get; set; }
        public FacilityStatusDTO FacilityStatus { get; set; }


    }
}
