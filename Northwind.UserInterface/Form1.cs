using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.UserInterface
{
    public partial class Form1 : Form
    {
        IProductService _productService;
        ICategoryService _categoryService;

        public Form1()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbProductNameUpdate.Text=dgwProduct.CurrentRow.Cells[1].Value.ToString();
            cbxCategoryUpdate.SelectedValue = dgwProduct.CurrentRow.Cells[2].Value;
            //combobox oldugunda dikkat etmek gerekir birincisi selectedvalue seçilecek deger ,display member gösterilecek deger,
            //
            txbUnitPriceUpdate.Text=dgwProduct.CurrentRow.Cells[3].Value.ToString();
            txbUnitsInStockUpdate.Text= dgwProduct.CurrentRow.Cells[4].Value.ToString();
            txbQuantityPerUnitsUpdate.Text= dgwProduct.CurrentRow.Cells[5].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void LoadCategories()
        {
            cbxCategorySearch.DataSource=_categoryService.GetAll();
            cbxCategorySearch.DisplayMember= "CategoryName";
            cbxCategorySearch.ValueMember = "CategoryID";

            cbxCategoryAdd.DataSource=_categoryService.GetAll();
            cbxCategoryAdd.DisplayMember = "CategoryName";
            cbxCategoryAdd.ValueMember = "CategoryID";


            cbxCategoryUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryUpdate.DisplayMember = "CategoryName";
            cbxCategoryUpdate.ValueMember = "CategoryID";
        }

        private void txbProductNameSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbProductNameSearch.Text))
            {

                LoadProducts();
            
            }
            else 
            { 
                LoadByProductNameSearch(txbProductNameSearch.Text); 
            }
            
        }

        private void LoadByProductNameSearch(string key)
        {
            dgwProduct.DataSource = _productService.GetAll().Where(p => p.ProductName.ToLower().Contains(key.ToLower())).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product 
            { 
                ProductName=txbProductNameAdd.Text,
                CategoryID=Convert.ToInt32(cbxCategoryAdd.SelectedValue),
                UnitPrice=Convert.ToDecimal(txbUnitPriceadd.Text),
                UnitsInStock=Convert.ToInt16(txbUnitsInstockAdd.Text),
                QuantityPerUnit=txbUnitsInstockAdd.Text


            });
            MessageBox.Show("Added");
            LoadProducts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // güncelle de kaldık
        }
    }
}
