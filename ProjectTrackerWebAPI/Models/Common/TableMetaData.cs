using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectTrackerWebAPI.Models.Common
{
    public abstract class TableMetaData
    {
        //[ScaffoldColumn(false)]
        //public string LastModifiedBy { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }

        //[ScaffoldColumn(false)]
        //public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
