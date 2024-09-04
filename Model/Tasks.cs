using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CQRS_and_MediatR.Model
{
    public class Tasks: BaseEntity
    {
        public Tasks()
        {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TaskName { get; set; }
        [MaxLength(400)]
        public string Description { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DeuDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
