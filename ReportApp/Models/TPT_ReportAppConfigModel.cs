using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReportApp.Models
{
    public class TPT_ReportAppConfig
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nchar(50)")]
        [MaxLength(100)]
        public string? ReportType { get; set; }

        [Column(TypeName = "nchar(255)")]
        [MaxLength(510)]
        public string? ReportName { get; set; }

        [Column(TypeName = "nchar(255)")]
        [MaxLength(510)]
        public string? ReportStoredName { get; set; }
    }
}
