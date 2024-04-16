using IntegratedSystems.Domain.Domain_Models;

namespace IntegratedSystems.Service.Interface
{
    public interface IVaccinationCenterService
    {
        public List<VaccinationCenter> GetVaccinationCenters();

        public VaccinationCenter GetVaccinationCenterById(Guid? id);

        public VaccinationCenter CreateNewVaccinationCenter(VaccinationCenter center);

        public VaccinationCenter UpdateVaccinationCenter(VaccinationCenter center);

        public VaccinationCenter DeleteVaccinationCenter(Guid id);
    }
}
