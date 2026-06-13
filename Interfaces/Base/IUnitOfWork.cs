using System.Data;
using BackOffice.Interfaces.Coupon;

namespace BackOffice.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction? Transaction { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();

        IAutoIncRepository AutoInc { get; }
        ISysInfoRepository SysInfo { get; }
        IRevenueCenterRepository Revenue { get; }
        ISummaryGroupRepository SummaryGroups { get; }
        IReportCatRepository ReportCat { get; }
        IReportTypeRepository ReportType { get; }
        ISalesTypeRepository SalesType { get; }
        IRefundReasonRepository RefundReason { get; }
        IPixelLookupRepository PixelLookup { get; }
        IStationInfoRepository StationInfo { get; }
        ISectionRepository Section { get; }
        IPrintPortRepository PrintPort { get; }
        IFormTemplateRepository FormTemplate { get; }
        ITypeOfProdRepository TypeOfProd { get; }
        IProductRepository Product { get; }
        IProductComboRepository ProductCombo { get; }
        IQuestionRepository Question { get; }
        IForceChoiceRepository ForceChoice { get; }
        IOrderCatRepository OrderCat { get; }
        IMenuOrderPosRepository MenuOrderPos { get; }
        IMenuProdPosRepository MenuProdPos { get; }
        IMultiMenuNamesRepository MultiMenuNames { get; }
        IEmployeeRepository Employee { get; }
        IEmpSchedInfoRepository EmpSchedInfo { get; }
        IJobPosRepository JobPos { get; }
        IPayRollRepository PayRoll { get; }
        IShiftRuleRepository ShiftRule { get; }
        IEmpDepartmentRepository EmpDepartment { get; }
        ISecurityRepository Security { get; }
        IMethodPayRepository MethodPay { get; }
        IPayMethReportCatRepository PayMethReportCat { get; }
        IPromoRepository Promo { get; }
        IPromoCatRepository PromoCat { get; }
        IPromoReportCatRepository PromoReportCat { get; }
        IPromoGrpRepository PromoGrp { get; }
        IPromoGrpDetailRepository PromoGrpDetail { get; }
    }
}
