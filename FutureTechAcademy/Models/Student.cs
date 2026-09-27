using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FutureTechAcademy.Models
{
    public class Student
    {
        [JsonProperty("id")] // Required for Cosmos DB
        public string Id { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string MobileNumber { get; set; }

        [Required]
        public string EnrolmentStatus { get; set; } // Active / Inactive

        public string? ProfileImageUrl { get; set; } // Stores only the filename (e.g. guid.jpg)
    }
}