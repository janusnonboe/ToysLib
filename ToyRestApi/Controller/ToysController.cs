using Microsoft.AspNetCore.Mvc;

using ToysLib;

namespace ToyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToyController : Controller
    {
        private ToysRepository _toyRepository;
        public ToyController(ToysRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAll")]

        public ActionResult<List<Toy>> GetAll()
        {
            List<Toy> result = _toyRepository.GetAll();

            if (result.Count < 1) { return NoContent(); }
            return Ok(result);


        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Id")]
        public ActionResult<List<Toy>> GetById(int id)
        {
            Toy? result = _toyRepository.GetById(id);
            if(result == null) 
            { 
                return NoContent(); 
            }

            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("Add")]
        public ActionResult<Toy> Post([FromBody]Toy newToy) 
        {
           
            try
            {
                Toy createToy = _toyRepository.Add(newToy);
                return Created($"api/Toy/{createToy.model}", createToy);
            }
            catch(ArgumentNullException ex) { return BadRequest(ex.Message); }
            catch(ArgumentOutOfRangeException ex) { return BadRequest(ex.Message); }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("Delete{id}")]
        public ActionResult Delete(int id) 
        {
            try
            {
                Toy? Delete = _toyRepository.Delete(id);
                if (Delete == null)
                {
                    return NotFound();
                }
            }
            catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
            catch (ArgumentOutOfRangeException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
            return Ok(new Toy());
        }
    }
}
