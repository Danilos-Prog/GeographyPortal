using GeographyPortal.Models;
using GeographyPortal.Repositories;
using MongoDB.Driver;

namespace GeographyPortal.Services.Impl
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task CreateAsync(Exercise newExercise)
        {
            await _exerciseRepository.CreateAsync(newExercise);
        }

        public async Task<ICollection<Exercise>> GetAsync()
        {
           return await _exerciseRepository.GetAsync();
        }

        public async Task<Exercise?> GetAsync(Guid id)
        {
            return await _exerciseRepository.GetAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _exerciseRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, Exercise updatedExercise)
        {
            await _exerciseRepository.UpdateAsync(id, updatedExercise);
        }
    }
}
