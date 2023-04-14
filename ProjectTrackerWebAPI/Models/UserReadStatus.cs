using ProjectTrackerWebAPI.Models.Common;
using static Project.Common.Constants;

namespace ProjectTrackerWebAPI.Models
{
    public class UserReadStatus: TableMetaData
    {
        public int Id { get; set; }
        public bool IsRead { get; set; } = false;

        public ApplicationUser User { get; set; }
    }
}
