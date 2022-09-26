using GeographyPortal.Models;

namespace GeographyPortal.Repositories
{
    /// <summary>
    /// The repository with exercises
    /// </summary>
    public interface IExerciseRepository
    {
        /// <summary>
        /// Get all exercises
        /// </summary>
        /// <returns>Collection of exercises</returns>
        public Task<ICollection<Exercise>> GetAsync();

        /// <summary>
        /// Get one exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>One exercise</returns>
        public Task<Exercise> GetAsync(Guid id);

        /// <summary>
        /// Create one Exercise
        /// </summary>
        /// <param name="newExercise">New Exercise</param>
        /// <returns>
        /// </returns>
        public Task CreateAsync(Exercise newExercise);

        /// <summary>
        /// Update one Exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedExercise">Updated Exercise</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, Exercise updatedExercise);

        /// <summary>
        /// Remove one exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
