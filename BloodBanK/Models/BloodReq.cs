using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BloodBanK.Models
{
    public class BloodReq
    {
        [Key]
        public Guid ReqId { get; set; }

        public string PatientName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PatientPhoneNo { get; set; }

        public string BloodGroup { get; set; }
        
        [ForeignKey("User")]
        public string UserName { get; set; }
        [JsonIgnore]
        public User User { set; get; }

        [ForeignKey("Slot")]
        public Guid SlotId { get; set; }
        [JsonIgnore]
        public Slot Slot { get; set; } 
        
    }
}
