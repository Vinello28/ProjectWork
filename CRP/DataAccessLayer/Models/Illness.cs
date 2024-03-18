using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("Illness")]
public partial class Illness
{
    [Key]
    [Column("IllnessID")]
    public int IllnessId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [InverseProperty("Illness")]
    public virtual ICollection<IllnessSymptom> IllnessSymptoms { get; set; } = new List<IllnessSymptom>();

    [InverseProperty("Illness")]
    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}
