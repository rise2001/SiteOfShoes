using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteOfShoes.Entities.Accounting;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using SiteOfShoes.Entities.Products.Shoes;
using SiteOfShoes.Entities.Ordering.Cart;
using SiteOfShoes.Entities.ProductTypes.Shoes;
using SiteOfShoes.Entities.Ordering;
using SiteOfShoes.Entities.Products;

namespace WebUI.Controllers
{
    [Authorize]
    public class OrderingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region Orders
        [HttpGet]
        public ActionResult AddOrder()
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var orderRepo = _unitOfWork.GetRepository<Order>();
            var orderItemsRepo = _unitOfWork.GetRepository<OrderItem>();
            var productRepo = _unitOfWork.GetRepository<Product>();
            var cart = _unitOfWork.GetRepository<Cart>().GetAll().AsEnumerable()
                .Where(c => c.User.ID == currentUser.ID).FirstOrDefault();
            var order = new Order() { User = currentUser, UserId = currentUser.ID, Cost = cart.GetSum() };

            foreach (var cartItem in cart.CartItems)
            {
                var product = (Product)cartItem.Product;
                var orderItem = new OrderItem() { Order = order, Product = product, Cost = product.Costs[product.Costs.Count-1].Cost, SizeOfProductId = cartItem.SizeOfProductId};
                order.OrderItems.Add(orderItem);
            }
            order.OrderStatus = _unitOfWork.GetRepository<OrderStatus>().Find(1);
            orderRepo.Insert(order);
            _unitOfWork.SaveChanges();
            ClearCart();
            return View("Thanks");
        }
        #endregion

        #region Cart
        [HttpGet]
        public ActionResult Cart()
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var repo = _unitOfWork.GetRepository<Cart>().GetAll().ToList();
            Cart cart;
            if (repo.Where(t => t.User.ID == currentUser.ID).ToList().Count > 0) {
                cart = repo.Where(c => c.User.ID == currentUser.ID).FirstOrDefault();
                cart.CartItems = _unitOfWork.GetRepository<CartItem>().GetAll()
                    .Where(u => u.Cart.Id == cart.Id).ToList();
            }
            else{ 
                cart = new Cart(currentUser);
                _unitOfWork.GetRepository<Cart>().Insert(cart);
                _unitOfWork.SaveChanges();
            }
            return View(cart);
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var shoe = _unitOfWork.GetRepository<Shoe>().Find(id);
            var repo = _unitOfWork.GetRepository<Cart>().GetAll().AsEnumerable();
            Cart cart;
            if (repo.Any(c => c.User.ID == currentUser.ID))
            {
                cart = repo.Where(c => c.User.ID == currentUser.ID).FirstOrDefault();
            }
            else
            {
                cart = new Cart(currentUser);
                _unitOfWork.GetRepository<Cart>().Insert(cart);
                _unitOfWork.SaveChanges();
            }
            cart.AddCartItem(shoe);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }


        [HttpGet]
        public ActionResult RemoveCartProduct(int cartItemId)
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var cart = _unitOfWork.GetRepository<Cart>().GetAll().Where(t => t.User.ID == currentUser.ID).FirstOrDefault();
            var cartItem = _unitOfWork.GetRepository<CartItem>().Find(cartItemId);
            cart.CartItems.Remove(cartItem);
            _unitOfWork.GetRepository<Cart>().Update(cart);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public ActionResult ClearCart()
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var cart = _unitOfWork.GetRepository<Cart>().GetAll().Where(t => t.User.ID == currentUser.ID).FirstOrDefault();
            cart.CartItems.Clear();
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }
        #endregion

    }
}
