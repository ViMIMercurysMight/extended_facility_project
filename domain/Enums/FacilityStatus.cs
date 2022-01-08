using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    //The enumeration matches the indexes in the facilityStatus table
    public enum FacilityStatus
    {
        ACTIVE   = 1,
        INACTIVE = 2,
        ON_HOLD  = 3,
    }
}
