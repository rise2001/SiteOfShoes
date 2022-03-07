using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteOfShoes.Entities.Products.Shoes;
using SiteOfShoes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SiteOfShoes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Actions = _unitOfWork.GetRepository<Shoe>().GetAll()
                .Where(u => u.IsDeleted == false && u.isSaled).AsEnumerable()
                .OrderByDescending(u => u.SalePercent).Take(5);
            ViewBag.Sneakers = _unitOfWork.GetRepository<Shoe>().GetAll()
                .Where(u => u.IsDeleted == false && u.TypeOfShoe.Name == "Кроссовки").AsEnumerable()
                .OrderByDescending(u => u.Costs[u.Costs.Count - 1].Cost).Take(5);
            ViewBag.Boots = _unitOfWork.GetRepository<Shoe>().GetAll()
                .Where(u => u.IsDeleted == false && u.TypeOfSeasonId == 1).AsEnumerable()
                .OrderByDescending(u => u.Costs[u.Costs.Count - 1].Cost).Take(5);
            ViewBag.Slances = _unitOfWork.GetRepository<Shoe>().GetAll().AsEnumerable()
                .Where(u => u.IsDeleted == false && u.TypeOfShoe.Name == "Сланцы")
                .OrderByDescending(u => u.Costs[u.Costs.Count - 1].Cost).Take(5);
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
