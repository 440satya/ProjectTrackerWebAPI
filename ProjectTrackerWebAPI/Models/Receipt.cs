using ProjectTrackerWebAPI.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTrackerWebAPI.Models
{
    public class Receipt : TableMetaData
    {
        [Key]
        public Guid Id { get; set; }
        public Department Department { get; set; } //dropdown

        [StringLength(100)]
        public string Subject { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Receipt Date")]
        public DateTime ReceiptReceivedDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        [DisplayName("Received By")]
        public string ReceiptReceivedBy { get; set; }

        [StringLength(200)]
        [DisplayName("Comments")]
        public string Comment { get; set; }

        [StringLength(100)]
        [DisplayName("Upload Receipt")]
        public string AttachedReceipt { get; set; }

        [NotMapped]
        [DisplayName("Uploaded Receipt")]
        public IFormFile ReceiptFile { get; set; }
    }
}
