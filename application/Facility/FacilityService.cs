using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Application.Facility
{

    using Domain.Entities;
    public class FacilityService
    {

        private readonly IApplicationDbContext _context;
        
        public FacilityService(IApplicationDbContext context)
                  =>   _context = context;



        public async Task<Common.QueryResult<FacilityDTO>> GetFacility(int id)
        {


          FacilityDTO res =  await _context.Facilities
                                    .Where(p => p.Id == id)
                                    .Include(p => p.FacilityStatus)
                                    .Select(p => FacilityDTO.Map(p))
                                    .FirstOrDefaultAsync();

            if (res != null)
                return new Common.QueryResult<FacilityDTO>() { Data = res, IsSucced = true };
            else
                return new Common.QueryResult<FacilityDTO>() { 
                    Data = null,
                    IsSucced = false,
                    ErrorString = "Element with Id Doesn`t exist" };
        }




        public async Task<Common.QueryResult<Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>>> GetPage(int page, int pageSize)
        {

            Common.PaginatedList<FacilityDTO, Facility, FacilityStatus> pagenatedList = new(page, pageSize);

            pagenatedList = await Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>.SetCount(
                     _context.Facilities,
                     pagenatedList );


            pagenatedList = await Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>.SetPageItems(
              _context.Facilities
               ,pagenatedList
               , FacilityDTO.Map
               , p => p.FacilityStatus);

            return new Common.QueryResult<Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>>() {
                Data = pagenatedList,
                IsSucced=true 
            };
      
        }

        public async Task<Common.QueryResult<FacilityDTO>> CreateFacility( FacilityDTO facility )
        {
          return  await Common.ExeptionFilter<FacilityDTO>.TryExecute( async () =>
            {
               await _context.Facilities.AddAsync(FacilityDTO.Map(facility));
               await _context.SaveChanges();

               return new Common.QueryResult<FacilityDTO>()
               {
                   Data = facility,
                   IsSucced = true
               };

            });
        }



        public async Task<Common.QueryResult<FacilityDTO>> UpdateFacility( FacilityDTO facility )
        {
                _context.Facilities.Update(FacilityDTO.Map(facility));
                await _context.SaveChanges();

                return new Common.QueryResult<FacilityDTO>() { Data = facility, IsSucced = true };
                     
        }


        public async Task<Common.QueryResult<int> > DeleteFacility( int id )
        {

                Facility facility =
                _context.Facilities.FirstOrDefault(p => p.Id == id);

            if (facility == null)
                return new Common.QueryResult<int>() { 
                    Data = id, 
                    IsSucced = false,
                    ErrorString = "Facility with index not found" };

            try
            {
                _context.Facilities.Remove(facility);
                await _context.SaveChanges();

                return new()
                {
                    Data = id,
                    IsSucced = true
                };
            }
            catch (Exception ex)
            {
                var exec = ex;

                return new();
            }



        }


        public async Task<Common.QueryResult<List<FacilityDTO>>> GetAll() =>
                   new()
                   {
                       Data = await _context.Facilities
                                            .Include(p => p.FacilityStatus)
                                            .Select(p => FacilityDTO.Map(p))
                                            .ToListAsync(),
                       IsSucced = true
                   };

}
}
