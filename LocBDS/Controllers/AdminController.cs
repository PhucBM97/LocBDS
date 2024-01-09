using HoangLocRealEstate.ViewModels;
using LocBDS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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
        public IActionResult Index(int? page)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            var model = _context.RealEstates.Include(p => p.Category)
                                          .Select(p => new RealEstateVM
                                          {
                                              Id = p.Id,
                                              Title = p.Title,
                                              Price = p.Price,
                                              Area = p.Area,
                                              Description = p.Description,
                                              CategoryId = p.CategoryId,
                                              TypeName = p.Category.CategoryName,
                                              CreatedDt = p.CreatedDt,
                                              UpdatedDt = p.UpdatedDt,
                                              Photo = p.Photo,
                                              Address = p.Address
                                          })
                                          .OrderByDescending(p => p.CreatedDt)
                                          .ToList();

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public IActionResult Add()
        {
            ViewData["Categories"] = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(RealEstate entity)
        {
            if (!string.IsNullOrEmpty(entity.Photo))
            {
                var base64 = entity.Photo.Split(",");
                entity.Photo = base64[1];
            }
            if(entity.CategoryId != 0 && entity.CategoryId != null)
            {
                entity.CreatedDt = DateTime.Now;
                _context.RealEstates.Add(entity);
                _context.SaveChanges();
                return RedirectToAction("Index");
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
                model.CategoryId = entity.CategoryId;
                model.Photo = entity.Photo;
                model.Address = entity.Address;
                _context.RealEstates.Update(model);
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
                _context.RealEstates.Remove(model);
                _context.SaveChanges();
                return Redirect("/HomeController/Index");
            }
            return View();
        }
    }
}
