using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagment.DTO;
using ProductManagment.Models;

namespace ProductManagment.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        List<ProductDTO> GetProductsByCategory(int categoryId);
    }
}
