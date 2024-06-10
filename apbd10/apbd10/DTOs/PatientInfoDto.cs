namespace apbd10.DTOs;

public class PatientInfoDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; } 
    public IEnumerable<PrescriptionInfoDto> Prescriptions { get; set; } = new List<PrescriptionInfoDto>();
}




