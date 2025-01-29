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

namespace Different20Project_11_WeatherApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double c;
        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/Istanbul/EN"),
                Headers =
    {
        { "x-rapidapi-key", "9cd394884emsh146f4c4615c50c7p1acc61jsn8ee26bba35b9" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                //yukarisi hazir api kodalari
                var json = JObject.Parse(body);
                var valuefah = json["main"]["feels_like"].ToString();//bu apideki deger! once maine git sonra digerine
                lblfah.Text = valuefah.ToString();

                var wind = json["wind"]["speed"].ToString();
                lblWind.Text = wind.ToString();
                c = (double.Parse(valuefah) - 32) / 1.8;
                lblc.Text = c.ToString("00.0");

                var humidity = json["main"]["humidity"].ToString();
                lblhumidity.Text = humidity.ToString();
                ;
            }
        }
    }
}
