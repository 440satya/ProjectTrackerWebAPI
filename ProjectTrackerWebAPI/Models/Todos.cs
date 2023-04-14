using ProjectTrackerWebAPI.Models.Common;

namespace ProjectTrackerWebAPI.Models
{
    public class Todos:TableMetaData
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
    }
}
