using DIO.Media.src.Entity;
using DIO.Media.src.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIO.Media.src.Repository
{
    public class MediaRepository(AppDbContext context) : IRepository<Entity.Media>
    {
        private readonly AppDbContext _context = context;

        public async Task<List<T>> GetAllByTypeAsync<T>() where T : Entity.Media
        {
            return await _context.Medias.OfType<T>().ToListAsync();
        }
   
        public async Task<List<Entity.Media>> List()
        {
            return await _context.Medias.ToListAsync();
        }

        public async Task<Entity.Media?> FindById(int id)
        {
            return await _context.Medias.OfType<Entity.Media>().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Insert(Entity.Media entity)
        {
            var existingGenre = await _context.Genres.FindAsync(entity.GenreId);

            if (existingGenre == null)
                throw new KeyNotFoundException("Genre not found.");

            _context.Medias.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Medias.FindAsync(id);

            if (entity == null)
                throw new KeyNotFoundException("Media not found.");

            entity.Excluded = true;
            _context.Medias.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Entity.Media entity)
        {
            var existingGenre = await _context.Genres.FindAsync(entity.GenreId);

            if (existingGenre == null)
                throw new KeyNotFoundException("Genre not found.");
              
            if (entity is Movie movie)
            {
                var existingEntity = await _context.Movies.FindAsync(id);
      
                if (existingEntity == null)
                    throw new KeyNotFoundException("Movie not found.");

                existingEntity.Title = movie.Title;
                existingEntity.GenreId = movie.GenreId;
                existingEntity.Year = movie.Year;
                existingEntity.Description = movie.Description;
                existingEntity.Director = movie.Director;
                existingEntity.DurationMinutes = movie.DurationMinutes;

                _context.Medias.Update(existingEntity);
            }
            else if (entity is Serie serie)
            {
                var existingEntity = await _context.Series.FindAsync(id);

                if (existingEntity == null)
                    throw new KeyNotFoundException("Serie not found.");

                existingEntity.Title = serie.Title;
                existingEntity.GenreId = serie.GenreId;
                existingEntity.Year = serie.Year;
                existingEntity.Description = serie.Description;
                existingEntity.EpisodeNumber = serie.EpisodeNumber;
                existingEntity.SeasonNumber = serie.SeasonNumber;

                _context.Series.Update(existingEntity);
            }
            else
            {
                throw new ArgumentException("Invalid entity type.");
            }
            
            await _context.SaveChangesAsync();
        }
    }
}