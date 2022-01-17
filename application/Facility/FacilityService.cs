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
                  => _context = context;



        public async Task<Common.QueryResult<FacilityDTO>> GetFacility(int id)
            => await Common.ExeptionFilter<FacilityDTO>.TryExecute(async () =>
           {
               FacilityDTO res = await _context.Facilities
                                          .Where(p => p.Id == id)
                                          .Include(p => p.FacilityStatus)
                                          .Select(p => FacilityDTO.Map(p))
                                          .FirstOrDefaultAsync();

               if (res != null)
                   return new Common.QueryResult<FacilityDTO>() { Data = res, IsSucced = true };
               else
                   return new Common.QueryResult<FacilityDTO>()
                   {
                       Data = null,
                       IsSucced = false,
                       ErrorMessage = "Element with Id Doesn`t exist"
                   };
           });




        public async Task<Common.QueryResult<Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>>> GetPage(int page, int pageSize)
         => await Common.ExeptionFilter<Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>>.TryExecute(async () =>
             {
                 Common.PaginatedList<FacilityDTO, Facility, FacilityStatus> pagenatedList = new(page, pageSize);

                 pagenatedList = await Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>.SetCount(
                              _context.Facilities,
                              pagenatedList);


                 pagenatedList = await Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>.SetPageItems(
                       _context.Facilities
                        , pagenatedList
                        , FacilityDTO.Map
                        , p => p.FacilityStatus);

                 return new Common.QueryResult<Common.PaginatedList<FacilityDTO, Facility, FacilityStatus>>()
                 {
                     Data = pagenatedList,
                     IsSucced = true
                 };

             });


        public async Task<Common.QueryResult<FacilityDTO>> CreateFacility(FacilityDTO facility)
          => await Common.ExeptionFilter<FacilityDTO>.TryExecute(async () =>
          {
              await _context.Facilities.AddAsync(FacilityDTO.Map(facility));
              await _context.SaveChanges();

              return new Common.QueryResult<FacilityDTO>()
              {
                  Data = facility,
                  IsSucced = true
              };

          });




        public async Task<Common.QueryResult<FacilityDTO>> UpdateFacility(FacilityDTO facility)
         => await Common.ExeptionFilter<FacilityDTO>.TryExecute(async () =>
            {
                _context.Facilities.Update(FacilityDTO.Map(facility));
                await _context.SaveChanges();

                return new Common.QueryResult<FacilityDTO>() { Data = facility, IsSucced = true };

            });


        public async Task<Common.QueryResult<int>> DeleteFacility(int id)
         => await Common.ExeptionFilter<int>.TryExecute(async () =>
         {

             Facility facility =
             _context.Facilities.FirstOrDefault(p => p.Id == id);

             if (facility == null)
                 return new Common.QueryResult<int>()
                 {
                     Data = id,
                     IsSucced = false,
                     ErrorMessage = "Facility with index not found"
                 };

             _context.Facilities.Remove(facility);
             await _context.SaveChanges();

             return new()
             {
                 Data = id,
                 IsSucced = true,
             };
         });




        public async Task<Common.QueryResult<List<FacilityDTO>>> GetAll()
          => await Common.ExeptionFilter<List<FacilityDTO>>.TryExecute(async () =>
                     new()
                     {
                         Data = await _context.Facilities
                                              .Include(p => p.FacilityStatus)
                                              .Select(p => FacilityDTO.Map(p))
                                              .ToListAsync(),
                         IsSucced = true
                     }
         );



        public async Task<Common.QueryResult<FacilityStatusDTO[]>> GetAllFacilityStatuses()
            => await Common.ExeptionFilter<FacilityStatusDTO[]>.TryExecute(async () => new()
               {
                   Data = new[]
            {
                 new FacilityStatusDTO(){ Name = "Inactive", Id = (int)Domain.Enums.FacilityStatus.INACTIVE },
                 new  FacilityStatusDTO(){ Name = "Active", Id = (int)Domain.Enums.FacilityStatus.ACTIVE },
                 new  FacilityStatusDTO(){ Name = "OnHold", Id = (int)Domain.Enums.FacilityStatus.ON_HOLD },

            },
                   IsSucced = true
               }

           );
    }
}
