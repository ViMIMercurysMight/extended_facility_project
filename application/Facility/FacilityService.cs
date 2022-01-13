using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Application.Facility
{
    public class FacilityService
    {

        private readonly IApplicationDbContext _context;
        
        public FacilityService(IApplicationDbContext context)
                  =>   _context = context;



        public async Task<FacilityDTO> GetFacility(int id)
            => (FacilityDTO)(_context.Facilities.Where(p => p.Id == id).Include( p => p.FacilityStatus ).Select(p => Map(p)));



        public async Task<Common.PaginatedList<FacilityDTO, Domain.Entities.Facility>> GetPage( int page, int pageSize)
          =>  new Common.PaginatedList<FacilityDTO, Domain.Entities.Facility>( page, pageSize, _context.Facilities, Map, "FacilityStatus");


        //new Domain.Entities.Facility() { Name = facility.Name, Address = facility.Address, Email = facility.Email, PhoneNumber = facility.PhoneNumber }
        public async Task<int> CreateFacility( FacilityDTO facility )
        {
            await _context.Facilities.AddAsync( Map(facility ));
           return await _context.SaveChanges();
        }


        public async Task<int> UpdateFacility( FacilityDTO facility )
        {

            _context.Facilities.Update( Map(facility) );
            return await _context.SaveChanges();
        }


        public async Task<int> DeleteFacility( int id )
        {

            Domain.Entities.Facility facility =
                _context.Facilities.FirstOrDefault( p => p.Id == id );

            if( facility != null )
            {
                _context.Facilities.Remove(facility);
               return await _context.SaveChanges();
            }

            return -1;
        }


        public async Task<List<FacilityDTO>> GetAll() =>
           await _context.Facilities.Include( p => p.FacilityStatus ).Select(p => Map(p)).ToListAsync();



        private static Domain.Entities.Facility Map(FacilityDTO facility) 
            => new()
        {
            Address = facility.Address,
            Email   = facility.Email,
            FacilityStatusId = facility.FacilityStatusId ,
            Id   = facility.Id,
            Name = facility.Name,
            PhoneNumber = facility.PhoneNumber
        };


        private static FacilityDTO Map(Domain.Entities.Facility facility) 
            => new()
        {
            Id      = facility.Id,
            Name    = facility.Name,
            Address  = facility.Address,
            Email    = facility.Email,
            PhoneNumber = facility.PhoneNumber,
            FacilityStatus = new FacilityStatusDTO()
            {
                Id   = facility.FacilityStatus.Id,
                Name = facility.FacilityStatus.Name

            }
        };


}
}
