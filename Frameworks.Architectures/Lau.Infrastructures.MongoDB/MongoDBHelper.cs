using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using System.Threading;

namespace Lau.Infrastructures.MongoDB
{
    public static class MongoDBHelper
    {
        public static readonly string connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
        public static readonly string database = ConfigurationManager.AppSettings["MongoDBDatabase"];

        public static Test1()
        {
            //https://github.com/mongolab/mongodb-driver-examples/blob/master/c%23/CSharpSimpleExample.cs
            //https://github.com/mongodb/mongo-csharp-driver


            //增删改查 批量，单个  同步，异步
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<BsonDocument>("bar");

            collection.InsertOneAsync(new BsonDocument("Name", "Jack"),null);
            
            //await collection.InsertOneAsync(new BsonDocument("Name", "Jack"));

            //var list = await collection.Find(new BsonDocument("Name", "Jack"))
            //    .ToListAsync();

            //foreach (var document in list)
            //{
            //   // Console.WriteLine(document["Name"]);
            //}
        }

        public static IMongoCollection<T> GetCollection<T>(string collectionName, out Mongo mongodb) where T : class
        {
            Mongo mongo = new Mongo(connectionString);

            mongo.Connect();
            IMongoDatabase db = mongo.GetDatabase(database);
            IMongoCollection<T> categories = db.GetCollection<T>(collectionName);
            mongodb = mongo;
            return categories;

        }

        ///// <summary>
        ///// 查询
        ///// </summary>
        ///// <param name="connectionString"></param>
        ///// <param name="databaseName"></param>
        ///// <param name="collectionName"></param>
        ///// <param name="query"></param>
        ///// <returns></returns>
        //public static MongoCursor<T> Query<T>(string connectionString, string databaseName,
        //    string collectionName, IMongoQuery query)
        //{
        //    //定义Mongo服务  
        //    var client = new MongoClient(connectionString);
        //    client.GetDatabase(databaseName);
        //    MongoServer server = client.GetServer();
        //    //获取databaseName对应的数据库，不存在则自动创建  
        //    MongoDatabase mongoDatabase = server.GetDatabase(databaseName);
        //    MongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);
        //    try
        //    {
        //        if (query == null)
        //            return collection.FindAll();
        //        else
        //            return collection.Find(query);
        //    }
        //    finally
        //    {
        //        server.Disconnect();
        //    }
        //}

        ///// <summary>  
        ///// 新增  
        ///// </summary>   
        //public static Boolean Insert<T>(string connectionString, string databaseName, string collectionName, T document)
        //{
        //    var client = new MongoClient(connectionString);
        //    MongoServer server = client.GetServer();

        //    MongoDatabase mongoDatabase = server.GetDatabase(databaseName);
        //    MongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);
        //    try
        //    {
        //        collection.Insert(document);
        //        server.Disconnect();
        //        return true;
        //    }
        //    catch
        //    {
        //        server.Disconnect();
        //        return false;
        //    }
        //}


        ///// <summary>  
        ///// 批量新增  
        ///// </summary>   
        //public static Boolean InsertBatch<T>(string connectionString, string databaseName, string collectionName, List<T> documents)
        //{
        //    var client = new MongoClient(connectionString);
        //    MongoServer server = client.GetServer();

        //    MongoDatabase mongoDatabase = server.GetDatabase(databaseName);
        //    MongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);
        //    try
        //    {
        //        collection.InsertBatch(documents);
        //        server.Disconnect();
        //        return true;
        //    }
        //    catch
        //    {
        //        server.Disconnect();
        //        return false;
        //    }
        //}

        ///// <summary>  
        ///// 修改  
        ///// </summary>    
        //public static Boolean Update(string connectionString, string databaseName, String collectionName,
        //    IMongoQuery query, IMongoUpdate new_doc)
        //{
        //    var client = new MongoClient(connectionString);
        //    MongoServer server = client.GetServer();
        //    MongoDatabase mongoDatabase = server.GetDatabase(databaseName);
        //    MongoCollection<BsonDocument> collection = mongoDatabase.GetCollection<BsonDocument>(collectionName);
        //    try
        //    {
        //        collection.Update(query, new_doc);
        //        server.Disconnect();
        //        return true;
        //    }
        //    catch
        //    {
        //        server.Disconnect();
        //        return false;
        //    }
        //}

        ///// <summary>  
        ///// 移除  
        ///// </summary>  
        //public static Boolean Remove(string connectionString, string databaseName, String collectionName, IMongoQuery query)
        //{
        //    var client = new MongoClient(connectionString);
        //    MongoServer server = client.GetServer();
        //    MongoDatabase mongoDatabase = server.GetDatabase(databaseName);
        //    MongoCollection<BsonDocument> collection = mongoDatabase.GetCollection<BsonDocument>(collectionName);
        //    try
        //    {
        //        collection.Remove(query);
        //        server.Disconnect();
        //        return true;
        //    }
        //    catch
        //    {
        //        server.Disconnect();
        //        return false;
        //    }
        //}
    }
}
