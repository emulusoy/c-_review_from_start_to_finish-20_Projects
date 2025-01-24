using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Different20P_3_StatisticProject_EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Different20P_3_Statistic_DbEntities data=new Different20P_3_Statistic_DbEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Ilk panel toplam catekori
            label2.Text = data.TblCategory.Count().ToString();

            //toplam urun
            label3.Text = data.TblProduct.Count().ToString();

            //toplam musteri
            label5.Text = data.TblCustomer.Count().ToString();
            //siparis sayisi
            label7.Text = data.TblOrder.Count().ToString();

            //toplam stok
            label9.Text= data.TblProduct.Sum(x=>x.ProductStock).ToString();

            //oRTALAMA URUN FIYATI

            label19.Text=data.TblProduct.Average(x=>x.ProductPrice).ToString();

            //TOPLAM MEYVE sayisi
            label17.Text= data.TblProduct.Where(x=>x.CategoryId==1).Sum(y=>y.ProductStock).ToString();

            //kOLA SATILIRSA NE KAZANIRIM
            var stock = data.TblProduct.Where(x => x.ProductName == "Kola").Select(y=>y.ProductStock).FirstOrDefault();
            var price= data.TblProduct.Where(x => x.ProductName == "Kola").Select(y => y.ProductPrice).FirstOrDefault();
            label13.Text=(stock*price).ToString();

            //STOK SAYISI 100DEN KUCUKLERI GETIR
            var values = data.TblProduct.Where(x => x.ProductStock < 100).Count();
            label15.Text = values.ToString();

            //AKTIF(TRUE) SEBZE SAYISI stok toplami

            //var values2=data.TblProduct.Where(x=>x.ProductStatus== true && x.CategoryId==2).Sum(y=>y.ProductStock).ToString();
            //bunun birde category idden getirelim
            
            //id yi disaridan da cekebiliriz
            //int id2 = data.TblCategory.Where(x => x.CategoryName == "Sebze").Select(y => y.CategoryId).FirstOrDefault();
            var values2=data.TblProduct.Where(x=>x.ProductStatus== true && x.CategoryId==(data.TblCategory.Where(z => z.CategoryName == "Sebze").Select(y => y.CategoryId).FirstOrDefault())).Sum(y=>y.ProductStock);
            label11.Text=values2.ToString();

            //TRRABZONDAN yapilan toplam siparis
           // label29.Text = data.TblCustomer.Where(x => x.CustomerCity == "trabzon").Count().ToString();
            //sql de query yazip onu kullanmak
            var querygetir = data.Database.SqlQuery<int>("SELECT Count(*) FROM TblOrder WHERE CustomerId IN (SELECT CustomerId FROM TblCustomer WHERE CustomerCountry = 'turkey')").FirstOrDefault();
            label29.Text = querygetir.ToString();

            //ENtity framework kullanarak yapalim turkiyeden gelen siparisler EF  yazip onu kullanmak
            var turkeyCustomer = data.TblCustomer.Where(x => x.CustomerCountry == "turkey").Select(y => y.CustomerId).ToList();
            var orderCountFromTurkeyWithEF=data.TblOrder.Count(z=>turkeyCustomer.Contains(z.CustomerId.Value));
            //count un icine yazdigimiz sql de ki IN metoduna esdegerdir contains = IN
            label27.Text=orderCountFromTurkeyWithEF.ToString();

            //mEYVe siparislerini getir toplam kazancini  SIPARISLER ICINDE MEYVE OLAN URUNLERIN TOPLAM SATIS FIYATI SQL QUERY ILE

            var fruitQuery = data.Database.SqlQuery<decimal>("Select Sum(o.UnitPrice) From TblOrder o Join TblProduct p On o.ProductId=p.ProductId Join TblCategory c On p.CategoryId=c.CategoryId Where c.CategoryName='Meyve'").FirstOrDefault();
            label23.Text = fruitQuery.ToString();
            //yukaridaki soruguyu ef ile yapalim
            var fruitEF = (from o in data.TblOrder
                           join p in data.TblProduct on o.ProductId equals p.ProductId
                           join c in data.TblCategory on p.CategoryId equals c.CategoryId
                           where c.CategoryName == "Meyve"
                           select o.UnitPrice).Sum();
            label25.Text=fruitEF.ToString();
            //SON EKLENEN URUnU GETIRDIK
            var lastProduct = data.TblProduct.OrderByDescending(x => x.ProductId).ToList().Select(y => y.ProductName).First();//TERSTEN SIRALAYIP ILKINI GETIRDIM NEDEN DIYE SORMAYIN AHAJAJAHJAHJ
            label21.Text=lastProduct.ToString();
            //SON EKLENEN URUUN KATEGORISINI GETIRDIK
            var lastProductCategoryId =data.TblProduct.OrderByDescending(x => x.ProductId).Select(y => y.CategoryId).FirstOrDefault();
            var lastProductCategoryName=data.TblCategory.Where(x=>x.CategoryId==lastProductCategoryId).Select(y => y.CategoryName).FirstOrDefault();
            label39.Text=lastProductCategoryName.ToString();

            //AKTIF URUN SAYISI
            var active = data.TblProduct.Where(x => x.ProductStatus == true).Count();
            label37.Text=active.ToString();

            //KOLADAN TOPLAM KAZANC 
            var stockKola = data.TblProduct.Where(x => x.ProductName=="Kola").Select(y=>y.ProductStock).FirstOrDefault();
            var priceCola= data.TblProduct.Where(x => x.ProductName == "Kola").Select(y => y.ProductPrice).FirstOrDefault();
            var total=stockKola*priceCola;
            label33.Text = total.ToString();


            //SON siparis veren musteri LABEL35

            var lastCustomer = data.TblOrder.OrderByDescending(x => x.OrderId).Select(y => y.CustomerId).FirstOrDefault();
            var findCustomer=data.TblCustomer.Where(x=>x.CustomerId==lastCustomer).Select(y => y.CustomerName).FirstOrDefault();
            label35.Text=findCustomer.ToString();

            //KAC FARKLI ULKE VAR

            var differentCountry = data.TblCustomer.Select(x => x.CustomerCountry).Distinct().Count();
            label31.Text=differentCountry.ToString();
        }
    }
}
