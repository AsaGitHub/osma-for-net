using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using System.Threading;
using System.Text;
using System.Security.Cryptography;

namespace Lau.Infrastructures.MongoDB
{
    public static class MongoDBHelper
    {
        public static readonly string connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
        public static readonly string database = ConfigurationManager.AppSettings["MongoDBDatabase"];

        public static void test1()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<BsonDocument>("bar");

            await collection.InsertOneAsync(new BsonDocument("Name", "Jack"),);

            //var list = await collection.Find(new BsonDocument("Name", "Jack"))
            //    .ToListAsync();

            //foreach (var document in list)
            //{
            //    Console.WriteLine(document["Name"]);
            //}
        }

        public static string ToMD5String(this string value)
        {
            return GetMD5(string.Concat(GetMD5(value), "KupartsY"));//增加加密复杂度
        }

        internal static string GetMD5(string str)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            return sb.ToString();
        }

        public static void Test1()
        {

            Console.WriteLine(ToMD5String("123456"));
            Console.ReadLine();

            //https://github.com/mongolab/mongodb-driver-examples/blob/master/c%23/CSharpSimpleExample.cs
            //https://github.com/mongodb/mongo-csharp-driver


            ////增删改查 批量，单个  同步，异步
            //var client = new MongoClient("mongodb://localhost:27017");

            ////Use the MongoClient to access the server
            //var _database = client.GetDatabase("foo");


            //var collection = database.GetCollection<BsonDocument>("bar");

            //collection.InsertOneAsync(new BsonDocument("Name", "Jack")).a;
            
            //await collection.InsertOneAsync(new BsonDocument("Name", "Jack"));

            //var list = await collection.Find(new BsonDocument("Name", "Jack"))
            //    .ToListAsync();

            //foreach (var document in list)
            //{
            //   // Console.WriteLine(document["Name"]);
            //}
        }


    }
}
