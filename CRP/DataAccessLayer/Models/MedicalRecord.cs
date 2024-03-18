using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("MedicalRecord")]
public partial class MedicalRecord
{
    [Key]
    [Column("RecordID")]
    public int RecordId { get; set; }

    [Column("PatientID")]
    public int? PatientId { get; set; }

    [Column("DoctorID")]
    [StringLength(255)]
    public string? DoctorId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    [Column(TypeName = "text")]
    public string? Diagnosis { get; set; }

    [Column(TypeName = "text")]
    public string? Treatment { get; set; }

    [Column(TypeName = "text")]
    public string? Medications { get; set; }

    [Column(TypeName = "text")]
    public string? Notes { get; set; }

    [Column("IllnessID")]
    public int? IllnessId { get; set; }

    [ForeignKey("IllnessId")]
    [InverseProperty("MedicalRecords")]
    public virtual Illness? Illness { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("MedicalRecords")]
    public virtual Patient? Patient { get; set; }
}
