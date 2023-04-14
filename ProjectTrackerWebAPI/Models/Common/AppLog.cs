using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerWebAPI.Models.Common
{
    public class AppLog
    {
        public Guid Id { get; set; }

        [Required]
        public string Message { get; set; }

        public string MessageTemplate { get; set; }

        public string Level { get; set; }

        public DateTime? TimeStamp { get; set; }

        public string Exception { get; set; }

        public string Properties { get; set; }
    }
}
