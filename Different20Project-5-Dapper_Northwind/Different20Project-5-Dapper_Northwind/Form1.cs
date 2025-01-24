using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Different20Project_5_Dapper_Northwind.Dtos.CategoryDtos;

namespace Different20Project_5_Dapper_Northwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection =new SqlConnection("Server=MULUSOY\\SQLEXPRESS01;initial catalog=20DifferentProject-5-DB;integrated security=true");
        private async void button1_Click(object sender, EventArgs e)
        {
            string query = "Select * From Categories";
            var values =await connection.QueryAsync<ResultCategoryDto>(query);
            dataGridView1.DataSource = values;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string query = "Insert INTO Categories (CategoryName,Description) values (@p1,@p2)";
            var parameters = new DynamicParameters();//ben sana dinamik olarak parametre gonderecem demekk
            parameters.Add("@p1", textBox1.Text);
            parameters.Add("@p2", textBox2.Text);
            await connection.ExecuteAsync(query, parameters);//sqlden gelen sorguma parametreleri gecir!
            
            
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string query = "Delete  From Categories Where(CategoryId=@p1)";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", textBox1.Text);
            await connection.ExecuteAsync(query, parameters);
            
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string query = "Update Categories Set CategoryName=@p1 where(CategoryId=@p2)";
            var parameters = new DynamicParameters();
            parameters.Add("@p2", textBox1.Text);
            parameters.Add("@p1", textBox2.Text);
           await connection.ExecuteAsync(query, parameters);

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string query = "Select Count(*) From Categories";
            
            label4.Text = "Toplam kategori sayisi : "+ await connection.ExecuteScalarAsync<int>(query); 
            // int deger donderdik queryle bveraber
            string query2 = "Select Count(*) From Products";
            label5.Text = "Toplam Urun sayisi : " + await connection.ExecuteScalarAsync<int>(query2);

            //ortalama stok sayisi
            string query3 = "Select Avg(UnitsInStock) From Products";
            label6.Text = "Ortalama stok sayisi : " + await connection.ExecuteScalarAsync<int>(query3);

            //deniz urunerinin toplam fiyati

            string query4 = "Select Sum(UnitsInStock) From Products where CategoryId=(Select CategoryId From Categories Where CategoryName='SeaFood')";
            label7.Text = "SeaFood toplam stok : " + await connection.ExecuteScalarAsync<int>(query4);
        }
    }
}
