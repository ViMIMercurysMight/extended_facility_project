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
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(
            System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }


        [System.ComponentModel.DataAnnotations.Phone]
        public string PhoneNumber { get; set; }


        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string Email { get; set; }


        [Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("StatusId")]
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Id")]
        public int FacilityStatusId { get; set; }


        public virtual FacilityStatus FacilityStatus { get; set; }
    }
}
