using System.ComponentModel.DataAnnotations;

namespace BloodBanK.Models
{
    public class User
    {

        [Key]
        public string UserName { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public int Age { get; set; }
        
        public string Gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Weight { get; set; }
        
        public string BloodGroup { get; set; }
        
        public int RoleId { get; set; }
        
        public ICollection<BloodReq> BloodReqs { get; set; }
    }
}
