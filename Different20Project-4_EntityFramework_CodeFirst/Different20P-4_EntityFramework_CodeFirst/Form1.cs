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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         MovieContext context = new MovieContext();
        void List()
        {
            var values = context.Categories.ToList();
            dataGridView1.DataSource = values;
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName=textBox2.Text;
            context.Categories.Add(category);
            context.SaveChanges();
            MessageBox.Show("Added!");
            List();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id =int.Parse(textBox1.Text);
            var value = context.Categories.Find(id);
            value.CategoryName = textBox2.Text;
            context.SaveChanges();
            MessageBox.Show("Updated!");
            List();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(textBox1.Text);
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            MessageBox.Show("Deleted!");
            List();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = context.Categories.Where(x => x.CategoryName.Contains(textBox2.Text)).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
