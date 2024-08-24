using ProductManagment.Services;
using ProductManagment.Models;
using ProductManagment.DTO;
namespace ProductManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadCategories()
        {
            try
            {
                var categories = _categoryService.GetCategories();
                categories.Insert(0, new CategoryDTO { CategoryID = 0, CategoryName = "Choose" });
                comboBox1.DataSource = categories;
                comboBox1.DisplayMember = "CategoryName";
                comboBox1.ValueMember = "CategoryID";
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }
        private void LoadParentChildTreeList()
        {
            var categoriesWithProducts = _categoryService.GetCategoriesWithProducts();

            ConstructTreeList2();

            treeList2.BeginUpdate();
            treeList2.DataSource = categoriesWithProducts;
            treeList2.EndUpdate();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int categoryId && categoryId != 0)
            {
                LoadProducts(categoryId);
            }
        }
        private void ConstructTreeList2()
        {
            treeList2.Columns.Clear();
            treeList2.ParentFieldName = "CategoryID";
            treeList2.KeyFieldName = "ProductID";

            var colCategoryName = new DevExpress.XtraTreeList.Columns.TreeListColumn
            {
                FieldName = "CategoryName",
                Caption = "Category Name",
                VisibleIndex = 0
            };

            var colProductName = new DevExpress.XtraTreeList.Columns.TreeListColumn
            {
                FieldName = "ProductName",
                Caption = "Product Name",
                VisibleIndex = 1
            };

            var colPrice = new DevExpress.XtraTreeList.Columns.TreeListColumn
            {
                FieldName = "Price",
                Caption = "Price",
                VisibleIndex = 2
            };

            var colQuantityAvailable = new DevExpress.XtraTreeList.Columns.TreeListColumn
            {
                FieldName = "QuantityAvailable",
                Caption = "Quantity Available",
                VisibleIndex = 3
            };

            treeList2.Columns.AddRange(new[]
            {
                colCategoryName,
                colProductName,
                colPrice,
                colQuantityAvailable
            });
        }
        private void LoadProducts(int categoryId)
        {
            try
            {

                var products = _productService.GetProductsByCategory(categoryId);

                treeList1.BeginUpdate();
                treeList1.Columns.Clear();
                treeList1.DataSource = products;
                treeList1.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeList1.Nodes.Count > 0)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save an Excel File";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            treeList1.ExportToXlsx(saveFileDialog.FileName);
                            MessageBox.Show("Export successful!", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is no data to export.", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There is An error occurred during export: {ex.Message}", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
