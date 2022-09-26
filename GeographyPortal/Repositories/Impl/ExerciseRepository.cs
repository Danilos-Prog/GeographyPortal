using GeographyPortal.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GeographyPortal.Repositories.Impl
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IMongoCollection<Exercise> _exerciseCollection;

        public ExerciseRepository(IOptions<PortalGeographyMongoDBSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _exerciseCollection = mongoDatabase.GetCollection<Exercise>(
                portalGeographyMongoDBSettings.Value.ExerciseCollectionName);
        }

        public async Task<ICollection<Exercise>> GetAsync()
        {
            return await _exerciseCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Exercise?> GetAsync(Guid id)
        {
            return await _exerciseCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Exercise newExercise)
        {
            await _exerciseCollection.InsertOneAsync(newExercise);
        }

        public async Task UpdateAsync(Guid id, Exercise updatedExercise)
        {
            await _exerciseCollection.ReplaceOneAsync(x => x.Id == id, updatedExercise);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _exerciseCollection.DeleteOneAsync(x => x.Id == id);
        }

    }
}
