using DIO.Media.src.Entity;
using DIO.Media.src.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DIO.Media.src.Controller
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly GenreRepository _repository;

        public GenreController(GenreRepository genreRepository)
        {
            _repository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetAllGenre()
        {
            var genre = await _repository.List();

            return Ok(genre);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenreById(int id)
        {
            var genre = await _repository.FindById(id);

            if (genre == null)
                return NotFound(new { message = "Genre not found." });
            
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] Genre genre)
        {
            if (genre == null)
                return BadRequest(new { message = "Invalid genre data." });

            try
            {
                await _repository.Insert(genre);

                return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the genre.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] Genre genre)
        {
            if (genre == null)
                return BadRequest(new { message = "Invalid genre data." });

            try
            {
                await _repository.Update(id, genre);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the genre.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            try
            {
                await _repository.Delete(id);
                
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the genre.", error = ex.Message });
            }
        }
    }
}