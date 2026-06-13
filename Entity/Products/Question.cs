using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Products
{
    [Table("Questions")]
    public class Question
    {
        public Guid ClientId { get; set; }

        [Key]
        public int OPTIONINDEX { get; set; }
        public required string QUESTION { get; set; }
        public required short FORCED { get; set; } = 1; //*Min choice
        public required short NUMCHOICE { get; set; } = 1; //*Max choice
        public required short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public short? CHOICEDEFAULT { get; set; }
        public short? FreeChoices { get; set; } = 99;
        public short? AutoOk { get; set; } = 0;
        public short? UseButtons { get; set; } = 0;
        public short? AllowMulti { get; set; } = 1;
        public short? AllowSplit { get; set; } = 0;
        public short? Subst { get; set; }
        public string? Descript { get; set; }
        public int? QstnTmplNum { get; set; }
        public int? SNum { get; set; } = -1;
        public int? SubstQuest { get; set; }
        public int? UpdateStatus { get; set; } = 1;

        [NotMapped]
        public List<ForceChoice>? ForcedChoices { get; set; }
    }

    public class QuestionUpdate
    {
        [NotMapped]
        public required int OPTIONINDEX { get; set; }
        public string? QUESTION { get; set; }
        public short? FORCED { get; set; } //*Min choice
        public short? NUMCHOICE { get; set; } //*Max choice
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public short? CHOICEDEFAULT { get; set; }
        public short? FreeChoices { get; set; }
        public short? AutoOk { get; set; }
        public short? UseButtons { get; set; }
        public short? AllowMulti { get; set; }
        public short? AllowSplit { get; set; }
        public short? Subst { get; set; }
        public string? Descript { get; set; }
        public int? QstnTmplNum { get; set; }
        public int? SNum { get; set; }
        public int? SubstQuest { get; set; }
        public int? UpdateStatus { get; set; }

        [NotMapped]
        public List<ForceChoice>? ForcedChoices { get; set; }
    }
}
