using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;

namespace MyDiary.StorageApi.DataAccess.MongoDb.Core
{
    public abstract class MyDiaryStorageMongoDbClient 
    {
        protected static IMongoClient _mongoClient;

        protected static IMongoDatabase _mongoDatabase;

        public MyDiaryStorageMongoDbClient(
               IMongoClient mongoClient,
               string dataBaseName)
        {
            if (mongoClient == null)
            {
                throw new ArgumentNullException();
            }

            _mongoClient = mongoClient;
            _mongoDatabase = _mongoClient.GetDatabase(dataBaseName);

            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);
        }
    }
}
