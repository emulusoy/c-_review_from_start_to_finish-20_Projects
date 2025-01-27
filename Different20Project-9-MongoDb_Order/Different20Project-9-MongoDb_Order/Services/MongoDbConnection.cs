using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Different20Project_9_MongoDb_Order.Services
{
    public class MongoDbConnection
    {
        private IMongoDatabase _database;

        public MongoDbConnection()//benim icin nesne donusturecek! constructur
        {
            var client = new MongoClient("mongodb://localhost:27017/"); //Buradan ayaga kal demek!
            _database = client.GetDatabase("DifferentProject20-9-DB");//Burada da olustur bir tane database ismi de su olsun diyoruz
        }
        public IMongoCollection<BsonDocument> GetOrdersCollections()
        {
            //bson document metot ve fonksiyon ayarlamak icin kullanilan bir format! bir tane koleksiyon olusturduk tablo olusturmak icin

            return _database.GetCollection<BsonDocument>("Orders");//burada da olusturdugumuz tablonun ismini belirleriz ya da koleksiyon olusturdugumuz koleksitoyn
        }
    }
}
