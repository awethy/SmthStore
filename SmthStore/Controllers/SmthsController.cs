using Microsoft.AspNetCore.Mvc;
using SmthStore.Application.Services;
using SmthStore.Contracts;

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
    }
}
