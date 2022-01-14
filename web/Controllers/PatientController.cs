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
    public class PatientController : Controller
    {
 
        private readonly Application.Patient.PatientService   _patientService;
        private readonly Application.Facility.FacilityService _facilityService;
    


        public PatientController( 
              Application.Patient.PatientService patientService
            , Application.Facility.FacilityService facilityService 
        ) {
            _patientService = patientService;
            _facilityService = facilityService;
        }

        public IActionResult Index() => Json("Main Patient Page Index Action");
  


        [HttpGet("Patient/{id:int}")]
        async public Task<IActionResult> GetPatient( int id )
        {
            try
            {
                var model = await _patientService.GetPatient(id);
                return Json(model);

            } catch(Exception ex)
            {
                return Json(ex);
            }



        }


        [HttpGet]
        public async Task<IActionResult> GetPatient( int page, int pageSize )
        {
            try
            {
                var req = await _patientService.GetPage(page, pageSize);
                return Json(req);

            } catch (Exception ex)
            {
                return Json(ex);
            }


        }


        [HttpPost("Patient/{id}")]
        public async Task<IActionResult> PostPatient( 
            [FromBody]
            [Bind("FirstName", "LastName", "DateOfBirth", "FacilityId")] Application.Patient.PatientDTO patient )
        {
           try
            {
               await _patientService.CreatePatient(patient);
                return Json(patient);
            } 
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        [HttpPut("Patient/{id}")]
        public async Task<IActionResult> PutPatient( 
            [FromBody]
            [Bind("Id", "FirstName", "LastName", "DateOfBirth", "FacilityId")] Application.Patient.PatientDTO patient )
        {
            try
            {
                await _patientService.UpdatePatient(patient);
                return Json(patient);
            }
            catch (Exception ex) 
            {
                return Json(ex);
            }
            
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePatient( int? id )
        {

            try
            {
               await _patientService.DeletePatient((int)id);
                return Json((int)id); 
            }
            catch (Exception ex) {
                return Json(ex);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var model = await _facilityService.GetAll();
                return Json(model);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }



    }
}
