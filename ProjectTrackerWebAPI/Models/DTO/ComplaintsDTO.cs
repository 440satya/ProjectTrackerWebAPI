using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTrackerWebAPI.Models.DTO
{
    public class ComplaintsDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Guid DepartmentId { get; set; }
        public bool IsResolved { get; set; }
    }
}
