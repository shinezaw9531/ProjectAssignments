using System.ComponentModel.DataAnnotations;

namespace HealthForm.Models
{
    public class AddHealthViewModel
    {
        [Required(ErrorMessage = "This is Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This is BusinessEmail")]
        public string BusinessEmail { get; set; }
        [Required(ErrorMessage = "This is CompanyName")]
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        [Required(ErrorMessage = "This is BusinessNumber")]
        public string BusinessNumber { get; set; }
        public string LicensePlate { get; set; }
        public string NricFinNumber { get; set; }
        public bool Quarantine { get; set; }
        public bool Contact { get; set; }
        public bool FeverFluSymptoms { get; set; }
        public bool OnlineForm { get; set; }
    }
}
