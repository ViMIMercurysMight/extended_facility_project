using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace Application.Facility
{
    using Domain.Entities;
    public class FacilityDTO
    {

        public int    Id          { get; set; }
        public string Name        { get; set; }
        public string PhoneNumber { get; set; }
        public string Email       { get; set; }
        public string Address     { get; set; }

        public int   FacilityStatusId { get; set; }
        public FacilityStatusDTO FacilityStatus { get; set; }




        internal static Facility Map(FacilityDTO facility)
          => (new Mapper(
              new MapperConfiguration(
                  cfg => cfg.CreateMap<FacilityDTO, Facility>()
                  )
              ).Map<Facility>(facility));




        internal static FacilityDTO Map(Facility facility)
             => (new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<Facility, FacilityDTO>()
                .ForMember(
                    "FacilityStatus",
                    opt => opt.MapFrom(
                              c => new FacilityStatusDTO()
                              {
                                  Id = c.FacilityStatus.Id,
                                  Name = c.FacilityStatus.Name

                              }))))).Map<FacilityDTO>(facility);
    }
}
