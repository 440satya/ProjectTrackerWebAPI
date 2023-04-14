using ProjectTrackerWebAPI.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static Project.Common.Constants;

namespace ProjectTrackerWebAPI.Models
{
    public class SubWork : TableMetaData
    {
        public Guid Id { get; set; }

        [DisplayName("Sub Work")]
        public string SubWorkName { get; set; }

        public string Descrption { get; set; }

        [DisplayName("Estimated Cost")]
        public float EstimatedCost { get; set; }

        [DisplayName("Actual Cost")]
        public float ActualCost { get; set; }

        public CurrentStatus currentStatus { get; set; } //dropdown

        [DisplayName("Project Name")]
        [ForeignKey("projects")]
        public Guid ProjectId { get; set; }

        public virtual Models.Project projects { get; set; }
        public CostMetrics EstimatedCostMetrics { get; set; } //dropdown
        public CostMetrics ActualCostMetrics { get; set; } //dropdown

        public string StringEstimatedCostMetrics
        {
            get { return EstimatedCost + " " + EstimatedCostMetrics.ToString(); }
        }
        public string StringActualCostMetrics
        {
            get { return ActualCost + " " + ActualCostMetrics.ToString(); }
        }
    }
}
