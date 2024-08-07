using Microsoft.AspNetCore.Mvc;
using SmthStore.Application.Services;
using SmthStore.Contracts;
using SmthStore.Core.Models;

namespace SmthStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmthsController : ControllerBase
    {
        private readonly ISmthsServices smthsServices;

        public SmthsController(ISmthsServices smthsServices)
        {
            this.smthsServices = smthsServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<SmthsRespons>>> GetSmths()
        {
            var smths = await smthsServices.GetAllSmths();

            var respons = smths.Select(b => new SmthsRespons(b.Id, b.Name, b.Description));

            return Ok(respons);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSmth([FromBody] SmthRequest smthRequest)
        {
            var (smth, error) = Smth.Create(
                Guid.NewGuid(),
                smthRequest.Name,
                smthRequest.Description);

            if (error != null)
            {
                return BadRequest(error);
            }

            var smthId = await smthsServices.CreateSmth(smth);

            return Ok(smthId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmth(Guid id, [FromBody] SmthRequest smthRequest)
        {
            var smthId = await smthsServices.UpdateSmth(id, smthRequest.Name, smthRequest.Description);

            return Ok(smthId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSmth(Guid id)
        {
            return Ok(await smthsServices.DeleteSmth(id));
        }
    }
}
