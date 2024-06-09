namespace apbd10.DTOs;

public class PatientInfoDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; } 
    public IEnumerable<PrescriptionInfoDto> Prescriptions { get; set; } = new List<PrescriptionInfoDto>();
}

public class PrescriptionInfoDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public IEnumerable<MedicamentInfoDto> Medicaments { get; set; } = new List<MedicamentInfoDto>();
    public IEnumerable<DoctorInfoDto> Doctors { get; set; } = new List<DoctorInfoDto>();
}

public class MedicamentInfoDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Dose { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class DoctorInfoDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; } = string.Empty;
}


