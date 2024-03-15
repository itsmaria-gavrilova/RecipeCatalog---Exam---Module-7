using Business;
using Data;
using Data.Models;
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
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            this.recipeController = new RecipeController();
            this.recipeTypeController = new RecipeTypeController();
            this.productController = new ProductController();
            this.productTypeController = new ProductTypeController();
            this.form2= new Form2();
            rbAdmin.Checked = true;
            rbAdd.Checked = true;
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
                product.TypeId = productTypeController.Get(txb3.Text).Id;
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
                recipe.TypeId = recipeTypeController.Get(txb4.Text).Id;
                recipe.Description = rtxbDesc.Text;
                recipeController.Add(recipe);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rbProduct.Checked)
            {
                int deletedId = productController.Get(txb1.Text).Id;
                productController.Delete(deletedId);
            }
            else if (rbRecipe.Checked)
            {
                int deletedId = recipeController.GetByName(txb1.Text).Id;
                recipeController.Delete(deletedId);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rbProduct.Checked)
            {
                Product update = productController.Get(txb1.Text);
                update.Price = double.Parse(txb2.Text);
                update.TypeId = productTypeController.Get(txb3.Text).Id;
                productController.Update(update);
            }
            else if (rbRecipe.Checked)
            {
                Recipe update = recipeController.GetByName(txb1.Text);
                update.Kcal = int.Parse(txb2.Text);
                update.Rating = int.Parse(txb3.Text);
                update.TypeId = recipeTypeController.Get(txb4.Text).Id;
                update.Description = rtxbDesc.Text;
                recipeController.Update(update);
            }
        }

        private void btnTop5_Click(object sender, EventArgs e)
        {
            lsBoxRecipes.Items.Clear();
            List<Recipe> recipes = this.recipeController.Top5ByRating();
            foreach (Recipe recipe in recipes)
            {
                lsBoxRecipes.Items.Add(recipe);
            }
        }
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            lsBoxRecipes.Items.Clear();
            List<Recipe> recipes = this.recipeController.GetAll();
            foreach (Recipe recipe in recipes)
            {
                lsBoxRecipes.Items.Add(recipe);
            }
        }

        private void btnGetAllByType_Click(object sender, EventArgs e)
        {
            lsBoxRecipes.Items.Clear();
            List<Recipe> recipes = this.recipeController.GetAllByType(CbRecipeType.SelectedValue.ToString());
            foreach (Recipe recipe in recipes)
            {
                lsBoxRecipes.Items.Add(recipe);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            lsBoxRecipes.Items.Clear();
            this.recipeController.SortByCalories();
            List<Recipe> recipes = this.recipeController.GetAll();
            foreach (Recipe recipe in recipes)
            {
                lsBoxRecipes.Items.Add(recipe);
            }
        }

        private void lsBoxRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recipe recipe = this.recipeController.GetByName(lsBoxRecipes.SelectedItem.ToString());
            form2.recipe = recipe;
            form2.Show();
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
        }

        private void rbUpdate_CheckedChanged(object sender, EventArgs e)
        {
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
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }
    }
}
