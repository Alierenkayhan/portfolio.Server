namespace portfolio.Server.Services.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.Connection);
            var mongoDb = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _collection = mongoDb.GetCollection<T>(typeof(T).Name);
        }

        public async Task CreateAsync(T newItem) => await _collection.InsertOneAsync(newItem);

        public async Task<List<T>> GetAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetAsync(Guid id) =>
            await _collection.Find(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id.ToString()))).FirstOrDefaultAsync();

        public async Task RemoveAsync(Guid id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id.ToString())));

        public async Task UpdateAsync(Guid id, T updateItem) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id.ToString())), updateItem);
    }
}
