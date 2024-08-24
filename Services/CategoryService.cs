using ProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagment.DTO;

namespace ProductManagment.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CategoryDTO> GetCategories()
        {
            var categories = _context.Categories.ToList();
            

            if (categories.Count < 1)
            {
                 
                throw new Exception("No categories found ");
            }

            var categoryDTOs = categories.Select(c => new CategoryDTO
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName
            }).ToList();

            return categoryDTOs;

        }

        public List<CategoriesWithProductsDTO> GetCategoriesWithProducts()
        {
            try
            {
                var categories = _context.Categories.Include(c => c.Products).ToList();

                var categoriesWithProducts = categories.SelectMany(c =>
                {
                    var list = new List<CategoriesWithProductsDTO>();

                    list.Add(new CategoriesWithProductsDTO
                    {
                        CategoryName = c.CategoryName,
                        ProductID = 0, 
                        ProductName = null,
                        Price = 0,
                        QuantityAvailable = 0,
                        ParentID = 0 
                    });

                    list.AddRange(c.Products.Select(p => new CategoriesWithProductsDTO
                    {
                        CategoryName = null, 
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        QuantityAvailable = p.QuantityAvailable,
                        ParentID = c.CategoryID 
                    }));

                    return list;
                }).ToList();

                return categoriesWithProducts;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving categories with products", ex);
            }
        }

    }
}
