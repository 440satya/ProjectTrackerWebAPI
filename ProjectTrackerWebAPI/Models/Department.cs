using ProjectTrackerWebAPI.Models.Common;
using Microsoft.AspNetCore.Identity;

namespace ProjectTrackerWebAPI.Models
{
    public class Department : TableMetaData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HODId { get; set; }
        public ApplicationUser HOD { get; set; }

        //public ICollection<FeedBack> Feedbacks { get; set; }
        //public ICollection<Complaint> complaints { get; set; }
    }
}
