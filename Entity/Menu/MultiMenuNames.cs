using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Menu
{
    public class MultiMenuNames
    {
        public Guid ClientId { get; set; }

        [Key]
        public int MENUINDEX { get; set; }
        public required string DESCRIPT { get; set; }
        public required int RevCenter { get; set; } //* Rev ID
        public required short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public string? TEMPLATEFILENAME { get; set; }
        public string? PLink { get; set; }
        public byte[]? TemplateData { get; set; }
        public string? MenuLock { get; set; }
        public int? TemplateNum { get; set; }
        public int? UpdateStatus { get; set; } = 1;
        public int? SNUM { get; set; } = -1;
    }

    public class MultiMenuNamesUpdate
    {
        [NotMapped]
        public required int MENUINDEX { get; set; }
        public string? DESCRIPT { get; set; }
        public int? RevCenter { get; set; }
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public string? TEMPLATEFILENAME { get; set; }
        public string? PLink { get; set; }
        public byte[]? TemplateData { get; set; }
        public string? MenuLock { get; set; }
        public int? TemplateNum { get; set; }
        public int? UpdateStatus { get; set; }
        public int? SNUM { get; set; }
    }

    public class MenuSetup
    {
        public List<MenuOrderPos>? ListMenuOrderPos { get; set; }
        public List<MenuProdPos>? ListMenuProdPos { get; set; }
    }
}
