using GeographyPortal.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GeographyPortal.Repositories.Impl
{
    public class TestRepository : ITestRepository
    {
        private readonly IMongoCollection<Test> _testCollection;

        public TestRepository(IOptions<PortalGeographyMongoDBSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _testCollection = mongoDatabase.GetCollection<Test>(
                portalGeographyMongoDBSettings.Value.TestCollectionName);
        }

        public async Task CreateAsync(Test newTest)
        {
            await _testCollection.InsertOneAsync(newTest);
        }

        public async Task<ICollection<Test>> GetAsync()
        {
            return await _testCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Test?> GetAsync(Guid id)
        {
            return await _testCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Guid id, Test updatedTest)
        {
            await _testCollection.ReplaceOneAsync(x => x.Id == id, updatedTest);
        }
    }
}
