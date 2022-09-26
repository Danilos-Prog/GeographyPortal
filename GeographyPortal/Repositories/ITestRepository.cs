using GeographyPortal.Models;

namespace GeographyPortal.Repositories
{
    public interface ITestRepository
    {
        public Task<ICollection<Test>> GetAsync();

        public Task<Test?> GetAsync(Guid id);

        public Task CreateAsync(Test newTest);

        public Task UpdateAsync(Guid id, Test updatedTest);

        public Task RemoveAsync(Guid id);
    }
}
