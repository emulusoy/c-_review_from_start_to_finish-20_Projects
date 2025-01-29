using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Different20Project_14_MailRegister
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Entities context=new Entities();
        public string email;
        private void button1_Click(object sender, EventArgs e)
        {
            
            var value = context.TblUser.Where(x => x.Email == textBox1.Text).Select(y => y.Code).FirstOrDefault();
            if (textBox2.Text==value.ToString())
            {
                var value2 = context.TblUser.Where(x => x.Email == textBox1.Text).FirstOrDefault();
                value2.IsConfirm = true;
                context.SaveChanges();
                MessageBox.Show("Hesabiniz Aktif Edildi!");
            }
            else
            {
                MessageBox.Show("Yanlis kod");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = email;
        }
    }
}
