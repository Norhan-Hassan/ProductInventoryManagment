using ProductManagment.Services;
using ProductManagment.Models;
using ProductManagment.DTO;
using DevExpress.XtraLayout;
using System.ComponentModel;
namespace ProductManagment
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ICategoryService _categoryService;
        private IProductService _productService;


        public Form1(ICategoryService categoryService, IProductService productService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _productService = productService;
            Load += Form1_Load;
        }


        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int categoryId && categoryId != 0)
            {
                LoadProducts(categoryId);
            }
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

        #region Windows Form Designer generated code

        /// <summary>

        private void InitializeComponent()
        {
            layoutControl1 = new LayoutControl();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            comboBox1 = new ComboBox();
            btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            Root = new LayoutControlGroup();
            layoutControlItem1 = new LayoutControlItem();
            emptySpaceItem1 = new EmptySpaceItem();
            layoutControlItem2 = new LayoutControlItem();
            layoutControlItem3 = new LayoutControlItem();
            ((ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((ISupportInitialize)treeList1).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)layoutControlItem1).BeginInit();
            ((ISupportInitialize)emptySpaceItem1).BeginInit();
            ((ISupportInitialize)layoutControlItem2).BeginInit();
            ((ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(treeList1);
            layoutControl1.Controls.Add(comboBox1);
            layoutControl1.Controls.Add(btnExportToExcel);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1307, 650);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // treeList1
            // 
            treeList1.Location = new Point(12, 42);
            treeList1.Name = "treeList1";
            treeList1.Size = new Size(1283, 565);
            treeList1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ScrollBar;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "select category" });
            comboBox1.Location = new Point(114, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(1181, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnExportToExcel
            // 
            btnExportToExcel.Location = new Point(12, 611);
            btnExportToExcel.Name = "btnExportToExcel";
            btnExportToExcel.Size = new Size(152, 27);
            btnExportToExcel.StyleController = layoutControl1;
            btnExportToExcel.TabIndex = 6;
            btnExportToExcel.Text = "Export to Excel";
            btnExportToExcel.Click += btnExportToExcel_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new BaseLayoutItem[] { layoutControlItem1, emptySpaceItem1, layoutControlItem2, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new Size(1307, 650);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = comboBox1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(1287, 30);
            layoutControlItem1.Text = "Select Category";
            layoutControlItem1.TextSize = new Size(90, 16);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(156, 599);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(1131, 31);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = treeList1;
            layoutControlItem2.Location = new Point(0, 30);
            layoutControlItem2.MinSize = new Size(104, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(1287, 569);
            layoutControlItem2.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnExportToExcel;
            layoutControlItem3.Location = new Point(0, 599);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(156, 31);
            layoutControlItem3.TextSize = new Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 650);
            Controls.Add(layoutControl1);
            Name = "Form1";
            Text = "Product Management";
            ((ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((ISupportInitialize)treeList1).EndInit();
            ((ISupportInitialize)Root).EndInit();
            ((ISupportInitialize)layoutControlItem1).EndInit();
            ((ISupportInitialize)emptySpaceItem1).EndInit();
            ((ISupportInitialize)layoutControlItem2).EndInit();
            ((ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
        }


        #endregion
        private Label label1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private ComboBox comboBox1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Button button1;
        private LayoutControlItem layoutControlItem4;
    }

    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    /// 
}