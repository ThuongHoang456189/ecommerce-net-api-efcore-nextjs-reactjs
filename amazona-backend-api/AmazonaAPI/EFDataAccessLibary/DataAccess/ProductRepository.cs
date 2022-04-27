using EFDataAccessLibary.DataAccess;
using EFDataAccessLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly AmazonaContext _context;
        public ProductRepository(AmazonaContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.products.ToList();
        }
        public Product? GetProductById(int id)
        {
            return _context.products.FirstOrDefault<Product>(x => x._id == id);
        }
        public Product? GetProductBySlug(string slug)
        {
            return _context.products.FirstOrDefault<Product>(x => x.slug.Equals(slug));
        }

        public bool UpdateProduct(int productId, int requestedQuantity)
        {
            try
            {
                var found = _context.products.FirstOrDefault(x => x._id == productId);
                int updatingCountInStock = found.countInStock - requestedQuantity;
                if (updatingCountInStock >= 0)
                {
                    found.countInStock = updatingCountInStock;
                    _context.SaveChanges();
                    return true;
                }
            }catch (Exception ex)
            {
            }
            return false;
        }
    }
}
