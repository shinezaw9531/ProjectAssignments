using System.ComponentModel.DataAnnotations;

namespace HealthForm.Models
{
    public class Health
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BusinessEmail { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string BusinessNumber { get; set; }
        public string LicensePlate { get; set; }
        public string NricFinNumber { get; set; }
        public bool Quarantine { get; set; }
        public bool Contact { get; set; }
        public bool FeverFluSymptoms { get; set; }
        public bool OnlineForm { get; set; }
    }
}
