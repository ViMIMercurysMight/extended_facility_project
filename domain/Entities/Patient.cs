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

        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(
             System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Schema.Column( TypeName = "nvarchar(125)") ]
        public string FirstName { set; get; }
        

        [Required]
        [System.ComponentModel.DataAnnotations.Schema.Column( TypeName = "nvarchar(125)")]
        public string LastName { set; get; }


        [Required]
        [ DataType( DataType.Date ) ]
        public DateTime DateOfBirth { set; get; }



        [System.ComponentModel.DataAnnotations.Schema.Column("FacilityId")]
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Id")]
        public int? FacilityId { get; set; }

        public Facility Facility { set; get; }

    }
}
