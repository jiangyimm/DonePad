﻿using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DonePadClient.MongoDb
{
    public class MongoDbProvide
    {
        static MongoDbProvide()
        {
            Init();
        }
        private static MongoClient _mongoClient;
        private static IMongoDatabase _db;
        private static bool _connected;

        private static void Init()
        {
            if (_connected)
                return;
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _db = _mongoClient.GetDatabase("ToDoDebug");

            _connected = true;
        }

        //private static void CreateTables()
        //{
        //    foreach (var name in Enum.GetNames(typeof(LogType)))
        //    {
        //        try
        //        {
        //            _db.CreateCollection(name);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //        }
        //    }
        //}

        public static void Insert<T>(T info)
        {
            
            var col = _db.GetCollection<T>(nameof(T));
            col.InsertOne(info);
        }

        public static List<T> QueryList<T>()
        {
            

            var col = _db.GetCollection<T>(nameof(T));
            return col.AsQueryable().ToList();
        }

        //public static void Update<T>(T info)
        //{
        //    var col = _db.GetCollection<T>(nameof(T));
        //    return col.UpdateOne(a => a.StudentId == studentId, Builders<Student>.Update.Set(a => a.IQ, 90));
        //}
    }
}