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
        private readonly ILogger<PatientController> _logger;

        private readonly Application.Patient.PatientService _patientService;
        private readonly Infrastructure.ApplicationContext _context;

        public PatientController(
            ILogger<PatientController> logger,
            Infrastructure.ApplicationContext context
            )
        {
            _context = context;
            _patientService = new Application.Patient.PatientService(context);
            _logger = logger;
        }

        public IActionResult Index() => Json("Main Patient Page Index Action");
  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet("Patient/{id:int}")]
        async public Task<IActionResult> GetPatient( int id )
        {
            if (id == null)
                return NotFound();
            else
            {
                var model = await _context.Patient.FindAsync(id);
                return Json(model);
            }
        
        }


        [HttpGet]
        public async Task<IActionResult> GetPatient( int page, int pageSize )
        {
            try
            {
                var model = await _context.Patient
                    .Skip(page * pageSize)
                    .Except(_context.Patient.Skip((page * pageSize) + pageSize))
                    .Include(e => e.Facility)
                    .ToListAsync();

                return Json(model);

            } catch (Exception ex)
            {
                return Json(ex.Message);
            }


        }


        [HttpPost("Patient/{id}")]
        public IActionResult PostPatient( [FromBody][Bind("FirstName", "LastName", "DateOfBirth", "FacilityId")] Domain.Entities.Patient patient )
        {
           try
            {
                _patientService.CreatePatient(patient);
            } 
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json( true );
        }


        [HttpPut("Patient/{id}")]
        public IActionResult PutPatient( [FromBody][Bind("Id", "FirstName", "LastName", "DateOfBirth", "FacilityId")] Domain.Entities.Patient patient )
        {
            try
            {
                _patientService.UpdatePatient(patient);
            }
            catch (Exception ex) 
            {
                return Json(ex.Message);
            }
            
            return Json( true );
        }


        [HttpDelete]
        public IActionResult DeletePatient( int? id )
        {
            if (id == null)
                return NotFound();

            try
            {
                _patientService.DeletePatient((int)id);
            }
            catch (Exception ex) {
                return Json(ex.Message);
            }

            
            return Json( true  );
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var model = await _context.Facility.ToListAsync();
                return Json(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetCountOfPages(int perPage)
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
                _context.Database.ExecuteSqlRaw("GetCountOfPatient @count OUT", param);


                listCount = (int)param.Value;
            }

            if (listCount == 0)
                return Json(listCount);

            return Json(listCount % perPage == 0
        ? (listCount / perPage) - 1
        : listCount / perPage);
        }


    }
}
