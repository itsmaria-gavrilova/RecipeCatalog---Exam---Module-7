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
    public partial class Form2 : Form
    {
        public Recipe recipe;
        private RecipeTypeController recipeTypeController;
        public Form2()
        {
            InitializeComponent();
            this.recipe = new Recipe();
            this.recipeTypeController = new RecipeTypeController();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            lblCaloriesResult.Text = recipe.Kcal.ToString();
            lblDescriptionResult.Text = recipe.Description.ToString();
            lblRatingResult.Text = recipe.Rating.ToString();
            lblTypeResult.Text = recipeTypeController.Get(recipe.TypeId).Name;
            lblRecipeName.Text = recipe.Name.ToString();
        }
    }
}
