using DIO.Media.src.Entity;
using DIO.Media.src.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DIO.Media.src.Controller
{
    [ApiController]
    [Route("api/media")]
    public class MediaController : ControllerBase
    {
        private readonly MediaRepository _mediaRepository;

        public MediaController(MediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Entity.Media>>> GetAllMedia()
        {
            var media = await _mediaRepository.List();

            return Ok(media);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> GetById(int id)
        {
            var media = await _mediaRepository.FindById(id);

            if (media == null)
                return NotFound();

            return Ok(media);
        }

        [HttpGet("movie")]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var movie = await _mediaRepository.GetAllByTypeAsync<Movie>();
            
            return Ok(movie);
        }

        [HttpGet("serie")]
        public async Task<ActionResult<List<Serie>>> GetAllSeries()
        {
            var serie = await _mediaRepository.GetAllByTypeAsync<Serie>();

            return Ok(serie);
        }

        [HttpPost("movie")]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            return await AddMediaAsync(movie);
        }

        [HttpPost("serie")]
        public async Task<IActionResult> AddSerie([FromBody] Serie serie)
        {
            return await AddMediaAsync(serie);     
        }

        [HttpPut("movie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            return await UpdateMediaAsync(id, movie);        
        }

        [HttpPut("serie/{id}")]
        public async Task<IActionResult> UpdateSerie(int id, [FromBody] Serie serie)
        {
            return await UpdateMediaAsync(id, serie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia(int id)
        {
            try
            {
                await _mediaRepository.Delete(id);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the media.", error = ex.Message });
            }
        }

        private async Task<IActionResult> AddMediaAsync(Entity.Media media)
        {
            try
            {
                await _mediaRepository.Insert(media);

                return CreatedAtAction(nameof(GetAllMedia), new { id = media.Id }, media);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the media.", error = ex.Message });
            } 
        }

        private async Task<IActionResult> UpdateMediaAsync(int id, Entity.Media media)
        {
            if (media == null)
                return BadRequest(new { message = "Invalid meda data." });

            try
            {
                await _mediaRepository.Update(id, media);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the media.", error = ex.Message });
            }   
        }
    }
}