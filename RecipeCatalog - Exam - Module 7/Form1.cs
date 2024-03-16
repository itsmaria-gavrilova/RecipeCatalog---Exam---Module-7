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

namespace RecipeCatalog___Exam___Module_7
{
    public partial class Form1 : Form
    {
        private RecipeController recipeController;
        private RecipeTypeController recipeTypeController;
        private ProductController productController;
        private ProductTypeController productTypeController;
        private ProductRecipeController prController;
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
            dgvProduct.Enabled = false;
            dgvProductType.Enabled = false;
            dgvRecipe.Enabled = false;
            dgvRecipeType.Enabled = false;
            AddComboBoxItems();
        }
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
                List<string> productNames = rtbProducts.Text.Split("\n").ToList();
                Product_Recipe product_Recipe = new Product_Recipe();
                //List<Product> products = new List<Product>();
                foreach (string item in productNames)
                {
                    Product product = productController.GetByName(item);
                    product_Recipe.Recipe = recipe;
                    product_Recipe.Product = product;
                    product_Recipe.RecipeId = recipe.Id;
                    product_Recipe.ProductId = product.Id;
                    prController.Add(product_Recipe);
                }
            }
            UpdateGrid();
            ClearTextBoxes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                var item = dgvProduct.SelectedRows[0].Cells;
                int deletedId = int.Parse(item[0].Value.ToString());
                productController.Delete(deletedId);
                UpdateGrid();
                ResetSelect();
            }
            if (dgvRecipe.SelectedRows.Count > 0)
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
            if (rbProduct.Checked)
            {
                Product update = productController.Get(int.Parse(txb1.Text));
                update.Price = double.Parse(txb2.Text);
                update.TypeId = productTypeController.Get(int.Parse(txb3.Text)).Id;
                productController.Update(update);
                UpdateGrid();
                ResetSelect();
            }
            else if (rbRecipe.Checked)
            {
                Recipe update = recipeController.Get(int.Parse(txb1.Text));
                update.Kcal = int.Parse(txb2.Text);
                update.Rating = int.Parse(txb3.Text);
                update.TypeId = recipeTypeController.Get(int.Parse(txb4.Text)).Id;
                update.Description = rtxbDesc.Text;
                recipeController.Update(update);
                UpdateGrid();
                ResetSelect();
            }
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
            rtbProducts.Visible = false;
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
            rtbProducts.Visible = false;
            if (rbUpdate.Checked)
            {
                lbl4.Visible = false;
                lbl5.Visible = false;
                lblDescription.Visible = false;
                txb4.Visible = false;
                rtxbDesc.Visible = false;
                lblProducts.Visible = false;
                rtbProducts.Visible = false;
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
            rtbProducts.Visible = true;
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
                rtbProducts.Visible = true;
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
            lbl1.Visible = true;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            rbProduct.Visible = true;
            rbRecipe.Visible = true;
            txb2.Visible = false;
            txb1.Visible = true;
            txb3.Visible = false;
            txb4.Visible = false;
            rtxbDesc.Visible = false;
            lblEnterData.Visible = true;
            lblEnterData.Text = "Въведи име:";
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
            rtbProducts.Visible = false;
        }

        private void rbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProduct.Checked)
            {
                lbl4.Visible = false;
                lbl5.Visible = false;
                lblDescription.Visible = false;
                txb4.Visible = false;
                rtxbDesc.Visible = false;
                lblProducts.Visible = false;
                rtbProducts.Visible = false;
            }
            lbl4.Visible = true;
            lbl5.Visible = true;
            txb4.Visible = true;
            rtxbDesc.Visible = true;
            lblDescription.Visible = true;
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
            lblProducts.Visible = true;
            rtbProducts.Visible = true;
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
            rtbProducts.Clear();
        }
        private void ResetSelect()
        {
            dgvProduct.ClearSelection();
            dgvRecipe.ClearSelection();
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