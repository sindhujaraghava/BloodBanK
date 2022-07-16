using System.ComponentModel.DataAnnotations;

namespace BloodBanK.Models
{
    public class Hospital
    {
        [Key]
        public string HospitalName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Area { get; set; }
        
        [DataType(DataType.PostalCode)]
        public string Pincode { get; set; }

        public ICollection<Slot> slots { get; set; }

        
    }
}
