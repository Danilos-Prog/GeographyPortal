using GeographyPortal.Models;
using GeographyPortal.Repositories;

namespace GeographyPortal.Services.Impl
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task CreateAsync(Test newExercise)
        {
            await _testRepository.CreateAsync(newExercise);
        }

        public async Task<ICollection<Test>> GetAsync()
        {
            return await _testRepository.GetAsync();
        }

        public async Task<Test> GetAsync(Guid id)
        {
            return await GetAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, Test updatedExercise)
        {
            await _testRepository.UpdateAsync(id, updatedExercise);
        }
    }
}
