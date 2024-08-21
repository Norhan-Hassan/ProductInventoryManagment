using ProductManagment.DTO;
using ProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            var products = _context.Products.ToList();

            if (products.Count <1)
            {
                throw new Exception("No products found ");
            }

            return products;
        }
        public List<ProductDTO> GetProductsByCategory(int categoryId)
        {
            var products = _context.Products.Where(p => p.CategoryID == categoryId).ToList();
        
              var productDTOs = products.Select(p => new ProductDTO
              {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    QuantityAvailable= p.QuantityAvailable,

              }).ToList();
            return productDTOs;
        }

       

    }
}
