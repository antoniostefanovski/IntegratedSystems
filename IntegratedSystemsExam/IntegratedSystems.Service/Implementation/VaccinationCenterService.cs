using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;

namespace IntegratedSystems.Service.Implementation
{
    public class VaccinationCenterService : IVaccinationCenterService
    {
        private readonly IRepository<VaccinationCenter> repository;

        public VaccinationCenterService(IRepository<VaccinationCenter> repository)
        {
            this.repository = repository;
        }

        public VaccinationCenter CreateNewVaccinationCenter(VaccinationCenter center)
        {
            return repository.Insert(center);
        }

        public VaccinationCenter DeleteVaccinationCenter(Guid id)
        {
            return repository.Delete(GetVaccinationCenterById(id));
        }

        public VaccinationCenter GetVaccinationCenterById(Guid? id)
        {
            return repository.Get(id);
        }

        public List<VaccinationCenter> GetVaccinationCenters()
        {
            return repository.GetAll().ToList();
        }

        public VaccinationCenter UpdateVaccinationCenter(VaccinationCenter center)
        {
            return repository.Update(center);
        }
    }
}
