namespace CQRS_and_MediatR.Model
{
    public abstract class BaseEntity
    {
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
