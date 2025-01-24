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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Different20Project_8_Rapid_Api_Currency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        
        private async void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            #region dolar
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=try&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "9cd394884emsh146f4c4615c50c7p1acc61jsn8ee26bba35b9" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var value = json["result"].ToString();
                label1.Text =value;
                //Console.WriteLine(body);
            }


            #endregion





            #region Euro

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=try&amount=1"),//EUR YAPTIK
                Headers =
    {
        { "x-rapidapi-key", "9cd394884emsh146f4c4615c50c7p1acc61jsn8ee26bba35b9" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                var json2 = JObject.Parse(body2);
                var value2 = json2["result"].ToString();
                label2.Text =value2;
                //Console.WriteLine(body);
            }

        }
        #endregion
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            decimal toplam = 0;
            decimal price = decimal.Parse(textBox1.Text);
            decimal usd = decimal.Parse(label1.Text);
            decimal eur = decimal.Parse(label2.Text);
            if (radioButton1.Checked)
            {
                radioButton2.Enabled = false;
                
                toplam = usd * price;
                
            }
            if (radioButton2.Checked)
            {
                radioButton1.Enabled = false;
                toplam = eur * price;

            }
            textBox2.Text = toplam.ToString();
        }
    }
}
