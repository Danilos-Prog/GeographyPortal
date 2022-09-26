using GeographyPortal.Models;
using GeographyPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeographyPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<ICollection<Exercise>> Get()
        {
            return await _exerciseService.GetAsync();
        }

        [HttpGet("{id:length(36)}")]
        public async Task<ActionResult<Exercise?>> Get(Guid id)
        {
            var exercise = await _exerciseService.GetAsync(id);

            if (exercise is null)
            {
                return NotFound();
            }

            return exercise;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Exercise newExercise)
        {
            await _exerciseService.CreateAsync(newExercise);

            return CreatedAtAction(nameof(Get), new { id = newExercise.Id }, newExercise);
        }


        [HttpPut("{id:length(36)}")]
        public async Task<IActionResult> Update(Guid id, Exercise updatedExercise)
        {
            var exercise = await _exerciseService.GetAsync(id);

            if (exercise is null)
            {
                return NotFound();
            }

            updatedExercise.Id = exercise.Id;

            await _exerciseService.UpdateAsync(id, exercise);

            return NoContent();
        }

        [HttpDelete("{id:length(36)}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var exercise = await _exerciseService.GetAsync(id);

            if (exercise is null)
            {
                return NotFound();
            }

            await _exerciseService.RemoveAsync(id);

            return NoContent();
        }

    }
}
