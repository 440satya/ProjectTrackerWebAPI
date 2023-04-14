using ProjectTrackerWebAPI.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static Project.Common.Constants;

namespace ProjectTrackerWebAPI.Models
{
    public class ProjectFileHistory : TableMetaData
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }

        //public ProjectFile File { get; set; }

        public string Comment { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string AssignedToId { get; set; }

        [DisplayName("Assigned To")]
        [ForeignKey("AssignedToId")]
        public ApplicationUser AssignedTo { get; set; }

        [DisplayName("File Status")]
        public FileStatus FileStatus { get; set; }
    }
}