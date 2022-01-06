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


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Facility/{id}")]
        public async Task<IActionResult> GetFacility( int? id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetFacility( int page, int pageSize)
        {
            return View();
        }


        [HttpPost("Facility/{id}")]
        public async Task<IActionResult> PostFacility([FromBody][Bind("")] Domain.Entities.Facility facility )
        {

            try
            {
                _facilityService.CreateFacility( facility );
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return  View();

        }


        [HttpPut("Facility/{id}")]
        public async Task<IActionResult> PutFacility([FromBody][Bind("")] Domain.Entities.Facility facility)
        {
            try
            {
                _facilityService.UpdateFacility( facility );
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return View();
        }


        [HttpDelete("Facility/{id}")]
        public async Task<IActionResult> DeleteFacility( int? id )
        {
            if (id == null)
                return NotFound();


            try
            {
                _facilityService.DeleteFacility((int)id);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return View();
        }

    }
}
