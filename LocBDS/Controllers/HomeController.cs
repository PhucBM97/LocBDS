using HoangLocRealEstate.ViewModels;
using LocBDS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace LocBDS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RealEstateContext _context;

        public HomeController(ILogger<HomeController> logger, RealEstateContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index(int? page)
        {
            int pageSize = 6;
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

        [AllowAnonymous]
        public IActionResult GetDetail(int id)
        {
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
                      Address= p.Address
                  })
                  .FirstOrDefault(p => p.Id == id);

            if (model is not null)
            {
                return View(model);
            }
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
    }
}
