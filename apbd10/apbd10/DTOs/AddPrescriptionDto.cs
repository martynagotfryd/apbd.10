namespace apbd10.DTOs;

public class AddPrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public PatientDto Patient { get; set; } = null!;
    public MedicamentInfoDto MedicamentInfoDto { get; set; } = null!;
}


