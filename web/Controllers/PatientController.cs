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
                return Json(await _patientService.GetPatient(id));

            } catch(Exception ex)
            {
                return Json(ex.Message);
            }



        }


        [HttpGet]
        public async Task<IActionResult> GetPatient( int page, int pageSize )
        {
            try
            {
                return Json(await _patientService.GetPage(page, pageSize));

            } catch (Exception ex)
            {
                return Json(ex.Message);
            }


        }


        [HttpPost("Patient/{id}")]
        public async Task<IActionResult> PostPatient( 
            [FromBody]
            [Bind("FirstName", "LastName", "DateOfBirth", "FacilityId")] Application.Patient.PatientDTO patient )
        {
           try
            {
                return Json(await _patientService.CreatePatient(patient));
            } 
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpPut("Patient/{id}")]
        public async Task<IActionResult> PutPatient( 
            [FromBody]
            [Bind("Id", "FirstName", "LastName", "DateOfBirth", "FacilityId")] Application.Patient.PatientDTO patient )
        {
            try
            {
                return Json(await _patientService.UpdatePatient(patient));
            }
            catch (Exception ex) 
            {
                return Json(ex.Message);
            }
            
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePatient( int? id )
        {

            try
            {
                return Json(await _patientService.DeletePatient((int)id)); 
            }
            catch (Exception ex) {
                return Json(ex.Message);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            try
            {;
                return Json(await _facilityService.GetAll());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }



    }
}
