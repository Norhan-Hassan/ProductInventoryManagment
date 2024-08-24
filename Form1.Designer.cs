using ProductManagment.Services;
using ProductManagment.Models;
using ProductManagment.DTO;
using DevExpress.XtraLayout;
using System.ComponentModel;
using DevExpress.XtraTreeList;
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
            LoadParentChildTreeList();
        }

       

        #region Windows Form Designer generated code

        /// <summary>

        private void InitializeComponent()
        {
            layoutControl1 = new LayoutControl();
            treeList1 = new TreeList();
            comboBox1 = new ComboBox();
            btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            Root = new LayoutControlGroup();
            layoutControlItem1 = new LayoutControlItem();
            emptySpaceItem1 = new EmptySpaceItem();
            layoutControlItem2 = new LayoutControlItem();
            layoutControlItem3 = new LayoutControlItem();
            treeList2 = new TreeList();
            layoutControlItem4 = new LayoutControlItem();
            ((ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((ISupportInitialize)treeList1).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)layoutControlItem1).BeginInit();
            ((ISupportInitialize)emptySpaceItem1).BeginInit();
            ((ISupportInitialize)layoutControlItem2).BeginInit();
            ((ISupportInitialize)layoutControlItem3).BeginInit();
            ((ISupportInitialize)treeList2).BeginInit();
            ((ISupportInitialize)layoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(treeList2);
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
            treeList1.Size = new Size(646, 565);
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
            btnExportToExcel.Location = new Point(12, 603);  
            btnExportToExcel.Name = "btnExportToExcel";
            btnExportToExcel.Size = new Size(10, 3); 
            btnExportToExcel.StyleController = layoutControl1;
            btnExportToExcel.TabIndex = 6;
            btnExportToExcel.Text = "Export to Excel";
            btnExportToExcel.Click += btnExportToExcel_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new BaseLayoutItem[] { layoutControlItem1, emptySpaceItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
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
            emptySpaceItem1.Location = new Point(650, 580);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(637, 50);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = treeList1;
            layoutControlItem2.Location = new Point(0, 30);
            layoutControlItem2.MinSize = new Size(104, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(650, 569);
            layoutControlItem2.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnExportToExcel;
            layoutControlItem3.Location = new Point(0, 591); 
            layoutControlItem3.MinSize = new Size(10,3);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(10,3); 
            layoutControlItem3.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem3.TextSize = new Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // treeList2
            // 
            treeList2.Location = new Point(662, 42);
            treeList2.Name = "treeList2";
            treeList2.Size = new Size(633, 546);
            treeList2.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = treeList2;
            layoutControlItem4.Location = new Point(650, 30);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(637, 550);
            layoutControlItem4.TextSize = new Size(0, 0);
            layoutControlItem4.TextVisible = false;
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
            ((ISupportInitialize)treeList2).EndInit();
            ((ISupportInitialize)layoutControlItem4).EndInit();
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
        private TreeList treeList2;
        private LayoutControlItem layoutControlItem4;
    }

    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    /// 
}