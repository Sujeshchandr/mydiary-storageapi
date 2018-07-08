using MongoDB.Driver;
using MyDiary.StorageApi.DataAccess.MongoDb.Core;

namespace MyDiary.StorageApi.DataAccess.MongoDb.Expenses
{
    public abstract class MongoDbCollectionHelper<TDocument>: MyDiaryStorageMongoDbClient 
    {
        protected static IMongoCollection<TDocument> _collection;

        public MongoDbCollectionHelper(
               IMongoClient mongoClient,
               string collectionName,
               string dataBaseName) 
               :base(mongoClient, dataBaseName)
        {
            _collection = _mongoDatabase.GetCollection<TDocument>(collectionName);
        }

        public IMongoCollection<TDocument> Collection
        {
            get
            {
                return _collection;
            }
        }
    }
}
