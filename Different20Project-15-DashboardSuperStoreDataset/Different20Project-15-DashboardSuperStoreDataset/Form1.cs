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

namespace Different20Project_15_DashboardSuperStoreDataset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnect=new SqlConnection("Server=MULUSOY\\SQLEXPRESS01;initial catalog=Different20Project-15-DB;integrated security=true");
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Statistic Widget
            sqlConnect.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) From train",sqlConnect);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lblProductCount.Text = reader[0].ToString();
            }
            sqlConnect.Close();

            sqlConnect.Open();
            SqlCommand cmd2 = new SqlCommand("Select Count(Distinct(state)) From train", sqlConnect);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                lblCityCount.Text = reader2[0].ToString();
            }
            sqlConnect.Close();

            sqlConnect.Open();
            SqlCommand cmd3 = new SqlCommand("Select count(*) From train where city='Los Angeles'", sqlConnect);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                lblLosangales.Text = reader3[0].ToString();
            }
            sqlConnect.Close();

            sqlConnect.Open();
            SqlCommand cmd4 = new SqlCommand("Select Sum(sales) From train where city='Los Angeles'", sqlConnect);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                lblOrderCount.Text = reader4[0].ToString();
            }
            sqlConnect.Close();
            #endregion
            #region Chart

            sqlConnect.Open();
            SqlCommand cmd5 = new SqlCommand("Select Top(7) City,Count(*) From train Group By City order by COUNT(*) desc", sqlConnect);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            while (reader5.Read())
            {
                chart1.Series["Series1"].Points.AddXY(reader5[0],reader5[1]);
            }
            sqlConnect.Close();

            sqlConnect.Open();
            SqlCommand cmd6 = new SqlCommand("Select top(4) City, Sum(Sales) From train Group by City order by sum(sales) desc", sqlConnect);
            SqlDataReader reader6 = cmd6.ExecuteReader();
            while (reader6.Read())
            {
                chart2.Series["Series1"].Points.AddXY(reader6[0], reader6[1]);
            }
            sqlConnect.Close();




            #endregion
        }

    }
}
