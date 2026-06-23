using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.System
{
    public class SalesType
    {
        public Guid ClientId { get; set; }

        [Key]
        public int SALETYPEINDEX { get; set; }
        public required string DESCRIPT { get; set; }
        public short ForcePrice { get; set; } = 0;
        public short Tax1Exempt { get; set; } = 0;
        public short Tax2Exempt { get; set; } = 0;
        public short Tax3Exempt { get; set; } = 0;
        public short Tax4Exempt { get; set; } = 0;
        public short Tax5Exempt { get; set; } = 0;
        public short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public short UpdateStatus { get; set; } = 1;
        public int? PrintDelivery { get; set; }
        public int? OnInternet { get; set; }
        public int? ShipVia { get; set; }
        public string? PLink { get; set; }
        public int PrintLoc { get; set; } = 1;
        public int? AutoOrderProd { get; set; }
        public short? NoPreAuth { get; set; }
        public byte[]? Picture { get; set; }
        public short EnforceMember { get; set; } = 0;
        public short EnforceFutureOrder { get; set; } = 0;
        public int SNUM { get; set; } = -1;
        public long ReflectionUpdate { get; set; } = 0;
    }

    public class SalesTypeUpdate
    {
        [NotMapped]
        public required int SALETYPEINDEX { get; set; }
        public string? DESCRIPT { get; set; }
        public short? ForcePrice { get; set; }
        public short? Tax1Exempt { get; set; }
        public short? Tax2Exempt { get; set; }
        public short? Tax3Exempt { get; set; }
        public short? Tax4Exempt { get; set; }
        public short? Tax5Exempt { get; set; }
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public short? UpdateStatus { get; set; }
        public int? PrintDelivery { get; set; }
        public int? OnInternet { get; set; }
        public int? ShipVia { get; set; }
        public string? PLink { get; set; }
        public int? PrintLoc { get; set; }
        public int? AutoOrderProd { get; set; }
        public short? NoPreAuth { get; set; }
        public byte[]? Picture { get; set; }
        public short? EnforceMember { get; set; }
        public short? EnforceFutureOrder { get; set; }
        public int? SNUM { get; set; }
        public long? ReflectionUpdate { get; set; }
    }
}
