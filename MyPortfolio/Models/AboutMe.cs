using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{     
    public class AboutMe
    {        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Skills { get; set; }
        public string Contacts { get; set; }
        public string Hobbies { get; set; }
        public string PhotoPath { get; set; }
        public string LinkedInUrl { get; set; }

        public string RoleName { get; set; }
        public ICollection<Project> Projects { get; set; } = new List<Project>();


        public AboutMe() { }

        public AboutMe(int id, string fullName, string bio, string skills, string contacts, string hobbies, string photoPath, string linkedInUrl)
        {
            Id = id;
            FullName = fullName;
            Bio = bio;
            Skills = skills;
            Contacts = contacts;
            Hobbies = hobbies;
            PhotoPath = photoPath;
            LinkedInUrl = linkedInUrl;
        }
    }
}
