using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Different20Project_9_MongoDb_Order.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Different20Project_9_MongoDb_Order.Services
{
    public class OrderOperation
    {
        public void AddOrder(Order order)
        {
            var connection = new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollections();
            var document = new BsonDocument
            {
                
                { "CustomerName", order.CustomerName },
                { "District", order.District },
                { "City", order.City },
                { "TotalPrice", order.TotalPrice }
            };
            orderCollection.InsertOneAsync(document);
        }
        public List<Order> ListOrder()
        {
            var connection = new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollections();

            var orders = orderCollection.Find(new BsonDocument()).ToList();

            List<Order> orderList = new List<Order>();
            foreach (var order in orders)
            {
                orderList.Add(new Order
                {
                    City = order["City"].ToString(),
                    CustomerName = order["CustomerName"].ToString(),
                    District = order["District"].ToString(),
                    TotalPrice =decimal.Parse(order["TotalPrice"].ToString()),
                    OrderId = order["_id"].ToString(),
                    
                });   
 
            }
            return orderList;
        }
        public void DeleteOrder(string orderId)
        {
            var connection = new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollections();
            var filter = Builders<BsonDocument>.Filter.Eq("_id" ,ObjectId.Parse(orderId));//buradaki Eq esit mi diye soruyor! filtrele ve bul esit mi bak
            orderCollection.DeleteOneAsync(filter);
        }
        public void UpdateOrder(Order order)
        {
            var connection = new MongoDbConnection();   
            var orderCollection = connection.GetOrdersCollections();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(order.OrderId));
            var updatedValue = Builders<BsonDocument>.Update
                .Set("CustomerName", order.CustomerName)
                .Set("District", order.District)
                .Set("City", order.City)
                .Set("TotalPrice", order.TotalPrice);
            orderCollection.UpdateOne(filter, updatedValue);
        }
        public Order GetOrderById(string orderId)
        {
            var connection=new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollections();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(orderId));
            var result = orderCollection.Find(filter).FirstOrDefault();
            if (result != null)
            {
                return new Order
                {
                    City = result["City"].ToString(),
                    CustomerName = result["CustomerName"].ToString(),
                    District = result["District"].ToString(),
                    TotalPrice = decimal.Parse(result["TotalPrice"].ToString()),
                    OrderId = orderId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
