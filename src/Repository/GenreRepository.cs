using DIO.Media.src.Entity;
using DIO.Media.src.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIO.Media.src.Repository
{
    public class GenreRepository(AppDbContext context)  : IRepository<Genre>
    {
        private readonly AppDbContext _context = context;

        public async Task<Genre?> FindById(int id)
        {
            return await _context.Genres.OfType<Genre>().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Insert(Genre entity)
        {
            _context.Genres.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Genre>> List()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task Update(int id, Genre entity)
        {
            var existingGenre = await _context.Genres.FindAsync(id);

            if (existingGenre == null)
                throw new KeyNotFoundException("Genre not found.");

            existingGenre.Name = entity.Name; 
            _context.Genres.Update(existingGenre);
            
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            
            if (genre == null)
                throw new KeyNotFoundException("Genre not found.");

            _context.Genres.Remove(genre);

            await _context.SaveChangesAsync();
        }
    }
}