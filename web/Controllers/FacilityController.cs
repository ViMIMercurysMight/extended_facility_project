using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Infrastructure;
using Application;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class FacilityController : Controller
    {

        private readonly ILogger<FacilityController> _logger;
        private readonly Infrastructure.ApplicationContext _context;
        private readonly Application.Facility.FacilityService _facilityService;

        

        public FacilityController(
            ILogger<FacilityController> logger,
            Infrastructure.ApplicationContext context
            )
        {
            _context = context;
            _facilityService = new Application.Facility.FacilityService(context);
            _logger = logger;
        }


        public IActionResult Index() => View();


        [HttpGet("Facility/{id:int}")]
        public async Task<IActionResult> GetFacility(int id)
        {
            try
            {
                var model = await _context.Facility.FindAsync(id);
                return Json(model);
            }
            catch( Exception ex)
            {
                return Json(ex.Message);
            }
        }



        [HttpGet]
        public IActionResult GetCountOfPages( int perPage )
        {
            var listCount = 0;

            using (_context)
            {

                SqlParameter param = new()
                {
                    ParameterName = "@count",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,

                };
                _context.Database.ExecuteSqlRaw("GetCountOfFacilities @count OUT", param);


                listCount = (int)param.Value;
            }

            if (listCount == 0)
                return Json(listCount);

            return Json(listCount % perPage == 0
        ? (listCount / perPage) - 1
        : listCount / perPage);
        }


        [HttpGet]
        public async Task<IActionResult> GetFacility( int page, int pageSize)
        {
            try
            {
                if (_context.Facility.Count() > 0)
                {

                    var model = await _context.Facility
                           .Skip(page * pageSize)
                           .Except(_context.Facility.Skip((page * pageSize) + pageSize))
                           .Include(e => e.FacilityStatus)
                           .ToListAsync();

                    return Json(model);
                } else
                {
                    return Json(new { });
                }
            } catch( Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpPost]
        public  IActionResult PostFacility([FromBody][Bind("Name", "Address", "PhoneNumber", "Email")] Domain.Entities.Facility facility )
         {

            try
            {
                _facilityService.CreateFacility( facility );
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

            return  Json( true );

        }


        [HttpPut]
        public  IActionResult PutFacility([FromBody][Bind("Id", "Name", "Address", "PhoneNumber", "Email", "FacilityStatusId")] Domain.Entities.Facility facility)
        {
            try
            {
                 _facilityService.UpdateFacility( facility );
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

            return Json( true );
        }


        [HttpDelete]
        public  IActionResult DeleteFacility( int? id )
        {
            if (id == null)
                return NotFound();


            try
            {
                 _facilityService.DeleteFacility((int)id);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

            return Json( true );
        }



        [HttpGet]
        public IActionResult GetAll()
        {


            return Json(new[]
            {
                 new { Name = "Inactive", Id = Domain.Enums.FacilityStatus.INACTIVE },
                 new { Name = "Active", Id = Domain.Enums.FacilityStatus.ACTIVE },
                 new { Name = "OnHold", Id = Domain.Enums.FacilityStatus.ON_HOLD },

            } ); 
        }

    }
}
