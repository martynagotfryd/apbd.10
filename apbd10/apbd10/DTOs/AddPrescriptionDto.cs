namespace apbd10.DTOs;

public class AddPrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public PatientDto Patient { get; set; } = null!;
    public DoctorInfoDto Doctor { get; set; } = null!;
    public IEnumerable<MedicamentInfoDto> Medicaments { get; set; } = new List<MedicamentInfoDto>();
}




