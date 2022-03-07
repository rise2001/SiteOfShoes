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
    public class CatalogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatalogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShoeTypes()
        {
            var types = _unitOfWork.GetRepository<TypeOfShoe>().GetAll();
            return View(types);
        }
        public IActionResult Catalog()
        {
            var items = _unitOfWork.GetRepository<Product>().GetAll()
                .Where(u => u.IsDeleted == false);
            return View(items);
        }

        public IActionResult ShoeCatalog(string type)
        {
            var items = _unitOfWork.GetRepository<TypeOfShoe>().GetAll()
                .Where(u => u.Name == type).FirstOrDefault();
            return View(items);
        }
    }
}
