using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTOs;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;

namespace IntegratedSystems.Service.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> repository;
        private readonly IRepository<VaccinationCenter> vaccinationCenterRepository;

        public PatientService(IRepository<Patient> repository, IRepository<VaccinationCenter> vaccinationCenterRepository)
        {
            this.repository = repository;
            this.vaccinationCenterRepository = vaccinationCenterRepository;
        }

        public Patient CreateNewPatient(Patient patient)
        {
            return repository.Insert(patient);
        }

        public Patient DeletePatient(Guid id)
        {
            return repository.Delete(GetPatientById(id));
        }

        public Patient GetPatientById(Guid? id)
        {
            return repository.Get(id);
        }

        public List<Patient> GetPatients()
        {
            return repository.GetAll().ToList();
        }

        public Patient UpdatePatient(Patient patient)
        {
            return repository.Update(patient);
        }

        public void VaccinatePatient(VaccinationDTO model)
        {
            var vaccine = new Vaccine
            {
                VaccinationCenter = model.CenterId,
                PatientId = model.PatientId,
                DateTaken = model.DateTaken,
                Certificate = Guid.NewGuid(),
                Manufacturer = model.ManufacturerId
            };

            var vaccinationCenter = vaccinationCenterRepository.Get(model.CenterId);

            if (vaccinationCenter is null)
            {
                return;
            }

            vaccinationCenter.MaxCapacity--;
            vaccinationCenter.Vaccines?.Add(vaccine);

            vaccinationCenterRepository.Update(vaccinationCenter);
        }
    }
}
