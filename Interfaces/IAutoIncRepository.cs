using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces
{
    public enum AutoIncType
    {
        GETNEXT_SUMMARYGROUP,
        GETNEXT_REPORTCAT,
        GETNEXT_RevCenter,
        GETNEXT_SALETYPE,
        GETNEXT_REFUNDREASON,
        GETNEXT_STATNUM,
        GETNEXT_SECTIONS,
        GETNEXT_PRODUCT,
        GetNext_ProductComboID,
        GETNEXT_QUESTIONS,
        GETNEXT_ForceChoice,
        GETNEXT_ORDERCAT,
        GETNEXT_MenuOrderPos,
        GETNEXT_MenuProdPos,
        GETNEXT_MENUNAMES,
        GETNEXT_EMPNO,
        GETNEXT_JOBPOS,
        GETNEXT_PAYROLL,
        GETNEXT_METHODPAYMENT,
        GETNEXT_PROMO,
        GETNEXT_PromoReport,
        GetNext_PromoGrpID,
        GetNext_PromoGrpDetailID,
    }

    public interface IAutoIncRepository : IGenericRepository<object>
    {
        Task<int> GetNextSequenceAsync(
            AutoIncType incType,
            Guid clientId,
            Guid? storeId = null,
            int incrementBy = 1
        );
    }
}
