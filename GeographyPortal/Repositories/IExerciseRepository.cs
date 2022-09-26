using GeographyPortal.Models;

namespace GeographyPortal.Repositories
{
    public interface IExerciseRepository
    {
        public Task<ICollection<Exercise>> GetAsync();

        public Task<Exercise?> GetAsync(Guid id);

        public Task CreateAsync(Exercise newExercise);

        public Task UpdateAsync(Guid id, Exercise updatedExercise);

        public Task RemoveAsync(Guid id);
    }
}
