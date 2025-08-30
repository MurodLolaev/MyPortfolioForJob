using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Image { get; set; }         
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }

        [NotMapped]
        public IFormFile? UploadedFile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
