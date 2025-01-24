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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=EMU2025\\MSSQLSERVER01;initial catalog=20DifferentProject_1_Adonet_DbCustomer;integrated security=true");
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Delete  From TblCustomer Where CityId=@p1", conn);
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.ExecuteNonQuery();
            conn.Close();
        }

       
        private void btnList_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select CustomerId,CustomerName,CustomerSurname,CustomerBalance,CustomerStatus,CityName From TblCustomer Inner Join TblCity On TblCity.CityId=TblCustomer.CustomerCity", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Execute Listeleme", conn);//Burada sql de olusturdugumuz proseduru calistirdik!
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("insert into TblCustomer  (CustomerName,CustomerSurname,CustomerBalance,CustomerCountry,CustomerStatus) Values (@p1,@p2,@p3,@p4,@p5)", conn);

            command.Parameters.AddWithValue("@p1", textBox2.Text);
            command.Parameters.AddWithValue("@p2", textBox3.Text);
            command.Parameters.AddWithValue("@p3", textBox4.Text);
            command.Parameters.AddWithValue("@p4", comboBox1.SelectedValue);
            command.Parameters.AddWithValue("@p5", textBox5.Text);
            
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select * From TblCity", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            comboBox1.ValueMember = "CityId";
            comboBox1.DisplayMember = "CityName";
            comboBox1.DataSource = dataTable;   
           
            conn.Close();

        }
    }
}
