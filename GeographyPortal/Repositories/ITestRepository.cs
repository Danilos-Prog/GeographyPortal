using GeographyPortal.Models;

namespace GeographyPortal.Repositories
{
    /// <summary>
    /// The repository with tests
    /// </summary>
    public interface ITestRepository
    {
        /// <summary>
        /// Get all of tests
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
        /// Create one test
        /// </summary>
        /// <param name="newTest">New test</param>
        /// <returns></returns>
        public Task CreateAsync(Test newTest);

        /// <summary>
        /// Update one test by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedTest">Updated test</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, Test updatedTest);

        /// <summary>
        /// Remove one test by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
