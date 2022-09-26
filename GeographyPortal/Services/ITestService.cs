using GeographyPortal.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GeographyPortal.Services
{
    public interface ITestService
    {
        public Task<ICollection<Test>> GetAsync();

        public Task<Test> GetAsync(Guid id);

        public Task CreateAsync(Test newExercise);

        public Task UpdateAsync(Guid id, Test updatedExercise);

        public Task RemoveAsync(Guid id);
    }
}
