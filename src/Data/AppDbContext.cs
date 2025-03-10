using Microsoft.EntityFrameworkCore;
using DIO.Media.src.Entity;

public class AppDbContext : DbContext
{
    public DbSet<Media> Medias { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
