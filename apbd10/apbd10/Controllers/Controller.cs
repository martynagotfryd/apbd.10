using apbd10.DTOs;
using apbd10.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apbd10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly IRepository _repository;

    public Controller(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientInfo(int idPatient)
    {
        var patient = await _repository.GetPatientInfo(idPatient);

        if (patient == null)
        {
            return NotFound();
        }

        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(AddPrescriptionDto prescriptionDto)
    {
        if (prescriptionDto.DueDate <= prescriptionDto.Date)
        {
            return BadRequest("DueDate must be greater than or equal to Date");
        }
        
        if (prescriptionDto.Medicaments.Count() > 10)
        {
            return BadRequest("Prescription can include a maximum of 10 medications");
        }
        
        foreach (var medicament in prescriptionDto.Medicaments)
        {
            if (!await _repository.DoesMedicamentExist(medicament.IdMedicament))
            {
                return NotFound("Medicament doesnt exist");
            }
        }
        
        if (!await _repository.DoesDoctorExist(prescriptionDto.Doctor.IdDoctor))
        {
            return NotFound("Doctor doesnt exist");
        }
        
        if (!await _repository.DoesPatientExist(prescriptionDto.Patient.IdPatient))
        {
            await _repository.AddPatient(prescriptionDto.Patient);
        }

        var idPrescription = await _repository.AddPrescription(prescriptionDto);

        foreach (var medicament in prescriptionDto.Medicaments)
        {
            await _repository.AddMedicament_Prescription(medicament, idPrescription);
        }

        return Created();
    }
    
}