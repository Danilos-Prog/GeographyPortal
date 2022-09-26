using GeographyPortal.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GeographyPortal.Services
{
    /// <summary>
    /// Service for test
    /// </summary>
    public interface ITestService
    {
        /// <summary>
        /// Get all tests
        /// </summary>
        /// <returns>Collection of tests</returns>
        public Task<ICollection<Test>> GetAsync();

        /// <summary>
        /// Get one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>One test</returns>
        public Task<Test> GetAsync(Guid id);

        /// <summary>
        /// Create one exercise
        /// </summary>
        /// <param name="newExercise">New exercise</param>
        /// <returns></returns>
        public Task CreateAsync(Test newExercise);

        /// <summary>
        /// Update one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedExercise">Updated Exercise</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, Test updatedExercise);

        /// <summary>
        /// Remove one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
