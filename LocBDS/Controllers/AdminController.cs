using LocBDS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocBDS.Controllers
{
    public class AdminController : Controller
    {
        private readonly RealEstateContext _context;
        public AdminController(RealEstateContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(RealEstate entity)
        {
            if(entity is not null)
            {
                _context.Add(entity);
                _context.SaveChanges();
                return Redirect("/HomeController/Index");
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(RealEstate entity)
        {
            var model = _context.RealEstates.FirstOrDefault(p => p.Id == entity.Id);
            
            if (model is not null)
            {
                model.Price = entity.Price;
                model.Title = entity.Title;
                model.Area = entity.Area;
                model.Description = entity.Description;
                model.UpdatedDt = entity.UpdatedDt;
                model.CreatedDt = entity.CreatedDt;
                model.TypeId = entity.TypeId;
                _context.Update(model);
                _context.SaveChanges();
                return Redirect("/HomeController/Index");
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _context.RealEstates.FirstOrDefault(p => p.Id == id);

            if (model is not null)
            {
                _context.Remove(model);
                _context.SaveChanges();
                return Redirect("/HomeController/Index");
            }
            return View();
        }
    }
}
