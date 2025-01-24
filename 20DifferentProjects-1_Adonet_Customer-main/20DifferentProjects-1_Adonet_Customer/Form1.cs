using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20DifferentProjects_1_Adonet_Customer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=EMU2025\\MSSQLSERVER01;initial catalog=20DifferentProject_1_Adonet_DbCustomer;integrated security=true");
        private void btnList_Click(object sender, EventArgs e)
        {
          
            conn.Open();
            SqlCommand command=new SqlCommand("Select * From TblCity",conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command=new SqlCommand("Insert Into TblCity (CityName,CityCountry) values (@p1,@p2)",conn);
            command.Parameters.AddWithValue("@p1", textBox2.Text);
            command.Parameters.AddWithValue("@p2",textBox3.Text);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Delete  From TblCity Where CityId=@p1", conn);
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Update TblCity Set CityName=@p1,CityCountry=@p2 Where CityId=@p3", conn);
            
            command.Parameters.AddWithValue("@p1", textBox2.Text);
            command.Parameters.AddWithValue("@p2", textBox3.Text);
            command.Parameters.AddWithValue("@p3", textBox1.Text);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select * From TblCity Where CityName=@p1", conn);
            command.Parameters.AddWithValue("@p1", textBox4.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
