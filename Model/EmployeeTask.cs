using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CQRS_and_MediatR.Model
{
    public class EmployeeTask: BaseEntity
    {     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int EmployeeTaskId { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]  

        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public DateTime AssignmentDate { get; set; }

        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual Tasks Tasks { get; set; }
    }
}
