using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //var settings = new MongoClientSettings { };
            // var connctionString = "mongodb://localhost:27017";
            //var client = new MongoClient(connctionString);
            //var db= client.GetDatabase("test");
            //var col = db.GetCollection<BsonDocument>("people");

            //var doc = new BsonDocument 
            //{ 
            //     {"name","Jones"}
            //};
            //doc.Add("age",32);
            //doc["profession"] = "hacker";

            //var nestedArray = new BsonArray();
            //nestedArray.Add( new BsonDocument("color","red") );

            //doc.Add("array", nestedArray);

            //Console.WriteLine(doc["array"][0]["color"]);
            //Console.WriteLine(doc);


            var client = new MongoClient();
            var db = client.GetDatabase("test");
            // var col = db.GetCollection<BsonDocument>("people");
            //  var col = db.GetCollection<Person >("people");

            //  var doc = new BsonDocument 
            // { 
            //      {"Name","Smith"},
            //      {"Age",30},
            //      {"Profession","Hacker"},
            // };
            //------INSERT -----
            ////  await col.InsertOneAsync(doc);

            //  var doc2 = new BsonDocument 
            // { 
            //      {"Name","Hugo"},

            // };
            //  await col.InsertManyAsync(new [] {doc,doc2});

            //var doc = new Person
            //{
            //    Name= "Jones",
            //    Age= 40,
            //    Profession = "Student",
            //};

            // await col.InsertOneAsync(doc);


            //------FIND -----
            //---*1
            //using (var cursor = await col.Find(new BsonDocument()).ToCursorAsync())
            //{
            //    while (await cursor.MoveNextAsync())
            //    {
            //        foreach (var doc in cursor.Current)
            //        {
            //            Console.WriteLine(doc);
            //        }
            //    }
            //}
            //---*2
            //var list = await col.Find(new BsonDocument()).ToListAsync();
            //foreach (var doc in list)
            //{
            //      Console.WriteLine(doc);
            //}
            //---*3
            //await col.Find(new BsonDocument()).ForEachAsync(doc => Console.WriteLine(doc));
            //------FILTERS -----
            ////---*1
            //var filter = new BsonDocument("Name", "Smith");
            //var list = await col.Find(filter).ToListAsync();
            //foreach (var doc in list)
            //{
            //    Console.WriteLine(doc);
            //}
            //---*2
            // var filter = new BsonDocument("$and", new BsonArray{

            //     new BsonDocument("Age", new BsonDocument("$lt", 31)),
            //     new BsonDocument("Name", "Smith"),
            //  });
            //var list = await col.Find(filter).ToListAsync();

            // foreach (var doc in list)
            // {
            //     Console.WriteLine(doc);
            // }
            //---*3
            //var builder = Builders<BsonDocument>.Filter;
            //var filter =builder.And(builder.Lt("Age", 31) &  !builder.Eq("Name","Jones")); // & | 
            ////var filter = new BsonDocument("$and", new BsonArray{

            ////    new BsonDocument("Age", new BsonDocument("$lt", 31)),
            ////    new BsonDocument("Name", "Smith"),
            //// });
            //var list = await col.Find(filter).ToListAsync();

            //foreach (var doc in list)
            //{
            //    Console.WriteLine(doc);
            //}
            //---*4 Com objectos
            //var builder = Builders<Person>.Filter;
            ////--*1 // var filter = builder.And(builder.Lt("Age", 31) & !builder.Eq("Name", "Jones")); 
            ////--*2 // var filter = builder.Lt(x => x.Age ,31 ) & !builder.Eq(x=>x.Name,"Jones");            
            ////--*1*2// var list = await col.Find(filter).ToListAsync();
            //var list = await col.Find(x => x.Age < 31 & x.Name != "Jones").ToListAsync();

            //foreach (var doc in list)
            //{
            //    Console.WriteLine(doc);
            //}

            //------SKIP LIMIT AND SORT  -----
            //var list = await col.Find(new BsonDocument())
            //    .Skip(1)
            //    .Limit(1)
            //    .ToListAsync();
            // --*Sort
            //var list = await col.Find(new BsonDocument())
            //  .Sort("{Age:1}")               
            //  .ToListAsync();
            //var list = await col.Find(new BsonDocument())
            // .Sort(new BsonDocument("Age",1))
            // .ToListAsync();

            //var list = await col.Find(new BsonDocument())
            // .Sort(Builders<BsonDocument>.Sort.Ascending("Age").Descending("Name"))
            // .ToListAsync();

            // var list = await col.Find(new BsonDocument())
            //.SortBy(x => x.Age)
            //.ThenByDescending(x=>x.Name)
            //.ToListAsync();

            //foreach (var doc in list)
            //{
            //    Console.WriteLine(doc);
            //}


            //------ FIND WITH PROJECTIONS  -----

            //var list = await col.Find(new BsonDocument())
            //    .Project("{Name:1, _id:0}")
            //    .ToListAsync();

            //var list = await col.Find(new BsonDocument())
            //    .Project(new BsonDocument("Name",1).Add("_id",0))
            //    .ToListAsync();

            //var list = await col.Find(new BsonDocument())
            // .Project(Builders<BsonDocument>.Projection.Include("Name").Exclude("_id"))
            // .ToListAsync();

            //var list = await col.Find(new BsonDocument())
            //.Project(Builders<Person>.Projection.Include("Name").Exclude("_id"))
            //.ToListAsync();

            // var list = await col.Find(new BsonDocument())
            //.Project(x => x.Name)
            //.ToListAsync();

            //var list = await col.Find(new BsonDocument())
            //.Project(x => new { x.Name, CalcAge = x.Age + 10 })
            //.ToListAsync();

            // foreach (var doc in list)
            // {
            //     Console.WriteLine(doc);
            // }
            
            //------REPLACE UPDATING  -----
            var col = db.GetCollection<BsonDocument>("widgets");
           // var col = db.GetCollection<Widget>("widgets");
            //await db.DropCollectionAsync("widgets");
            //var docs = Enumerable.Range(0, 10).Select(i => new BsonDocument("_id", i).Add("x", i));
            //await col.InsertManyAsync(docs);

            //var result = await col.ReplaceOneAsync(
            //    new BsonDocument("x", 10),
            //    new BsonDocument("x", 30),
            //    new UpdateOptions { IsUpsert= true});
            //*--Updating
            //var result = await col.UpdateOneAsync(
            //    Builders<BsonDocument>.Filter.Eq("x",30),
            //  new BsonDocument("$inc", new BsonDocument("x",10)));

            //var result = await col.UpdateOneAsync(
            //  Builders<BsonDocument>.Filter.Eq("x", 40),
            // Builders<BsonDocument>.Update.Inc("x", 5));

            //await col.Find(new BsonDocument())
            //            .ForEachAsync(x => Console.WriteLine(x));


            //------DELETE  -----
           //// var result = await col.DeleteOneAsync(x => x.X > 5);

            // ------FindOneAndUpdate, FindOneAndReplace, FindOneAndDelete------
            //var result = await col.UpdateOneAsync(
            //x=> x.X > 5,     
            //    Builders<Widget>.Update.Inc(x=> x.X, 1));


            //var result = await col.FindOneAndUpdateAsync<Widget>(
            //   x => x.X > 5,
            //   Builders<Widget>.Update.Inc(x => x.X, 1),
            //   new FindOneAndUpdateOptions<Widget, Widget>
            //   {
            //       ReturnDocument = ReturnDocument.After,
            //       Sort = Builders<Widget>.Sort.Descending(x=> x.X)
            //   }
            //   );

            //var result = await col.FindOneAndDeleteAsync<Widget>(
            //  x => x.X > 5,             
            //  new FindOneAndDeleteOptions<Widget, Widget>
            //  {  
            //      Sort = Builders<Widget>.Sort.Descending(x => x.X)
            //  }
            //  );

            //await col.Find(new BsonDocument())
            //            .ForEachAsync(x => Console.WriteLine(x));

            //------BulkWrite  ----- enviar varios docs de uma vez so para a BD

            //var result = await col.BulkWriteAsync( new WriteModel<BsonDocument>[]
            //{
            //    new DeleteOneModel<BsonDocument>("{x:5}"),
            //    new DeleteOneModel<BsonDocument>("{x:7}")
            //});

            var result = await col.BulkWriteAsync(new WriteModel<BsonDocument>[]
            {
                new DeleteOneModel<BsonDocument>("{x:5}"),
                new DeleteOneModel<BsonDocument>("{x:7}"),
                new UpdateManyModel<BsonDocument>("{x:{$lt:7 }}","{$inc:{x:1}}")
            });




            await col.Find(new BsonDocument())
                        .ForEachAsync(x => Console.WriteLine(x));

        }

        private class Person
        {
            public ObjectId Id { get; set; }
            public String Name { get; set; }
            public int Age { get; set; }
            public String Profession { get; set; }

            public override string ToString()
            {
                return string.Format("Id: {0}, Name: \"{1}\", Age: {2}, Profession: \"{3}\",", Id, Name, Age, Profession);
            }
        }

        private class Widget
        {
            public int Id { get; set; }

            //[BsonElement("x")]
            [MongoDB.Bson.Serialization.Attributes.BsonElement("x")]
            public int X { get; set; }          
         

            public override string ToString()
            {
                return string.Format("Id: {0}, x: {1}", Id, X);
            }
        }
    }
}
