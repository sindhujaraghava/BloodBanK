using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BloodBanK.Models
{
    public class Slot
    {
        [Key]
        public Guid SlotId { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime SlotTime { get; set; }
        
        [ForeignKey("Hospital")]
        public string HospitalName { get; set; }
        [JsonIgnore]
        public Hospital Hospital { get; set; }  
    }
}
