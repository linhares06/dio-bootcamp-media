using System.ComponentModel.DataAnnotations;

namespace DIO.Media.src.Entity
{
    public class Serie : Media
    {
        [Required]
        public int SeasonNumber { get; set; }
        [Required]
        public int EpisodeNumber { get; set; }
    }
}