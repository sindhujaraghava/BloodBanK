using System.ComponentModel.DataAnnotations;

namespace BloodBanK.Models
{
    public class User
    {

        [Key]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Pincode { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        public int RoleId { get; set; }
        public ICollection<BloodReq> BloodReqs { get; set; }
    }
}
