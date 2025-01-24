using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace emu20DifferentProject_2_EntityFramework_DBfirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Entities db=new Entities();

        void List()
        {
            dataGridView1.DataSource = db.TblCategory.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TblCategory tblCategory = new TblCategory();
            tblCategory.CategoryName = textBox2.Text;
            db.TblCategory.Add(tblCategory);
            db.SaveChanges();
            List();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var values = db.TblCategory.Find(Convert.ToInt16(textBox1.Text));
            db.TblCategory.Remove(values);
            db.SaveChanges();
            List();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var values = db.TblCategory.Find(Convert.ToInt16(textBox1.Text));
            
            values.CategoryName = textBox2.Text;
            db.SaveChanges();
            List();
        }
    }
}
