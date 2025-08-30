using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; }        

        [NotMapped]
        public IFormFile? UploadedFile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
