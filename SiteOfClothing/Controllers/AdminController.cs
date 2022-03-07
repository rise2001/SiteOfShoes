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
using Microsoft.AspNetCore.Authorization;

namespace SiteOfShoes.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Entities()
        {
            return View();
        }


        #region Shoe
        [HttpGet]
        public IActionResult Shoe()
        {
            var shoes = ShoeModel.CreateShoeModels(_unitOfWork.GetRepository<Shoe>().GetAll());
            return View(shoes);
        }


        [HttpGet]
        public IActionResult AddShoe()
        {
            ViewBag.TypesOfSeason = _unitOfWork.GetRepository<TypeOfSeason>().GetAll();
            ViewBag.TypesOfSex = _unitOfWork.GetRepository<TypeOfSex>().GetAll();
            ViewBag.TypesOfDestination = _unitOfWork.GetRepository<TypeOfDestination>().GetAll();
            ViewBag.TypesOfShoe = _unitOfWork.GetRepository<TypeOfShoe>().GetAll();
            ViewBag.SizesOfShoe = _unitOfWork.GetRepository<SizeOfShoe>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddShoe(ShoeModel shoeModel)
        {
            var shoe = shoeModel.GetShoe(_unitOfWork);
            _unitOfWork.GetRepository<Shoe>().Insert(shoe);
            _unitOfWork.SaveChanges();
            _unitOfWork.GetRepository<CostOfProduct>().Insert(new CostOfProduct(shoe, shoeModel.Cost));
            _unitOfWork.SaveChanges();
            return RedirectToAction("Shoe");
        }

        [HttpGet]
        public IActionResult EditShoe(int id)
        {
            var shoe = _unitOfWork.GetRepository<Shoe>().Find(id);
            var model = new ShoeModel(shoe);
            ViewBag.TypesOfSeason = _unitOfWork.GetRepository<TypeOfSeason>().GetAll();
            ViewBag.TypesOfSex = _unitOfWork.GetRepository<TypeOfSex>().GetAll();
            ViewBag.TypesOfDestination = _unitOfWork.GetRepository<TypeOfDestination>().GetAll();
            ViewBag.TypesOfShoe = _unitOfWork.GetRepository<TypeOfShoe>().GetAll();
            ViewBag.SizesOfShoe = _unitOfWork.GetRepository<SizeOfShoe>().GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult EditShoe(ShoeModel shoeModel)
        {
            var shoeRepo = _unitOfWork.GetRepository<Shoe>();
            var shoe = shoeRepo.Find(shoeModel.Id);
            shoe.UpdateByShoeModel(shoeModel, _unitOfWork);
            if (shoe.Costs.Last().Cost != shoeModel.Cost)
            {
                var newCost = new CostOfProduct(shoe, shoeModel.Cost);
                _unitOfWork.GetRepository<CostOfProduct>().Insert(newCost);
                shoe.Costs.Add(newCost);
                _unitOfWork.SaveChanges();
            }

            shoeRepo.Update(shoe);
            _unitOfWork.SaveChanges();
            //_unitOfWork.GetRepository<CostOfProduct>().Insert(new CostOfProduct(shoe, shoeModel.Cost));
            //_unitOfWork.SaveChanges();
            return RedirectToAction("Shoe");
        }


        [HttpGet]
        public IActionResult DeleteShoe(int id)
        {
            var item = _unitOfWork.GetRepository<Shoe>().Find(id);
            _unitOfWork.GetRepository<Shoe>().Delete(item);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Shoe");
        }
        #endregion


        #region TypeOfShoe
        [HttpGet]
        public IActionResult TypeOfShoe()
        {
            var typesOfShoe = _unitOfWork.GetRepository<TypeOfShoe>().GetAll();
            return View(typesOfShoe);
        }

        [HttpGet]
        public IActionResult AddTypeOfShoe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTypeOfShoe(TypeOfShoe typeOfShoe)
        {
            _unitOfWork.GetRepository<TypeOfShoe>().Insert(typeOfShoe);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfShoe");
        }

        [HttpGet]
        public IActionResult EditTypeOfShoe(int id)
        {
            var type = _unitOfWork.GetRepository<TypeOfShoe>().GetAll()
                .Where(type => type.Id == id).FirstOrDefault();
            return View(type);
        }

        [HttpPost]
        public IActionResult EditTypeOfShoe(TypeOfShoe typeOfShoe)
        {
            _unitOfWork.GetRepository<TypeOfShoe>().Update(typeOfShoe);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfShoe");
        }

        [HttpGet]
        public IActionResult DeleteTypeOfShoe(int id)
        {
            var type = _unitOfWork.GetRepository<TypeOfShoe>().GetAll()
                .Where(type => type.Id == id).FirstOrDefault();
            _unitOfWork.GetRepository<TypeOfShoe>().Delete(type);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfShoe");
        }
        #endregion


        #region TypeOfDestination
        public IActionResult TypeOfDestination()
        {
            var typesOfDestination = _unitOfWork.GetRepository<TypeOfDestination>().GetAll();
            return View(typesOfDestination);
        }

        [HttpGet]
        public IActionResult AddTypeOfDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTypeOfDestination(TypeOfDestination typeOfDestination)
        {
            _unitOfWork.GetRepository<TypeOfDestination>().Insert(typeOfDestination);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfDestination");
        }

        [HttpGet]
        public IActionResult EditTypeOfDestination(int id)
        {
            var type = _unitOfWork.GetRepository<TypeOfDestination>().GetAll()
                .Where(type => type.Id == id).FirstOrDefault();
            return View(type);
        }

        [HttpPost]
        public IActionResult EditTypeOfDestination(TypeOfDestination typeOfDestination)
        {
            _unitOfWork.GetRepository<TypeOfDestination>().Update(typeOfDestination);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfDestination");
        }

        [HttpGet]
        public IActionResult DeleteTypeOfDestination(int id)
        {
            var type = _unitOfWork.GetRepository<TypeOfDestination>().GetAll()
                .Where(type => type.Id == id).FirstOrDefault();
            _unitOfWork.GetRepository<TypeOfDestination>().Delete(type);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfDestination");
        }
        #endregion


        #region Role
        public IActionResult Role()
        {
            var roles = _unitOfWork.GetRepository<Role>().GetAll();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            _unitOfWork.GetRepository<Role>().Insert(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }

        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var role = _unitOfWork.GetRepository<Role>().GetAll()
                .Where(role => role.ID == id).FirstOrDefault();
            return View(role);
        }

        [HttpPost]
        public IActionResult EditRole(Role role)
        {
            _unitOfWork.GetRepository<Role>().Update(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }

        [HttpGet]
        public IActionResult DeleteRole(int id)
        {
            var role = _unitOfWork.GetRepository<Role>().GetAll()
                .Where(role => role.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Role>().Delete(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }
        #endregion


        #region User
        [HttpGet]
        public IActionResult User()
        {
            var users = _unitOfWork.GetRepository<User>().GetAll();
            foreach (var user in users)
            {
                user.Role = _unitOfWork.GetRepository<Role>().GetAll().Where(role => role.ID == user.RoleId).FirstOrDefault();
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.Roles = _unitOfWork.GetRepository<Role>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _unitOfWork.GetRepository<User>().Insert(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            ViewBag.Roles = _unitOfWork.GetRepository<Role>().GetAll();
            var user = _unitOfWork.GetRepository<User>().GetAll().Where(user => user.ID == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            _unitOfWork.GetRepository<User>().Update(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var user = _unitOfWork.GetRepository<User>().GetAll().Where(user => user.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<User>().Delete(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }
        #endregion

    }
}
