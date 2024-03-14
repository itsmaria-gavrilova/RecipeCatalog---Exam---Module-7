using Business;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

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
            txt1.Visible = true;
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
            txt1.Visible = false;
            txb3.Visible = false;
            txb4.Visible = false;
            rtxbDesc.Visible = false;
            lblEnterData.Visible = false;
        }
    }
}
