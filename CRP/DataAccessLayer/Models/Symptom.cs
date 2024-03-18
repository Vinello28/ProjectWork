using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("Symptom")]
public partial class Symptom
{
    [Key]
    [Column("SymptomID")]
    public int SymptomId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [InverseProperty("Symptom")]
    public virtual ICollection<IllnessSymptom> IllnessSymptoms { get; set; } = new List<IllnessSymptom>();
}
