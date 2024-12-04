using Api_demo.Data;
using Api_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace Api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityRepository _cityRepository;
        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        [HttpGet]
        public IActionResult SelectAllCities()
        {
            var cities = _cityRepository.SelectAll();
            return Ok(cities);
        }
    }
}
