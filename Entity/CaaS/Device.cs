using System;
using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.CaaS
{
    public enum DeviceType
    {
        Mobile = 0,
        Tablet = 1,
        POS = 2,
    }

    public class Device
    {
        public required Guid ClientId { get; set; }

        [Key]
        public Guid DeviceId { get; set; }
        public required string SerialNumber { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string DeviceType { get; set; }
        public required int StatNum { get; set; }
        public required short IsQuickOrder { get; set; }
        public required string AppVersion { get; set; }
        public required short ISACTIVE { get; set; }
    }

    public class DeviceUpdate
    {
        public required Guid DeviceId { get; set; }
        public int? StatNum { get; set; }
        public short? IsQuickOrder { get; set; }
    }
}
