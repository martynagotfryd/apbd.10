using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd10.Models;

[Table("prescription_medicament")]
[PrimaryKey(nameof(MedicamentId), nameof(PrescriptionId))]
public class PrescriptionMedicament
{
    public int MedicamentId { get; set; }
    
    [ForeignKey(nameof(MedicamentId))]
    public Medicament Medicament { get; set; }
    
    public int PrescriptionId { get; set; }
    
    [ForeignKey(nameof(PrescriptionId))]
    
    public Prescription Prescription { get; set; }
    
    public int Dose { get; set; }
    
    [MaxLength(100)]
    public string Description { get; set; }
}