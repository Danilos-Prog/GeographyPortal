using GeographyPortal.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GeographyPortal.Services
{
    public interface ITestService
    {
        public Task<ICollection<Test>> GetAsync();

        public Task<Test?> GetAsync(string id);

        public Task CreateAsync(Test newExercise);

        public Task UpdateAsync(string id, Test updatedExercise);

        public Task RemoveAsync(string id);
    }
}
