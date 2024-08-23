using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.DTO
{
    public  class CategoriesWithProductsDTO
    {
        public string CategoryName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int QuantityAvailable { get; set; }
        public int ParentID { get; set; }


    }
}
