using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.Menu
{
    public class OrderCat
    {
        public Guid ClientId { get; set; }

        [Key]
        public int ORDERCAT { get; set; }
        public required string DESCRIPT { get; set; }
        public required int BACKCOLOUR { get; set; }
        public required int TOPCOLOUR { get; set; }
        public short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public short? DEFGROUP { get; set; }
        public byte[]? DRAW { get; set; }
        public short? ORDERPOSITION { get; set; }
        public short? TYPECAT { get; set; }
        public string? BUTTON1 { get; set; }
        public string? BUTTON2 { get; set; }
        public string? BUTTON3 { get; set; }
        public short? UseTemplate { get; set; }
        public short? ButtonAcross { get; set; }
        public short? ButtonDown { get; set; }
        public string? FontName { get; set; }
        public short? FontSize { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public string? WebTop { get; set; }
        public string? WebBottom { get; set; }
        public string? PLink { get; set; }
        public int? FontStyle { get; set; }
        public string? MenuBoardDes { get; set; }
        public string? MenuBoardLongDes { get; set; }
        public int? SNum { get; set; } = -1;
    }

    public class OrderCatUpdate
    {
        [Key]
        public required int ORDERCAT { get; set; }
        public string? DESCRIPT { get; set; }
        public int? BACKCOLOUR { get; set; }
        public int? TOPCOLOUR { get; set; }
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public short? DEFGROUP { get; set; }
        public byte[]? DRAW { get; set; }
        public short? ORDERPOSITION { get; set; }
        public short? TYPECAT { get; set; }
        public string? BUTTON1 { get; set; }
        public string? BUTTON2 { get; set; }
        public string? BUTTON3 { get; set; }
        public short? UseTemplate { get; set; }
        public short? ButtonAcross { get; set; }
        public short? ButtonDown { get; set; }
        public string? FontName { get; set; }
        public short? FontSize { get; set; }
        public short? UpdateStatus { get; set; }
        public string? WebTop { get; set; }
        public string? WebBottom { get; set; }
        public string? PLink { get; set; }
        public int? FontStyle { get; set; }
        public string? MenuBoardDes { get; set; }
        public string? MenuBoardLongDes { get; set; }
        public int? SNum { get; set; }
    }
}
