using ProjectTrackerWebAPI.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static Project.Common.Constants;

namespace ProjectTrackerWebAPI.Models
{
    public class Project : TableMetaData
    {
         
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Descrption { get; set; }

        [DisplayName("Project Cost")]
        public float ProjectCost { get; set; } 

        public Department Department { get; set; }

        public CostMetrics CostMetrics { get; set; } //dropdown

        public ICollection<Memo> Memos { get; set; }

        public ICollection<SubWork> SubWorks { get; set; }
        //public ICollection<ProjectFile> ProjectFiles { get; set; }

        [NotMapped]
        [DisplayName("Project Cost")]
        public string StringProjectCost
        {
            get { return ProjectCost + " " + CostMetrics.ToString(); }

        }
    }
}
