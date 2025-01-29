using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

namespace Different20Project_14_MailRegister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Entities context=new Entities();
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd= new Random();   
            int codeConfirm=rnd.Next(100000,1000000);
            TblUser user=new TblUser();

            user.Name=textBox1.Text;
            user.Surname=textBox2.Text;
            user.Email=textBox3.Text;  
            user.Password=textBox4.Text;
            user.IsConfirm=false;
            user.Code=codeConfirm.ToString();

            context.TblUser.Add(user);
            context.SaveChanges();

            #region
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("AdminRegister", "emucryptoo@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", textBox3.Text);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder=new BodyBuilder();

            bodyBuilder.TextBody = "Email Adresinizin Konfirmasyon kodu ?>" + codeConfirm;
            mimeMessage.Body=bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Email Konfirmasyon Kodu";

            SmtpClient smtpClient = new SmtpClient();//mail transfer protokolu
            smtpClient.Connect("smtp.gmail.com", 587, false);//trnin kodu bu
            smtpClient.Authenticate("emucryptoo@gmail.com", "zwiugfdiswzyufau");//bu sifreyi google veriyor!
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            MessageBox.Show("Dogrulama kodu gonderildi!");

            Form2 form = new Form2();
            form.ShowDialog();  



            #endregion



        }
    }
}
