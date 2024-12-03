using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Lab8
{
    [Route("api/fox")]
    [ApiController]
    public class FoxController : ControllerBase
    {
        private readonly IFoxService _foxService;

        public FoxController(IFoxService foxService)
        {
            _foxService = foxService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fox>> GetAll()
        {
            try
            {
                return Ok(_foxService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fox with ID not found.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Fox> Get(int id)
        {
            try
            {
                return Ok(_foxService.Get(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fox with ID not found.");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(Fox fox)
        {
            try
            {
                _foxService.Add(fox);
                return CreatedAtAction(nameof(Get), new { id = fox.Id }, fox);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fox with ID not found.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            try
            {
                _foxService.Update(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fox with ID not found.");
            }
        }

        [HttpPut("love/{id}")]
        public IActionResult Love(int id)
        {
            try
            {
                _foxService.Love(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fox with ID not found.");
            }
        }

        [HttpPut("hate/{id}")]
        public IActionResult Hate(int id)
        {
            try
            {
                _foxService.Hate(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fox with ID not found.");
            }
        }
    }
}
