using AmazonaAPI.Services;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.DTOs;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AmazonaAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route(template: "orders")]
    public class OrderController : Controller
    {
        private readonly OrderService _service;
        private readonly IOrderRepository _repository;
        private readonly IProductRepository _productRepository;
        public OrderController(IProductRepository productRepository, IOrderRepository repository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _service = new OrderService(_productRepository, _repository);
        }
        [HttpPost(template: "")]
        public IActionResult SaveOrder(OrderInfo orderInfo)
        {
            Order order = _service.SaveOrder(orderInfo);
            if (order == null)
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong!");
            }
            return Ok(order);
        }
        [HttpGet(template: "{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            return Ok(_repository.GetOrder(orderId));
        }
        [HttpGet(template: "history")]
        public IActionResult GetHistory()
        {
            string authHeader = Request.Headers["authorization"];

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                string encodedToken = authHeader.Substring("Bearer ".Length);
                // Encoding encoding = Encoding.UTF8;
                // context.Token = encoding.GetString(Convert.FromBase64String(encodedToken));
                var handler = new JwtSecurityTokenHandler();
                var decodedValue = handler.ReadJwtToken(encodedToken);
                int userId = int.Parse(decodedValue.Claims.First().Value);

                return Ok(_repository.GetAllOrdersOfUser(userId));            }
            return NotFound();
        }
    }
}
