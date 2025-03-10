using System.ComponentModel.DataAnnotations;

namespace DIO.Media.src.Entity
{
    public class Movie : Media
    {
        [Required]
        public int DurationMinutes { get; set; }
        [Required]
        public string? Director { get; set; } 
    }
}