using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using ProjectTrackerWebAPI.Models.Common;

namespace ProjectTrackerWebAPI.Models
{
    public class Memo : TableMetaData
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } //dropdown

        [DisplayName("Memo Date")]
        [DataType(DataType.Date)]
        public DateTime MemoDate { get; set; } //Date only
        [DisplayName("Description")]
       
        public string Descrption { get; set; }

        [DisplayName("Attachment Name")]
        
        public string AttachedMemo { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
