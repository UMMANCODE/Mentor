using MentorInClass.DAL;
using MentorInClass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorInClass.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _context;

        public PricingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PricingVM pricingVM = new PricingVM
            {
                Pricings = _context.Pricings.Include(x => x.Features).ToList(),
                Features = _context.Features.Include(x => x.Pricings).ToList()
            };

            return View(pricingVM);
        }
    }
}
