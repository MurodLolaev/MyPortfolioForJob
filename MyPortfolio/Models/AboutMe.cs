using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{     
    public class AboutMe
    {        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Skills { get; set; }
        public string Contacts { get; set; }
        public string Job { get; set; }
        public string Hobbies { get; set; }
        public string? PotoPath { get; set; }
        [NotMapped]
        public IFormFile? UploadedFile { get; set; }
        public string LinkedInUrl { get; set; }       
       
        public AboutMe() { }

        public AboutMe(int id, string fullName, string bio, string skills, string contacts, string hobbies, IFormFile photoPath, string linkedInUrl)
        {
            Id = id;
            FullName = fullName;
            Bio = bio;
            Skills = skills;
            Contacts = contacts;
            Hobbies = hobbies;
            UploadedFile = photoPath;
            LinkedInUrl = linkedInUrl;
        }
    }
}
