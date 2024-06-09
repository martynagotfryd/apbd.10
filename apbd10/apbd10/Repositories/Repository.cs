using apbd10.Data;
using apbd10.DTOs;
using Microsoft.EntityFrameworkCore;

namespace apbd10.Repositories;

public class Repository : IRepository
{
    private readonly DataBaseContext _context;

    public Repository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<PatientInfoDto?> GetPatientInfo(int id)
    {
        var patient = await _context.Patients
            .Where(p => p.Id == id)
            .Select(p => new PatientInfoDto
            {
                IdPatient = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Prescriptions = p.Prescriptions.Select(pr => new PrescriptionInfoDto
                {
                    IdPrescription = pr.Id,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Medicaments = pr.PrescriptionMedicaments.Select(pm => new MedicamentInfoDto
                    {
                        IdMedicament = pm.Medicament.Id,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose,
                        Description = pm.Description
                    }).ToList(), // Ensure ToList() is called here
                    Doctors = new List<DoctorInfoDto>
                    {
                        new DoctorInfoDto
                        {
                            IdDoctor = pr.Doctor.Id,
                            FirstName = pr.Doctor.FirstName
                        }
                    }
                }).ToList() // Ensure ToList() is called here
            })
            .FirstOrDefaultAsync();

        return patient;
    }

    public Task<bool> DoesPatientExist(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddPatient(PatientDto patientDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DoesDoctorExist(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DoesMedicamentExist(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddPrescription(PatientDto patientDto)
    {
        throw new NotImplementedException();
    }
}