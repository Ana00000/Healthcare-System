using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IInpatientCareRepository : IGenericRepository<InpatientCare>
    {
        List<InpatientCare> GetInpatientCaresForPatient(Patient patient);

    }
}