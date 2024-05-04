using MentorInClass.DAL;
using MentorInClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorInClass.Areas.Admin.Controllers {
	[Area("Admin")]
	public class PricingController : Controller {
		private readonly AppDbContext _context;

		public PricingController(AppDbContext context) {
			_context = context;
		}



		public IActionResult Index() {
			var pricings = _context.Pricings.Include(x => x.Features).ToList();
			return View(pricings);
		}

		public IActionResult Create() {
			ViewBag.Features = _context.Features.ToList();
			return View();
		}

		[HttpPost]
		public IActionResult Create(Pricing pricing) {
			if (_context.Pricings.Any(x => x.Title == pricing.Title)) {
				ModelState.AddModelError("Title", "This title already exists");
				return View(pricing);
			}

			if (pricing.FeatureIds != null) {
				foreach (var featureId in pricing.FeatureIds) {
					pricing.Features.Add(new PricingFeature {
						FeatureId = featureId,
						Pricing = pricing,
					});
				}
			}

			if (ModelState.IsValid) {
				_context.Pricings.Add(pricing);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.Features = _context.Features.ToList();
			return View(pricing);
		}


		public IActionResult Edit(int id) {
			var pricing = _context.Pricings.Include(x => x.Features).FirstOrDefault(x => x.Id == id);
			if (pricing == null) {
				return NotFound();
			}
			ViewBag.Features = _context.Features.ToList();
			return View(pricing);
		}

		[HttpPost]
		public IActionResult Edit(Pricing pricing) {
			Pricing? existPricing = _context.Pricings.Include(x => x.Features).FirstOrDefault(x => x.Id == pricing.Id);

			if (existPricing is null) return NotFound();

			if (_context.Pricings.Any(x => x.Title == pricing.Title && x.Id != pricing.Id)) {
				ModelState.AddModelError("Title", "This title already exists");
				ViewBag.Features = _context.Features.ToList();
				return View(pricing);
			}

			existPricing.Features.RemoveAll(x => !pricing.FeatureIds.Contains(x.FeatureId));

			foreach (var featureId in pricing.FeatureIds.FindAll(x => !existPricing.Features.Any(bt => bt.FeatureId == x))) {
				if (!_context.Features.Any(x => x.Id == featureId)) return RedirectToAction("notfound", "error");

				PricingFeature pricingFeature = new() {
					FeatureId = featureId,
				};
				existPricing.Features.Add(pricingFeature);
			}


			if (ModelState.IsValid) {
				_context.Pricings.Update(pricing);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.Features = _context.Features.ToList();
			return View(pricing);
		}

		public IActionResult Delete(int id) {
			var pricing = _context.Pricings.Find(id);
			if (pricing == null) {
				return NotFound();
			}
			_context.Pricings.Remove(pricing);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
