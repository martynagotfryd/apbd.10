using apbd10.DTOs;

namespace apbd10.Repositories;

public interface IRepository
{
    Task<PatientInfoDto?> GetPatientInfo(int id);

}