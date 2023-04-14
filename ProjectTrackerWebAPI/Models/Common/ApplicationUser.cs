using Microsoft.AspNetCore.Identity;

namespace ProjectTrackerWebAPI.Models.Common
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LasttName { get; set; }

        public string FullName
        {
            get { return FirstName+" "+LasttName; }
        }
        //public ICollection<Task> Tasks { get; set; }
        //public ICollection<ProjectFile> ProjectFiles { get; set; }
        //public ICollection<ProjectFileHistory> PFilesHistory { get; set; }
        //public ICollection<Department> Departments { get; set;}
    }
}
