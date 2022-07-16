using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBanK.Models
{
    public class BloodReq
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public String State { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string BloodGroup { get; set; }
        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { set; get; }
        
    }
}
