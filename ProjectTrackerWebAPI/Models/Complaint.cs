using ProjectTrackerWebAPI.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTrackerWebAPI.Models
{
    public class Complaint: TableMetaData
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        
        public Guid DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }
        public bool IsResolved { get; set; }
    }
}
