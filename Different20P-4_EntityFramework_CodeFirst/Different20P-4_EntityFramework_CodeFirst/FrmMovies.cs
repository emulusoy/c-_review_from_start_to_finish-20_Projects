using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Different20P_4_EntityFramework_CodeFirst.DAL.Context;
using Different20P_4_EntityFramework_CodeFirst.DAL.Entities;

namespace Different20P_4_EntityFramework_CodeFirst
{
    public partial class FrmMovies : Form
    {
        public FrmMovies()
        {
            InitializeComponent();
        }

        MovieContext context=new MovieContext();

        void List()
        {
            var values = context.Movies.ToList();
            dataGridView1.DataSource = values;
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void FrmMovies_Load(object sender, EventArgs e)
        {
            var values = context.Categories.ToList();
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";
            comboBox1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            movie.MovieTitle=textBox2.Text;
            movie.Duration = int.Parse(textBox3.Text);
            movie.Description = textBox4.Text; 
            movie.CreateDate=DateTime.Parse(maskedTextBox1.Text);
            movie.CategoryId =int.Parse(comboBox1.SelectedValue.ToString());
            context.Movies.Add(movie);
            context.SaveChanges();
            MessageBox.Show("ADDED!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value = context.Movies.Find(id);
            value.MovieTitle = textBox2.Text;
            value.Duration = int.Parse(textBox3.Text);
            value.Description = textBox4.Text;
            value.CreateDate = DateTime.Parse(maskedTextBox1.Text);
            value.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            context.SaveChanges();
            MessageBox.Show("UPDATED!");

            List();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value = context.Movies.Find(id);
            context.Movies.Remove(value);
            context.SaveChanges();
            MessageBox.Show("DELETED!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = context.Movies.Where(x => x.MovieTitle.Contains(textBox2.Text)).ToList();
            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var value = context.Movies
                .Join(context.Categories,
                movie => movie.CategoryId,
                category => category.CategoryId,
                (movie, category) => new
                {

                    MovieId = movie.MovieId,
                    MovieTitle = movie.MovieTitle,
                    Description = movie.Description,
                    Duration = movie.Duration,
                    CategoryName = category.CategoryName,


                }).ToList();
            dataGridView1.DataSource=value;  
        }
    }
}
