using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    public class FacilityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
