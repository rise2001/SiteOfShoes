using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SiteOfShoes.Models.Accounting; // пространство имен моделей RegisterModel и LoginModel
using SiteOfShoes.Entities.Accounting; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Arch.EntityFrameworkCore.UnitOfWork;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SiteOfShoes.Entities.Ordering;
using SiteOfShoes.Entities.Products;

namespace SiteOfShoes.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _unitOfWork.GetRepository<User>().GetAll()
                    .Where(user => user.Email == User.Identity.Name).FirstOrDefault();


                var orders = _unitOfWork.GetRepository<Order>().GetAll()
                   .Where(order => order.UserId == user.ID).OrderByDescending(t => t.OrderDate).ToList();
                foreach(var order in orders)
                {
                    foreach (var orderItem in order.OrderItems)
                        orderItem.Product = _unitOfWork.GetRepository<Product>().Find(orderItem.ProductId);
                }
                ViewBag.Orders = orders;

                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)//
            {
                User user = _unitOfWork.GetRepository<User>().GetAll().Include(u => u.Role)
                    .Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    await Authenticate(user); // аутентификация
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var users = _unitOfWork.GetRepository<User>();
                User user = users.GetAll()
                    .Where(u => u.Email == model.Email).FirstOrDefault();
                if (user == null)
                {
                    user = new User { Email = model.Email, Password = model.Password, Name = model.Name, RoleId = 2 };
                    Role userRole = _unitOfWork.GetRepository<Role>().GetAll()
                        .Where(r => r.Name == "User").FirstOrDefault();
                    if (userRole != null)
                        user.Role = userRole;
                    // добавляем пользователя в бд
                    users.Insert(user);
                    await _unitOfWork.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}