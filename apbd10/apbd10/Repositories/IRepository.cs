using apbd10.DTOs;

namespace apbd10.Repositories;

public interface IRepository
{
    Task<PatientInfoDto?> GetPatientInfo(int id);
    Task<bool> DoesPatientExist(int id);
    Task AddPatient(PatientDto patientDto);
    Task<bool> DoesDoctorExist(int id);
    Task<bool> DoesMedicamentExist(int id);
    Task AddPrescription(PatientDto patientDto);
}