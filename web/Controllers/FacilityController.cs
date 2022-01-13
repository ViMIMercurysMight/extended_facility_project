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

        private readonly Application.Facility.FacilityService _facilityService;



        public FacilityController(Application.Facility.FacilityService facilityService)
          => _facilityService = facilityService;

        public IActionResult Index() => View();


        [HttpGet("Facility/{id:int}")]
        public async Task<IActionResult> GetFacility(int id)
        {
            try
            {
                var req = await _facilityService.GetFacility(id);
                return ((IActionResult)req);
            }
            catch( Exception ex)
            {
                return Json(ex.Message);
            }
        }




        [HttpGet]
        public async Task<IActionResult> GetFacility( int page, int pageSize)
        {

            try
            {
                var req = await _facilityService.GetPage(page, pageSize);
                return Json(req);
              
            } catch( Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostFacility([FromBody][Bind("Name", "Address", "PhoneNumber", "Email")] Application.Facility.FacilityDTO facility )
         {

            try
            {
                await _facilityService.CreateFacility( facility );
                return Json( facility );
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }


        }


        [HttpPut]
        public async Task<IActionResult> PutFacility([FromBody][Bind("Id", "Name", "Address", "PhoneNumber", "Email", "FacilityStatusId")] Application.Facility.FacilityDTO facility)
        {
            try
            {
                 await _facilityService.UpdateFacility( facility );
                return Json(facility);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteFacility( int? id )
        {
            try
            {
                await _facilityService.DeleteFacility((int)id);
                return Json((int)id);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

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
