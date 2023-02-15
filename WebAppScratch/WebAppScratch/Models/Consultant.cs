using System.ComponentModel.DataAnnotations;

namespace RedAcademySite.Models
{
    public class Consultant
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is mandatory!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name field mus be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The role field is mandatory!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Role field mus be between 3 and 50 characters")]
        public string Role { get; set; }

        [Required(ErrorMessage = "The email field is mandatory!")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Email field mus be between 10 and 250 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The image field is mandatory!")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Image field mus be between 3 and 300 characters")]
        public string Image { get; set; }

        [Required(ErrorMessage = "The team field is mandatory!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Team field mus be between 3 and 50 characters")]
        public string Team { get; set; }

        public bool Active { get; set; }



    }
}
