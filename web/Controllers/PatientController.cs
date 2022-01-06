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

        public IActionResult Index()
        {
            return View();
        }

  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet("patient/{id}")]
        async public Task<IActionResult> GetPatient( int? id )
        {
            if (id == null)
                return NotFound();
            else
            {
                var model = await _context.Patient.FindAsync(id);
                return View(model);
            }
        
        }


        [HttpGet]
        public async Task<IActionResult> GetPatient( int page, int pageSize )
        {
            var model = await _context.Patient
                    .Skip(page * pageSize)
                    .Except(_context.Patient.Skip((page * pageSize) + pageSize))
                    .Include(e => e.Facility)
                    .ToListAsync();

            return View( model );
        }


        [HttpPost("patient/{id}")]
        public IActionResult PostPatient( [FromBody][Bind("FirstName", "LastName", "DateOfBirth", "FacilityId")] Domain.Entities.Patient patient )
        {
           try {
                _patientService.CreatePatient(patient);
            } catch (Exception ex) {
                return View(ex.Message);
            }
            return View();
        }



        [HttpPut("patient/{id}")]
        public IActionResult PutPatient( [FromBody][Bind("Id", "FirstName", "LastName", "DateOfBirth", "FacilityId")] Domain.Entities.Patient patient )
        {
            try {
                _patientService.UpdatePatient(patient);
            }
            catch (Exception ex) {
                return View(ex.Message);
            }
            
            return View( );
        }



        [HttpDelete("patient/{id}")]
        public IActionResult DeletePatient( [FromQuery]int? id )
        {
            if (id == null)
                return NotFound();

            try
            {
                _patientService.DeletePatient((int)id);
            }
            catch (Exception ex) {
                return View(ex.Message);
            }

            
            return View(  );
        }

    }
}
