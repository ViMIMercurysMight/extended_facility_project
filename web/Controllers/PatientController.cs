using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Controllers
{
    public class PatientController : Controller
    {
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet("patient/{id}")]
        public IActionResult GetPatient( int? id )
        {

            if (id == null)
                return NotFound();

            var model = 1;

            return View( model );
        }


        [HttpGet]
        public IActionResult GetPatient( int page, int pageSize )
        {

            var model = 1;

            return View( model );
        }


        [HttpPost("patient/{id}")]
        public IActionResult PostPatient( int? id )
        {
            if (id == null)
                return NotFound();

            var model = 1;

            return View( model );
        }
        

        [HttpPut("patient/{id}")]
        public IActionResult PutPatient( int? id )
        {
            if (id == null)
                return NotFound();

            var model = 1;

            return View( model );
        }

        [HttpDelete("patient/{id}")]
        public IActionResult DeletePatient( int? id )
        {
            if (id == null)
                return NotFound();

            var model = 1;


            return View( model );
        }

    }
}
