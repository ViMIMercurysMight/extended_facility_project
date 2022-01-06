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
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }


        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Name { get; set; }
    }
}
