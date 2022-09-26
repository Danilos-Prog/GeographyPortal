using Microsoft.AspNetCore.Mvc;
using GeographyPortal.Services;
using GeographyPortal.Models;

namespace GeographyPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller 
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService) 
        {
            _testService = testService; 
        }

        [HttpGet]
        public async Task<ICollection<Test>> Get()
        {
            return await _testService.GetAsync();
        }

        [HttpGet("{id:length(36)}")]
        public async Task<ActionResult<Test>> Get(Guid id)
        {
            var test = await _testService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Test newTest)
        {
            await _testService.CreateAsync(newTest);

            return CreatedAtAction(nameof(Get), new { id = newTest.Id }, newTest);
        }

        [HttpPut("{id:length(36)}")]
        public async Task<IActionResult> Update(Guid id, Test updatedTest)
        {
            var test = await _testService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            updatedTest.Id = test.Id;

            await _testService.UpdateAsync(id, test);

            return NoContent();
        }

        [HttpDelete("{id:length(36)}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var test = await _testService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            await _testService.RemoveAsync(id);

            return NoContent();
        }




    }
}
