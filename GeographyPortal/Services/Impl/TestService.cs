using GeographyPortal.Models;

namespace GeographyPortal.Services.Impl
{
    public class TestService : ITestService
    {
        public Task CreateAsync(Test newExercise)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Test>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Test?> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, Test updatedExercise)
        {
            throw new NotImplementedException();
        }
    }
}
