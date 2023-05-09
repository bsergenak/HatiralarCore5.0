using Hatiralar.Businees.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Hatiralar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cities = (await _cityService.GetAll()).Select(x => new
            {
                id = x.Id,
                name = x.Name,
                createDate = x.CreateDate
            }).ToList();
            return Ok(cities);
        }

    }
}
