using EFDataAccessLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        Product? GetProductBySlug(string slug);
        bool UpdateProduct(int productId, int requestedQuantity);
    }
}
