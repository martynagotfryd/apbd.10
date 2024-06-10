using apbd10.Data;
using apbd10.DTOs;
using apbd10.Models;
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

    public async Task<bool> DoesPatientExist(int id)
    {
        var patient = await _context.Patients.AnyAsync(p => p.Id == id);

        return patient;
    }

    public async Task AddPatient(PatientDto patientDto)
    {
        var patient = new Patient()
        {
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            BirthDate = patientDto.BirthDate
        };
        
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesDoctorExist(int id)
    {
        var doctor = await _context.Doctors.AnyAsync(p => p.Id == id);

        return doctor;
    }

    public async Task<bool> DoesMedicamentExist(int id)
    {
        var medicament = await _context.Medicaments.AnyAsync(p => p.Id == id);

        return medicament;
    }

    public async Task<int> AddPrescription(AddPrescriptionDto prescriptionDto)
    {
        var prescription = new Prescription()
        {
            Date = DateTime.Now,
            DueDate = prescriptionDto.DueDate,
            PatientId = prescriptionDto.Patient.IdPatient,
            DoctorId = prescriptionDto.Doctor.IdDoctor
        };
        
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();

        return prescription.Id;
    }

    public async Task AddMedicament_Prescription(MedicamentInfoDto medicamentInfoDto, int idPrescription)
    {
        var prescription_medicament = new PrescriptionMedicament()
        {
            MedicamentId = medicamentInfoDto.IdMedicament,
            PrescriptionId = idPrescription,
            Dose = medicamentInfoDto.Dose,
            Description = medicamentInfoDto.Description
        };
        
        await _context.PrescriptionMedicaments.AddAsync(prescription_medicament);
        await _context.SaveChangesAsync();
    }
}