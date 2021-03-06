using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IEquipmentRepository : IGenericRepository<Equipment>
    {
        List<Equipment> GetByName(string name);
        List<Equipment> GetByRoomSerialNumber(string roomSerialNumber);
    }
}