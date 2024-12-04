using Api_demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateRepository _stateRepository;
        public StateController(StateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        [HttpGet]
        public IActionResult SelectAllState()
        {
            var states = _stateRepository.SelectAll();
            return Ok(states);
        }
    }
}
