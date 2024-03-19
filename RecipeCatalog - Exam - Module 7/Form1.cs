using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RecipeCatalog___Exam___Module_7
{
    public partial class Form1 : Form
    {
        private RecipeController recipeController;
        private RecipeTypeController recipeTypeController;
        private ProductController productController;
        private ProductTypeController productTypeController;
        private RecipeCatalogDbContext dbContext;
        private int editID = 0;
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            this.recipeController = new RecipeController();
            this.recipeTypeController = new RecipeTypeController();
            this.productController = new ProductController();
            this.productTypeController = new ProductTypeController();
            this.form2 = new Form2();
            rbAdmin.Checked = true;
            rbAdd.Checked = true;
            //AddData();
            AddComboBoxItems();
            AddCheckedListBoxItems();
        }
        //private void AddData()
        //{
        //    RecipeType type1 = new RecipeType();
        //    type1.Name = "паста";
        //    recipeTypeController.Add(type1);
        //    RecipeType type2 = new RecipeType();
        //    type2.Name = "салата";
        //    recipeTypeController.Add(type2);
        //    RecipeType type3 = new RecipeType();
        //    type3.Name = "скара";
        //    recipeTypeController.Add(type3);
        //    RecipeType type4 = new RecipeType();
        //    type4.Name = "десерт";
        //    recipeTypeController.Add(type4);
        //    RecipeType type5 = new RecipeType();
        //    type5.Name = "печиво";
        //    recipeTypeController.Add(type5);
        //    RecipeType type6 = new RecipeType();
        //    type6.Name = "супа";
        //    recipeTypeController.Add(type6);
        //    RecipeType type7 = new RecipeType();
        //    type7.Name = "разядка";
        //    recipeTypeController.Add(type7);
        //    RecipeType type8 = new RecipeType();
        //    type8.Name = "яхнии";
        //    recipeTypeController.Add(type8);
        //    RecipeType type9 = new RecipeType();
        //    type9.Name = "тестени";
        //    recipeTypeController.Add(type9);
        //    RecipeType type10 = new RecipeType();
        //    type10.Name = "сос";
        //    recipeTypeController.Add(type10);
        //    RecipeType type11 = new RecipeType();
        //    type11.Name = "риба";
        //    recipeTypeController.Add(type11);

        //    ProductType ptype1 = new ProductType();
        //    ptype1.Name = "плод";
        //    productTypeController.Add(ptype1);
        //    ProductType ptype2 = new ProductType();
        //    ptype2.Name = "зеленчук";
        //    productTypeController.Add(ptype2);
        //    ProductType ptype3 = new ProductType();
        //    ptype3.Name = "вариво";
        //    productTypeController.Add(ptype3);
        //    ProductType ptype4 = new ProductType();
        //    ptype4.Name = "месо";
        //    productTypeController.Add(ptype4);
        //    ProductType ptype5 = new ProductType();
        //    ptype5.Name = "тестени";
        //    productTypeController.Add(ptype5);
        //    ProductType ptype6 = new ProductType();
        //    ptype6.Name = "захарни";
        //    productTypeController.Add(ptype6);
        //    ProductType ptype7 = new ProductType();
        //    ptype7.Name = "зърнени";
        //    productTypeController.Add(ptype7);
        //    ProductType ptype8 = new ProductType();
        //    ptype8.Name = "морска храна";
        //    productTypeController.Add(ptype8);
        //    ProductType ptype9 = new ProductType();
        //    ptype9.Name = "млечни";
        //    productTypeController.Add(ptype9);

        //    Product product1 = new Product();
        //    product1.Name = "краставица";
        //    product1.Price = 0.7;
        //    product1.TypeId = 2;
        //    productController.Add(product1);
        //    Product product2 = new Product();
        //    product2.Name = "домат";
        //    product2.Price = 0.8;
        //    product2.TypeId = 2;
        //    productController.Add(product2);
        //    Product product3 = new Product();
        //    product3.Name = "хляб";
        //    product3.Price = 1.2;
        //    product3.TypeId = 5;
        //    productController.Add(product3);
        //    Product product4 = new Product();
        //    product4.Name = "салам";
        //    product4.Price = 2.3;
        //    product4.TypeId = 4;
        //    productController.Add(product4);
        //    Product product5 = new Product();
        //    product5.Name = "сирене";
        //    product5.Price = 5.4;
        //    product5.TypeId = 9;
        //    productController.Add(product5);
        //}
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbProduct.Checked)
            {
                lbl2.Text = "Цена:";
                lbl3.Text = "Тип:";
                lbl4.Visible = false;
                lbl5.Visible = false;
                lblDescription.Visible = false;
                txb4.Visible = false;
                rtxbDesc.Visible = false;
                Product product = new Product();
                product.Name = txb1.Text;
                product.Price = double.Parse(txb2.Text);
                product.TypeId = productTypeController.GetByName(txb3.Text);
                productController.Add(product);
                clbProducts.Items.Add(product.Name);
            }
            else if (rbRecipe.Checked)
            {
                lbl2.Text = "Калории:";
                lbl3.Text = "Рейтинг:";
                lbl4.Visible = true;
                lbl5.Visible = true;
                lblDescription.Visible = true;
                txb4.Visible = true;
                rtxbDesc.Visible = true;
                Recipe recipe = new Recipe();
                recipe.Name = txb1.Text;
                recipe.Kcal = int.Parse(txb2.Text);
                recipe.Rating = int.Parse(txb3.Text);
                recipe.TypeId = recipeTypeController.GetByName(txb4.Text);
                recipe.Description = rtxbDesc.Text;
                recipeController.Add(recipe);
                foreach(var item in clbProducts.CheckedItems)
                {
                    int productId = productController.GetByName(item.ToString()).Id;
                    Product_Recipe pr = new Product_Recipe();
                    pr.ProductId = productId;
                    pr.RecipeId = recipe.Id;
                    recipeController.AddProductRecipe(pr);
                }
            }
            UpdateGrid();
            ClearTextBoxes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0 && rbProduct.Checked)
            {
                var item = dgvProduct.SelectedRows[0].Cells;
                int deletedId = int.Parse(item[0].Value.ToString());
                productController.Delete(deletedId);
                UpdateGrid();
                ResetSelect();
            }
            if (dgvRecipe.SelectedRows.Count > 0 && rbRecipe.Checked)
            {
                var item = dgvRecipe.SelectedRows[0].Cells;
                int deletedId = int.Parse(item[0].Value.ToString());
                recipeController.Delete(deletedId);
                UpdateGrid();
                ResetSelect();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clbProducts.Visible = false;
            if (rbProduct.Checked)
            {
                Product editedProduct = new Product();
                editedProduct.Id = editID;
                editedProduct.Name = txb1.Text;
                editedProduct.Price = double.Parse(txb2.Text);
                editedProduct.TypeId = productTypeController.GetByName(txb3.Text);
                productController.Update(editedProduct);
                UpdateGrid();
                dgvProduct.ClearSelection();
                dgvProduct.Enabled = true;

            }
            else if (rbRecipe.Checked)
            {
                Recipe editedRecipe = new Recipe();
                editedRecipe.Id = editID;
                editedRecipe.Name = txb1.Text;
                editedRecipe.Kcal = int.Parse(txb2.Text);
                editedRecipe.Rating = int.Parse(txb3.Text);
                editedRecipe.TypeId = recipeTypeController.GetByName(txb4.Text);
                editedRecipe.Description = rtxbDesc.Text;
                recipeController.Update(editedRecipe);
                UpdateGrid();
                dgvRecipe.ClearSelection();
                dgvRecipe.Enabled = true;
            }
            ClearTextBoxes();
            rbUpdate.Checked = false;
        }

        private void btnTop5_Click(object sender, EventArgs e)
        {
            lsBoxRecipes.Items.Clear();
            List<Recipe> recipes = this.recipeController.Top5ByRating();
            foreach (Recipe recipe in recipes)
            {
                lsBoxRecipes.Items.Add(recipe.Name);
            }
        }

        private void rbAdmin_CheckedChanged_1(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            gbProductRecipe.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = true;
            rbProduct.Visible = true;
            rbRecipe.Visible = true;
            txb2.Visible = true;
            txb1.Visible = true;
            txb3.Visible = true;
            txb4.Visible = true;
            rtxbDesc.Visible = true;
            lblEnterData.Visible = true;
            CbRecipeType.Visible = false;
            btnGetAll.Visible = false;
            btnGetAllByType.Visible = false;
            btnSort.Visible = false;
            btnTop5.Visible = false;
            lsBoxRecipes.Visible = false;
            rbAdd.Visible = true;
            rbDelete.Visible = true;
            rbUpdate.Visible = true;
            lblDescription.Visible = true;
            lblProducts.Visible = true;
            clbProducts.Visible = true;
        }

        private void rbCustomer_CheckedChanged_1(object sender, EventArgs e)
        {
            CbRecipeType.Visible = true;
            btnGetAll.Visible = true;
            btnGetAllByType.Visible = true;
            btnSort.Visible = true;
            btnTop5.Visible = true;
            lsBoxRecipes.Visible = true;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            gbProductRecipe.Visible = false;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            rbProduct.Visible = false;
            rbRecipe.Visible = false;
            txb2.Visible = false;
            txb1.Visible = false;
            txb3.Visible = false;
            txb4.Visible = false;
            lblDescription.Visible = false;
            rtxbDesc.Visible = false;
            lblEnterData.Visible = false;
            rbAdd.Visible = false;
            rbDelete.Visible = false;
            rbUpdate.Visible = false;
            clbProducts.Visible = false;
            lblProducts.Visible = false;
        }

        private void rbProduct_CheckedChanged(object sender, EventArgs e)
        {
            lbl2.Text = "Цена:";
            lbl3.Text = "Тип:";
            lbl4.Visible = false;
            lbl5.Visible = false;
            lblDescription.Visible = false;
            txb4.Visible = false;
            rtxbDesc.Visible = false;
            lblProducts.Visible = false;
            clbProducts.Visible = false;
            if (rbUpdate.Checked)
            {
                lbl4.Visible = false;
                lbl5.Visible = false;
                lblDescription.Visible = false;
                txb4.Visible = false;
                rtxbDesc.Visible = false;
                lblProducts.Visible = false;
                clbProducts.Visible = false;
            }
        }

        private void rbRecipe_CheckedChanged(object sender, EventArgs e)
        {
            lbl2.Text = "Калории:";
            lbl3.Text = "Рейтинг:";
            lbl4.Visible = true;
            lbl5.Visible = true;
            lblDescription.Visible = true;
            txb4.Visible = true;
            rtxbDesc.Visible = true;
            lblProducts.Visible = true;
            clbProducts.Visible = true;
            if (rbDelete.Checked)
            {
                lbl4.Visible = false;
                lbl5.Visible = false;
                txb4.Visible = false;
                rtxbDesc.Visible = false;
                lblDescription.Visible = false;
            }
        }

        private void rbAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRecipe.Checked)
            {
                lbl4.Visible = true;
                lbl5.Visible = true;
                txb4.Visible = true;
                rtxbDesc.Visible = true;
                lblDescription.Visible = true;
                lblProducts.Visible = true;
                clbProducts.Visible = true;
            }
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            gbProductRecipe.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            rbProduct.Visible = true;
            rbRecipe.Visible = true;
            txb2.Visible = true;
            txb1.Visible = true;
            txb3.Visible = true;
            lblEnterData.Visible = true;
            CbRecipeType.Visible = false;
            lblEnterData.Text = "Въведи информация:";
            btnGetAll.Visible = false;
            btnGetAllByType.Visible = false;
            btnSort.Visible = false;
            btnTop5.Visible = false;
            lsBoxRecipes.Visible = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            gbProductRecipe.Visible = true;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            rbProduct.Visible = true;
            rbRecipe.Visible = true;
            txb2.Visible = false;
            txb1.Visible = false;
            txb3.Visible = false;
            txb4.Visible = false;
            rtxbDesc.Visible = false;
            lblEnterData.Visible = false;
            lblDescription.Visible = false;
            CbRecipeType.Visible = false;
            btnGetAll.Visible = false;
            btnGetAllByType.Visible = false;
            btnSort.Visible = false;
            btnTop5.Visible = false;
            lsBoxRecipes.Visible = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            lblProducts.Visible = false;
            clbProducts.Visible = false;
        }

        private void rbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProduct.Checked)
            {
                if (dgvProduct.SelectedRows.Count > 0)
                {
                    var item = dgvProduct.SelectedRows[0].Cells;
                    var id = int.Parse(item[0].Value.ToString());
                    editID = id;
                    UpdateProductTextBoxes(id);
                    dgvProduct.Enabled = false;
                }
            }
            else if (rbRecipe.Checked)
            {
                if (dgvRecipe.SelectedRows.Count > 0)
                {
                    var item = dgvRecipe.SelectedRows[0].Cells;
                    var id = int.Parse(item[0].Value.ToString());
                    editID = id;
                    UpdateRecipeTextBoxes(id);
                    dgvRecipe.Enabled = false;
                }
            }
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            gbProductRecipe.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            rbProduct.Visible = true;
            rbRecipe.Visible = true;
            txb2.Visible = true;
            txb1.Visible = true;
            txb3.Visible = true;
            lblEnterData.Visible = true;
            CbRecipeType.Visible = false;
            lblEnterData.Text = "Въведи нова информация:";
            btnGetAll.Visible = false;
            btnGetAllByType.Visible = false;
            btnSort.Visible = false;
            btnTop5.Visible = false;
            lsBoxRecipes.Visible = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ClearTextBoxes();
        }
        private void UpdateGrid()
        {
            dgvProductType.DataSource = productTypeController.GetAll();
            dgvProductType.ReadOnly = true;
            dgvProductType.SelectionMode=DataGridViewSelectionMode.FullRowSelect;

            dgvRecipeType.DataSource = recipeTypeController.GetAll();
            dgvRecipeType.ReadOnly = true;
            dgvRecipeType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProduct.DataSource = productController.GetAll();
            dgvProduct.ReadOnly = true;
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvRecipe.DataSource = recipeController.GetAll();
            dgvRecipe.ReadOnly = true;
            dgvRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearTextBoxes()
        {
            txb2.Clear();
            txb1.Clear();
            txb3.Clear();
            txb4.Clear();
            rtxbDesc.Clear();
        }
        private void ResetSelect()
        {
            dgvProduct.ClearSelection();
            dgvRecipe.ClearSelection();

        }
        private void UpdateProductTextBoxes(int id)
        {
            Product update = productController.Get(id);
            txb1.Text = update.Name;
            txb2.Text = update.Price.ToString();
            txb3.Text = productTypeController.Get(update.TypeId).Name;
        }
        private void UpdateRecipeTextBoxes(int id)
        {
            Recipe update = recipeController.Get(id);
            txb1.Text = update.Name;
            txb2.Text = update.Kcal.ToString();
            txb3.Text = update.Rating.ToString();
            txb4.Text = recipeTypeController.Get(update.TypeId).Name;
            rtxbDesc.Text = update.Description;
        }
        private void lsBoxRecipes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Recipe recipe = this.recipeController.GetByName(lsBoxRecipes.SelectedItem.ToString());
            form2.recipe = recipe;
            form2.Show();
        }

        private void btnGetAll_Click_1(object sender, EventArgs e)
        {
            lsBoxRecipes.Items.Clear();
            List<Recipe> recipes = this.recipeController.GetAll();
            foreach (Recipe recipe in recipes)
            {
                lsBoxRecipes.Items.Add(recipe.Name);
            }
        }

        private void btnGetAllByType_Click_1(object sender, EventArgs e)
        {
            lsBoxRecipes.Items.Clear();
            List<Recipe> recipes = this.recipeController.GetAllByType(CbRecipeType.SelectedItem.ToString());
            foreach (Recipe recipe in recipes)
            {
                lsBoxRecipes.Items.Add(recipe.Name);
            }
        }
        private void AddComboBoxItems()
        {
            List<RecipeType> rt = recipeTypeController.GetAll();
            foreach (var item in rt)
            {
                CbRecipeType.Items.Add(item.Name);
            }
        }
        private void AddCheckedListBoxItems()
        {
            List<Product> products = productController.GetAll();
            foreach (var item in products)
            {
                clbProducts.Items.Add(item.Name);
            }
        }
        private void btnSort_Click_1(object sender, EventArgs e)
        {
            lsBoxRecipes.Items.Clear();
            List<Recipe> recipes = this.recipeController.SortByCalories();
            foreach (Recipe recipe in recipes)
            {
                lsBoxRecipes.Items.Add(recipe.Name);
            }
        }
    }
}