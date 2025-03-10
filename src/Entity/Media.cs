using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIO.Media.src.Entity
{
    public abstract class Media
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [JsonIgnore]
        public bool Excluded { get; set; } = false;
        public int GenreId { get; set; }
    }
}