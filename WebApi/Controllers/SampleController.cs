using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService customerService)
        {
            _sampleService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSample(int id)
        {
            var customer = await _sampleService.GetSampleByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSample(Sample customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdSample = await _sampleService.AddSampleAsync(customer);
            return CreatedAtAction(nameof(GetSample), new { id = createdSample.Id }, createdSample);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSample(int id, Sample sample)
        {
            if (id != sample.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var updated = await _sampleService.UpdateSampleAsync(sample);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSample(int id)
        {
            var deleted = await _sampleService.DeleteSampleAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
