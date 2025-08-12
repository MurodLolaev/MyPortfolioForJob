using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int AboutMeId { get; set; }
        public AboutMe Creator { get; set; }

    }
}
