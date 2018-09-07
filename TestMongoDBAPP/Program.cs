using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;

namespace TestMongoDBAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employees> employees = new List<Employees>();

            string connectionString = ConfigurationSettings.AppSettings["connectionString"];

            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("company");
            //IMongoCollection<Employees> employeeList = database.GetCollection<Employees>("employees");

            //employeeList.InsertOneAsync(new Employees {Name="Rakesh",Age=23,Salary=4900,EmailId="rakesh@gmail.com"});
           
            var employeeList = database.GetCollection<BsonDocument>("employees");

            var doc = new BsonDocument{
                {"name","Rakesh"},
                {"age",30},
                {"salary",9700},
                {"emailid","rakesh@gmail.com"}
            };

            employeeList.InsertOneAsync(doc);
            Console.WriteLine("Record Inserted Successfully");
          //  employeeList.Find(new BsonDocument()).ForEachAsync(X => Console.WriteLine(X));
            Console.ReadLine();
        }
    }
}
