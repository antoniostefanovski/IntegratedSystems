using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Domain.DTOs
{
    public class VaccinationDTO
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();

        [DisplayName("Patient")]
        public Guid PatientId { get; set; }

        public Guid CenterId { get; set; }

        public List<string> Manufacturers { get; set; } = new List<string>();

        [DisplayName("Manufacturer")]
        public string? ManufacturerId { get; set; }

        public DateTime DateTaken { get; set; } = DateTime.Now;
    }
}
