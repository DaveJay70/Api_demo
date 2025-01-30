using Api_demo.Data;
using Api_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Connection
        private readonly CountryRepository _countryRepository;
        public CountryController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        #endregion

        #region Get
        [HttpGet]
        public IActionResult SelectAllCountry()
        {
            var country = _countryRepository.SelectAll();
            return Ok(country);
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryRepository.SelectByPK(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var isDeleted = _countryRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region Post
        [HttpPost]
        public IActionResult InsertCountry([FromBody] CountryModel country)
        {
            if (country == null)
            {
                return BadRequest();
            }
            bool isInserted = _countryRepository.InsertCountry(country);
            if (isInserted)
            {
                return Ok(new { Message = "Country Inserted" });
            }
            return StatusCode(500, "An error occured while inserting the country");
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] CountryModel country)
        {
            if (country == null || id != country.CountryID)
            {
                return BadRequest();
            }
            var isUpdated = _countryRepository.UpdateCountry(country);
            if (!isUpdated)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

       
    }
}
