using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using SiteOfShoes.Entities.Ordering.Cart;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {

        private readonly ILogger<CartItemController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public CartItemController(ILogger<CartItemController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<CartItem> Get()
        {
            return _unitOfWork.GetRepository<CartItem>().GetAll().ToArray();
        }

        [HttpPost("{id}")]
        public string Delete(int id)
        {
            _unitOfWork.GetRepository<CartItem>().Delete(id);
            _unitOfWork.SaveChanges();
            return "success";
        }

        [HttpGet("{cartId}/{sizeId}")]
        public string ChangeSize(int cartId, int sizeId)
        {
            var cartItem = _unitOfWork.GetRepository<CartItem>().Find(cartId);
            cartItem.SizeOfProductId = sizeId;
            _unitOfWork.GetRepository<CartItem>().Update(cartItem);
            _unitOfWork.SaveChanges();
            return "success";
        }

    }
}
