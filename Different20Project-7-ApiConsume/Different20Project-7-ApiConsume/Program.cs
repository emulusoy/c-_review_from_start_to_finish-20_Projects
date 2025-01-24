
#region MenuBaslangici

using System;
using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

Console.WriteLine("Api Consume Islemine Hosgeldiniz!");
Console.WriteLine();
Console.WriteLine("Yapmak Islediginiz Islemi Seciniz :");
Console.WriteLine();
Console.WriteLine("1--Sehir Listesini Getirin.");
Console.WriteLine("2--Sehir ve Hava Durumu Listesini Getirin.");
Console.WriteLine("3--Sehir Ekleme Getirin.");
Console.WriteLine("4--Sehir Silme Getirin.");
Console.WriteLine("5--Sehir Guncelleme Getirin.");
Console.WriteLine("6--Sehiri Idye Gore Listeleme.");
Console.WriteLine();

string number;
Console.WriteLine("Tercihinizi Secin!");
number = Console.ReadLine();
if (number == "1")
{
    Console.WriteLine("Sehir Listesi");

    string url = "https://localhost:7199/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response=await client.GetAsync(url);
        string responseBody=await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);
        foreach (var item in jArray)
        {
            string cityName = item["cityName"].ToString();
            Console.WriteLine($"Sehir: {cityName}");
        }

    }
}
if (number == "2")
{
    Console.WriteLine("Sehir ve Hava Durumu Listesi");
    string url = "https://localhost:7199/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage responseMessage=await client.GetAsync(url);
        string responseBody=await responseMessage.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);
         foreach(var item in jArray)
        {
            string cityName = item["cityName"].ToString();
            string temp =item["temp"].ToString();
            string country =item["countryName"].ToString();
            Console.WriteLine($"Sehir: {cityName}"+" | "+$" Sicaklik: {temp}"+$" | Ulke: {country}");
        }

    }
}
if (number == "3")
{
    Console.WriteLine("Sehir Ekleme Alani");
    Console.WriteLine();

    string cityName, countryName, detail;
    decimal temp;
    Console.WriteLine("Sehir Ismini Girriniz!");
    cityName=Console.ReadLine();
    Console.WriteLine("Ulke Ismini Girriniz!");
    countryName=Console.ReadLine();
    Console.WriteLine("Detaylari  Girriniz!");
    detail=Console.ReadLine();
    Console.WriteLine("Dereceyi Girriniz!");
    temp=decimal.Parse(Console.ReadLine());


    string url = "https://localhost:7199/api/Weathers";
    var newWeatherCity = new
    {
        //burada atama yapacaz konsolda almak istediklerimiz
        CityName = cityName,
        CountryName = countryName,
        Detail = detail,
        Temp = temp
    };
    using (HttpClient client = new HttpClient())
    {
        string json = JsonConvert.SerializeObject(newWeatherCity);//yukaridaki newWeathertCity icideki degerleri jsona donusturecegiz o veriler bizim icin json dosyasina getirecek
        StringContent content = new StringContent(json,Encoding.UTF8,"application/json");//BU BIR STANDART donusum yapacagim turu yazmam gerekiyor utf 8 de tr karakterler icin! ve ben sana bir json dosyasi gonderiyorum demektir 
        HttpResponseMessage responseMessage =await client.PostAsync(url,content);//nereye urlye ne atiyim content icindeki donusumu at!
        responseMessage.EnsureSuccessStatusCode();//istegin basarili olp olmadigini kontrol eder
    }

}
if (number == "4")
{
    Console.WriteLine("Sehir Silme Alani");
    Console.WriteLine();
    string url = "https://localhost:7199/api/Weathers";

    Console.WriteLine("Hangi Id yi silmek istiyorsunuz?");
    int id=Convert.ToInt32(Console.ReadLine());
    using (HttpClient client=new HttpClient())
    {
        HttpResponseMessage response=await client.DeleteAsync(url+"?id="+id);
        response.EnsureSuccessStatusCode();

    }

}
if (number == "5")
{
    Console.WriteLine("Sehir guncelleme Islemi");
    Console.WriteLine();

    string cityName, countryName, detail;
    decimal temp;
    int cityId;

    Console.Write("Sehir Ismini Girriniz! ");
    cityName = Console.ReadLine();
    Console.Write("Ulke Ismini Girriniz! ");
    countryName = Console.ReadLine();
    Console.Write("Dereceyi Girriniz! ");
    temp = decimal.Parse(Console.ReadLine());
    Console.Write("Detaylari  Girriniz! ");
    detail = Console.ReadLine();
    Console.Write("Sehir numarasini Girriniz! ");
    cityId = int.Parse(Console.ReadLine());

    string url = "https://localhost:7199/api/Weathers";
    var updatedWeatherCity = new
    {
        //burada atama yapacaz konsolda almak istediklerimiz
        CityId=cityId,
        CityName = cityName,
        CountryName = countryName,
        Detail = detail,
        Temp = temp
    };
    using (HttpClient client = new HttpClient())
    {
        string json=JsonConvert.SerializeObject(updatedWeatherCity);
        StringContent content = new StringContent(json, Encoding.UTF8,"application/json");    
        HttpResponseMessage response=await client.PutAsync(url, content);
        response.EnsureSuccessStatusCode();


    }

}
if (number == "6")
{
    Console.WriteLine("Idye Gore Sehir Listesi");
    Console.WriteLine();
    
    Console.Write("Hangi id deki bilgileri getirelim : ");
    int id=int.Parse(Console.ReadLine());
    string url = "https://localhost:7199/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response=await client.GetAsync(url+"/GetByIdWeatherCity?id"+id);
        response.EnsureSuccessStatusCode();
        string responseBody=await response.Content.ReadAsStringAsync();
        JObject weatherCityObject=JObject.Parse(responseBody);
        string cityName = weatherCityObject["cityName"].ToString();
        string detail = weatherCityObject["detail"].ToString();
        string countryName = weatherCityObject["countryName"].ToString();
        decimal temp =decimal.Parse(weatherCityObject["temp"].ToString());
        Console.Write("Girmis oldugunuz idye gore bilgiler asagidadir!");
        Console.WriteLine();
        Console.WriteLine("Sehir: " + cityName + " Ulke: " + countryName + " Sicaklik: " + temp + "Detay"+detail);

    }
}


Console.Read();
#endregion