using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.System
{
    [Table("FormTemplates")]
    public class FormTemplate
    {
        public Guid ClientId { get; set; }

        [Key]
        public required int TemplateNum { get; set; }
        public string? Descript { get; set; }
        public byte[]? FormData { get; set; }
        public int? RevCenter { get; set; }
        public short? IsActive { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
        public int? FormType { get; set; }
        public short? Version { get; set; }
    }
}
