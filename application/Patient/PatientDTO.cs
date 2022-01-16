using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Patient
{

    using Domain.Entities;

    public class PatientDTO
    {
        public int      Id          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int?     FacilityId  { get; set; }

        public Application.Facility.FacilityDTO Facility { get; set; }




        internal static Patient Map(PatientDTO patient)
          => (new Mapper(new MapperConfiguration(
              cfg => cfg.CreateMap<PatientDTO, Patient>()))
          .Map<Patient>(patient));



        internal static PatientDTO Map(Patient patient)
            => (new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<Patient, PatientDTO>()
                .ForMember("Facility", opt => opt.MapFrom(
                    c => new Application.Facility.FacilityDTO()
                    {
                        Id = c.Facility.Id,
                        Name = c.Facility.Name,
                        Email = c.Facility.Email,
                        PhoneNumber = c.Facility.PhoneNumber,
                        Address = c.Facility.Address,
                        FacilityStatus = new Application.Facility.FacilityStatusDTO()
                    }))))).Map<PatientDTO>(patient);

    }
}
