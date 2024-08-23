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
                // Fetch categories and their products from the database
                var categories = _context.Categories.Include(c => c.Products).ToList();

                // Map to DTO
                var categoriesWithProducts = categories.SelectMany(c =>
                {
                    // Create a list to hold both categories and their products
                    var list = new List<CategoriesWithProductsDTO>();

                    // Add the category itself (as a parent)
                    list.Add(new CategoriesWithProductsDTO
                    {
                        CategoryName = c.CategoryName,
                        ProductID = 0, // Default value to indicate it's a category, not a product
                        ProductName = null,
                        Price = 0,
                        QuantityAvailable = 0,
                        ParentID = 0 // No parent for the category itself
                    });

                    // Add each product within the category
                    list.AddRange(c.Products.Select(p => new CategoriesWithProductsDTO
                    {
                        CategoryName = null, // Not applicable for products
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        QuantityAvailable = p.QuantityAvailable,
                        ParentID = c.CategoryID // Link product to its category
                    }));

                    return list;
                }).ToList();

                return categoriesWithProducts;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new ApplicationException("Error retrieving categories with products", ex);
            }
        }

    }
}
