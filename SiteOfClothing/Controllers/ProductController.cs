using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteOfShoes.Entities.Accounting;
using SiteOfShoes.Entities.Products.Shoes;
using SiteOfShoes.Entities.ProductTypes.Shoes;
using System.Linq;
using SiteOfShoes.EF;
using SiteOfShoes.Models.Products;
using System.Collections.Generic;
using SiteOfShoes.Entities.Products;
using SiteOfShoes.EF;

namespace SiteOfShoes.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product(int id)
        {
            var item = _unitOfWork.GetRepository<Product>().Find(id);
            if (item is Shoe)
            {
                return RedirectToAction("Shoe", new { id = id });
            }
            return View("404");
        }


        public IActionResult Shoe(int id)
        {
            var shoe = _unitOfWork.GetRepository<Shoe>().Find(id);
            return View(shoe);
        }

    }
}
