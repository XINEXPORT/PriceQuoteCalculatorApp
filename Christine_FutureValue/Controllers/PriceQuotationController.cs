using Microsoft.AspNetCore.Mvc;
using PriceQuotation.Models;

namespace PriceQuotation.Controllers
{
    public class PriceQuotationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PriceQuotationModel());
        }

        [HttpPost]
        public IActionResult Index(PriceQuotationModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }
    }}
