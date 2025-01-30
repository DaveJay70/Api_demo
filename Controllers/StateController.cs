using Api_demo.Data;
using Api_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        #region Connection
        private readonly StateRepository _stateRepository;
        public StateController(StateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        #endregion

        #region Get
        [HttpGet]
        public IActionResult SelectAllState()
        {
            var states = _stateRepository.SelectAll();
            return Ok(states);
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public IActionResult GetStateById(int id)
        {
            var state = _stateRepository.SelectByPK(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteState(int id)
        {
            var isDeleted = _stateRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region Post
        [HttpPost]
        public IActionResult InsertState([FromBody] StateModel state)
        {
            if (state == null)
            {
                return BadRequest();
            }
            bool isInserted = _stateRepository.InsertState(state);
            if (isInserted)
            {
                return Ok(new { Message = "State Inserted" });
            }
            return StatusCode(500, "An error occured while inserting the State");
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public IActionResult UpdateState(int id, [FromBody] StateModel state)
        {
            if (state == null || id != state.StateID)
            {
                return BadRequest();
            }
            var isUpdated = _stateRepository.UpdateState(state);
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
            var countries = _stateRepository.GetCountries();
            if (!countries.Any())
            {
                return NotFound("No Countries Found");
            }
            return Ok(countries);
        }
        #endregion
    }
}
