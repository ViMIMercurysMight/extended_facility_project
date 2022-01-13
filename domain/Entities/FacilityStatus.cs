using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class FacilityStatus
    {
        public int Id      { get; set; }
        public string Name { get; set; }


        public List<Facility> Facility    { get; set; }   
    }
}
