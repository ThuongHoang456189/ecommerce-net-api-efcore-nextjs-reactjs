using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.DTOs;
using EFDataAccessLibrary.Models;

namespace AmazonaAPI.Services
{
    public class OrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _repository;
        public OrderService(IProductRepository productRepository, IOrderRepository repository)
        {
            _productRepository = productRepository;
            _repository = repository;
        }
        public Order SaveOrder(OrderInfo orderInfo)
        {
            try
            {
                for (int i = 0; i < orderInfo.orderItems.Count; i++)
                {
                    if (!_productRepository.UpdateProduct(orderInfo.orderItems[i]._id, orderInfo.orderItems[i].quantity))
                        return null;
                }
                return _repository.SaveOrder(orderInfo);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
