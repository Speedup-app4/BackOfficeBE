using System;
using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.CaaS
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }
        public required string ClientName { get; set; }
        public required string TaxCode { get; set; }
        public required string ContactPhone { get; set; }
        public required short ISACTIVE { get; set; }
    }
}
