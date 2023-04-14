using ProjectTrackerWebAPI.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Project.Common.Constants;

namespace ProjectTrackerWebAPI.Models
{
    public class Task : TableMetaData
    {
        public Guid Id { get; set; }

        [DisplayName("Task Name")]
        public string TaskName { get; set; }

        public string Descrption { get; set; }
        [DisplayName("Assigned to ID")]
        public string AssignedToId { get; set; }
        [ForeignKey("AssignedToId")]
        public ApplicationUser AssignedTo { get; set; }

        [DisplayName("Current Status")]
        public CurrentStatus currentStatus { get; set; } //dropdown
    }
}
