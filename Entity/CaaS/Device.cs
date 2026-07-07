using System;
using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.CaaS
{
    public class Device
    {
        public required Guid ClientId { get; set; }

        [Key]
        public Guid DeviceId { get; set; }
        public required string SerialNumber { get; set; }
        public required int StatNum { get; set; }
        public required bool IsQuickOrder { get; set; }
        public required string AppVersion { get; set; }
        public required short ISACTIVE { get; set; } = 1;
    }
}
