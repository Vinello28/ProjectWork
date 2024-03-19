using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models;

[Table("Illness_Symptom")]
public partial class IllnessSymptom
{
    [Key]
    [Column("Illness_Symptom_ID")]
    public int IllnessSymptomId { get; set; }

    [Column("IllnessID")]
    public int? IllnessId { get; set; }

    [Column("SymptomID")]
    public int? SymptomId { get; set; }

    [ForeignKey("IllnessId")]
    [InverseProperty("IllnessSymptoms")]
    public virtual Illness? Illness { get; set; }

    [ForeignKey("SymptomId")]
    [InverseProperty("IllnessSymptoms")]
    public virtual Symptom? Symptom { get; set; }
}
