using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIO.Media.src.Entity
{
    public class Genre
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<Entity.Media>? Medias { get; set; }

    }
}