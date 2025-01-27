using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Different20Project_9_MongoDb_Order.Entities;
using Different20Project_9_MongoDb_Order.Services;

namespace Different20Project_9_MongoDb_Order
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OrderOperation operation=new OrderOperation();
        private void button2_Click(object sender, EventArgs e)
        {
            var order = new Order{
                
                CustomerName = textBox2.Text,
                District = textBox3.Text,
                City = textBox4.Text,
                TotalPrice = decimal.Parse(textBox5.Text),
            };
            operation.AddOrder(order);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> order = operation.ListOrder();
            dataGridView1.DataSource = order;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string orderId = textBox1.Text;
            operation.DeleteOrder(orderId);
            
            MessageBox.Show("Deleted");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            var uupdateOrder = new Order
            {
                CustomerName = textBox2.Text,
                District = textBox3.Text,
                City = textBox4.Text,
                OrderId = id,
                TotalPrice = decimal.Parse(textBox5.Text),
            };
            operation.UpdateOrder(uupdateOrder);
            MessageBox.Show("Updated!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            Order orders = operation.GetOrderById(id);
            dataGridView1.DataSource = new List<Order> { orders };
        }
    }
}
