using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Different20Project_13_GassPrice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double gasolinePrice = 0;
        double dieselPrice = 0;      
        double lpgPrice = 0;
        double gasAmount=0;
        double lpgAmount = 0;
        double dieselAmount =0;
        double progressBar = 0;
        double totalPrice = 0;
        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            gasAmount = Convert.ToDouble(textgasamount.Text);
            dieselAmount = Convert.ToDouble(textgasamount.Text);
            lpgAmount = Convert.ToDouble(textgasamount.Text);
            timer1.Start();
            timer1.Interval = 200;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.Text = count.ToString();
            
            if (radioButton1.Checked)
            {
                count++;
                if (count <= gasAmount)
                {
                    totalPrice += gasolinePrice;
                    texttotal.Text = totalPrice.ToString();
                }
                else
                {
                    texttotal.Text = totalPrice.ToString();
                }
                progressBar1.Value += 1;

                if (progressBar1.Value == 99)
                {
                    timer1.Stop();
                }
            }
            if (radioButton2.Checked)
            {
                count++;
                if (count <= dieselAmount)
                {
                    totalPrice += dieselPrice;
                    texttotal.Text = totalPrice.ToString();
                }
                else
                {
                    texttotal.Text = totalPrice.ToString();
                }
                progressBar1.Value += 1;

                if (progressBar1.Value == 99)
                {
                    timer1.Stop();
                }
            }
            if (radioButton3.Checked)
            {
                count++;
                if (count <= lpgAmount)
                {
                    totalPrice += lpgPrice;
                    texttotal.Text = totalPrice.ToString();
                }
                else
                {
                    texttotal.Text = totalPrice.ToString();
                }
                progressBar1.Value += 1;

                if (progressBar1.Value == 99)
                {
                    timer1.Stop();
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
        
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://akaryakit-fiyatlari.p.rapidapi.com/fuel/istanbul"),
                Headers =
    {
        { "x-rapidapi-key", "9cd394884emsh146f4c4615c50c7p1acc61jsn8ee26bba35b9" },
        { "x-rapidapi-host", "akaryakit-fiyatlari.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var valueGasoline = json["data"][16]["prices"][0]["benzin"];               
                var valueDiesel = json["data"][16]["prices"][0]["motorin"];               
                var valueLpg = json["data"][16]["prices"][0]["lpg"];                
                textgasoline.Text = valueGasoline.ToString();
                textdiesel.Text = valueDiesel.ToString();
                textlpg.Text = valueLpg.ToString();


            }
            

            
            
        }
    }
}
