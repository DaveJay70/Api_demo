using Api_demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryRepository _countryRepository;
        public CountryController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        public IActionResult SelectAllCountry()
        {
            var country = _countryRepository.SelectAll();
            return Ok(country);
        }
    }
}
