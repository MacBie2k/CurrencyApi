using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;
        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }
        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            var rate = _rateService.GetRateByCode(code);
            if(rate == null)
                return NotFound();
            return Ok(rate);
        }

    }
}
