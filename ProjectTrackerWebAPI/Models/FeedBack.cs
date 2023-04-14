using ProjectTrackerWebAPI.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerWebAPI.Models
{
    public class FeedBack : TableMetaData
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } //dropdown

        public string WorkDescription { get; set; }

        public bool IsWorkDone { get; set; }

        public bool IsDoneOnTime { get; set; }
        public bool IsGuidedProperly { get; set; }
        public int HabitMarks { get; set; }
        public int KnowlegeMarks { get; set; }

        public int OverallSatisficationMarks { get; set; }
        public string Feedback { get; set; }

        //public UserReadStatus UserReadStatus { get; set; } //Ignore as of now

        public bool IsResolved { get; set; }
    }
}
