using ProductManagment.DTO;
using ProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductManagment.Services
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetCategories();
        List<CategoriesWithProductsDTO> GetCategoriesWithProducts();
    }
}
