using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CQRS_and_MediatR.Model
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            EmployeeTasks = new HashSet<EmployeeTask>();    
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public string Email{ get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set;}

    }
}
