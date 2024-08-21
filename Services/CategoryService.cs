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
       
    }
}
