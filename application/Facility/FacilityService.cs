using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Application.Facility
{
    public class FacilityService
    {

        private readonly IApplicationDbContext _context;
        
        public FacilityService(IApplicationDbContext context)
                  =>   _context = context;



        public async Task<FacilityDTO> GetFacility(int id)
            => (FacilityDTO)(_context.Facilities.Where(p => p.Id == id).Include( p => p.FacilityStatus ).Select(p => Map(p)));



        public async Task<Common.PaginatedList<FacilityDTO, Domain.Entities.Facility, Domain.Entities.FacilityStatus>> GetPage( int page, int pageSize)
          =>  new Common.PaginatedList<FacilityDTO, Domain.Entities.Facility, Domain.Entities.FacilityStatus>( 
              page,
              pageSize,
              _context.Facilities, 
              Map,
              p =>  p.FacilityStatus);


        public async Task<int> CreateFacility( FacilityDTO facility )
        {
            try
            {
                await _context.Facilities.AddAsync(Map(facility));
                return await _context.SaveChanges();

            } catch(ApplicationException ex)
            {
                throw ex;
            }
        }


        public async Task<int> UpdateFacility( FacilityDTO facility )
        {
            try
            {
                _context.Facilities.Update(Map(facility));
               return  await _context.SaveChanges();

            } catch(ApplicationException ex)
            {
                throw ex;
            }
           
        }


        public async Task<int> DeleteFacility( int id )
        {
            try
            {
                Domain.Entities.Facility facility =
                _context.Facilities.FirstOrDefault(p => p.Id == id);

                if (facility == null)
                    throw new ApplicationException("Facility Not Found");

                _context.Facilities.Remove(facility);
                return await _context.SaveChanges();

            }
            catch (ApplicationException ex)
            {
                throw ex;
            }

        }


        public async Task<List<FacilityDTO>> GetAll() =>
           await _context.Facilities.Include( p => p.FacilityStatus ).Select(p => Map(p)).ToListAsync();



        private static Domain.Entities.Facility Map(FacilityDTO facility)
            => (new Mapper(
                new MapperConfiguration(
                    cfg => cfg.CreateMap<FacilityDTO, Domain.Entities.Facility>()
                    )
                ).Map<Domain.Entities.Facility>(facility));

       


        private static FacilityDTO Map(Domain.Entities.Facility facility)
             => (new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<Domain.Entities.Facility, FacilityDTO>()
                .ForMember(
                    "FacilityStatus",
                    opt => opt.MapFrom<FacilityStatusDTO>(
                              c => new FacilityStatusDTO()
                              {
                                  Id = c.FacilityStatus.Id,
                                  Name = c.FacilityStatus.Name

                              }))))).Map<FacilityDTO>(facility);
    


}
}
