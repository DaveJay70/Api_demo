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
        #region Connection
        private readonly CityRepository _cityRepository;
        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        #endregion

        #region Get
        [HttpGet]
        public IActionResult SelectAllCities()
        {
            var cities = _cityRepository.SelectAll();
            return Ok(cities);
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var city = _cityRepository.SelectByPK(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var isDeleted = _cityRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region Post
        [HttpPost]
        public IActionResult InsertCity([FromBody] CityModel city)
        {
            if (city == null)
            {
                return BadRequest();
            }
            bool isInserted = _cityRepository.InsertCity(city);
            if (isInserted)
            {
                return Ok(new { Message = "City Inserted" });
            }
            return StatusCode(500, "An error occured while inserting the city");
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id,[FromBody] CityModel city)
        {
            if (city == null || id != city.CityID)
            {
                return BadRequest();
            }
            var isUpdated = _cityRepository.UpdateCity(city);
            if (!isUpdated)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region Countries
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var countries = _cityRepository.GetCountries();
            if(!countries.Any())
            {
                return NotFound("No Countries Found");
            }
            return Ok(countries);
        }
        #endregion

        #region GetStatesByCountryID
        [HttpGet("states/{CountryID}")]
        public IActionResult GetStatesByCountryID(int CountryID)
        {
            if (CountryID <= 0)
                return BadRequest("Invaild CountryID");
            var states = _cityRepository.GetStatesByCountryID(CountryID);
            if (!states.Any())
            {
                return NotFound("No States Found ");
            }
            return Ok(states);
        }
        #endregion
    }
}
