using System;
using System.Data;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Coupon;
using BackOffice.Interfaces.Modules.Employees;
using BackOffice.Interfaces.Modules.Menu;
using BackOffice.Interfaces.Modules.Payment;
using BackOffice.Interfaces.Modules.Products;
using BackOffice.Interfaces.Modules.Refund;
using BackOffice.Interfaces.Modules.Report;
using BackOffice.Interfaces.Modules.Station;
using BackOffice.Interfaces.Modules.System;
using BackOffice.Interfaces.Modules.Table;
using BackOffice.Repositories.Modules.Coupon;
using BackOffice.Repositories.Modules.Employees;
using BackOffice.Repositories.Modules.Menu;
using BackOffice.Repositories.Modules.Payment;
using BackOffice.Repositories.Modules.Products;
using BackOffice.Repositories.Modules.Refund;
using BackOffice.Repositories.Modules.Report;
using BackOffice.Repositories.Modules.Station;
using BackOffice.Repositories.Modules.System;
using BackOffice.Repositories.Modules.Table;
using Npgsql;

namespace BackOffice.Repositories.Base
{
    public class UnitOfWork(NpgsqlDataSource connectionFactory) : IUnitOfWork
    {
        private readonly IDbConnection _connection = connectionFactory.CreateConnection();
        private IDbTransaction? _transaction;

        public IDbConnection Connection => _connection;
        public IDbTransaction? Transaction => _transaction;

        public void BeginTransaction()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
            GC.SuppressFinalize(this);
        }

        private IAutoIncRepository? _autoInc;
        private ISysInfoRepository? _sysInfo;
        private IRevenueCenterRepository? _revenue;
        private ISummaryGroupRepository? _summaryGroups;
        private IReportCatRepository? _reportCat;
        private IReportTypeRepository? _reportType;
        private ISalesTypeRepository? _salesType;
        private IRefundReasonRepository? _refundReason;
        private IPixelLookupRepository? _pixelLookup;
        private IStationInfoRepository? _stationInfo;
        private ISectionRepository? _section;
        private IPrintPortRepository? _printPort;
        private IFormTemplateRepository? _formTemplate;
        private ITypeOfProdRepository? _typeProd;
        private IProductRepository? _product;
        private IProductComboRepository? _productCombo;
        private IQuestionRepository? _question;
        private IForceChoiceRepository? _forceChoice;
        private IOrderCatRepository? _orderCat;
        private IMenuOrderPosRepository? _menuOrderPos;
        private IMenuProdPosRepository? _menuProdPos;
        private IMultiMenuNameRepository? _multiMenuName;
        private IEmployeeRepository? _employee;
        private IEmpSchedInfoRepository? _empSchedule;
        private IPayRollRepository? _payRoll;
        private IJobPosRepository? _jobPos;
        private IShiftRuleRepository? _shiftRule;
        private IEmpDepartmentRepository? _empDepartment;
        private ISecurityRepository? _security;
        private IMethodPayRepository? _methodPay;
        private IPayMethReportCatRepository? _payMethReportCat;

        private IPromoRepository? _promo;
        private IPromoCatRepository? _promoCat;
        private IPromoReportCatRepository? _promoReportCat;
        private IPromoGrpRepository? _promoGrp;
        private IPromoGrpDetailRepository? _promoGrpDetail;

        public IAutoIncRepository AutoInc => _autoInc ??= new AutoIncRepository(this);
        public ISysInfoRepository SysInfo => _sysInfo ??= new SysInfoRepository(this);
        public IRevenueCenterRepository Revenue => _revenue ??= new RevenueCenterRepository(this);
        public ISummaryGroupRepository SummaryGroups =>
            _summaryGroups ??= new SummaryGroupRepository(this);
        public IReportCatRepository ReportCat => _reportCat ??= new ReportCatRepository(this);
        public IReportTypeRepository ReportType => _reportType ??= new ReportTypeRepository(this);
        public ISalesTypeRepository SalesType => _salesType ??= new SalesTypeRepository(this);
        public IRefundReasonRepository RefundReason =>
            _refundReason ??= new RefundReasonRepository(this);
        public IStationInfoRepository StationInfo =>
            _stationInfo ??= new StationInfoRepository(this);
        public ISectionRepository Section => _section ??= new SectionRepository(this);
        public IPixelLookupRepository PixelLookup =>
            _pixelLookup ??= new PixelLookupRepository(this);
        public IPrintPortRepository PrintPort => _printPort ??= new PrintPortRepository(this);
        public IFormTemplateRepository FormTemplate =>
            _formTemplate ??= new FormTemplateRepository(this);
        public ITypeOfProdRepository TypeOfProd => _typeProd ??= new TypeOfProdRepository(this);

        public IProductRepository Product => _product ??= new ProductRepository(this);
        public IProductComboRepository ProductCombo =>
            _productCombo ??= new ProductComboRepository(this);
        public IQuestionRepository Question => _question ??= new QuestionRepository(this);
        public IForceChoiceRepository ForceChoice =>
            _forceChoice ??= new ForceChoiceRepository(this);
        public IOrderCatRepository OrderCat => _orderCat ??= new OrderCatRepository(this);
        public IMenuOrderPosRepository MenuOrderPos =>
            _menuOrderPos ??= new MenuOrderPosRepository(this);
        public IMenuProdPosRepository MenuProdPos =>
            _menuProdPos ??= new MenuProdPosRepository(this);
        public IMultiMenuNameRepository MultiMenuName =>
            _multiMenuName ??= new MultiMenuNameRepository(this);
        public IEmployeeRepository Employee => _employee ??= new EmployeeRepository(this);
        public IEmpSchedInfoRepository EmpSchedInfo =>
            _empSchedule ??= new EmpSchedInfoRepository(this);
        public IPayRollRepository PayRoll => _payRoll ??= new PayRollRepository(this);
        public IJobPosRepository JobPos => _jobPos ??= new JobPosRepository(this);
        public IShiftRuleRepository ShiftRule => _shiftRule ??= new ShiftRuleRepository(this);
        public IEmpDepartmentRepository EmpDepartment =>
            _empDepartment ??= new EmpDepartmentRepository(this);
        public ISecurityRepository Security => _security ??= new SecurityRepository(this);
        public IMethodPayRepository MethodPay => _methodPay ??= new MethodPayRepository(this);
        public IPayMethReportCatRepository PayMethReportCat =>
            _payMethReportCat ??= new PayMethReportCatRepository(this);

        public IPromoRepository Promo => _promo ??= new PromoRepository(this);
        public IPromoCatRepository PromoCat => _promoCat ??= new PromoCatRepository(this);
        public IPromoReportCatRepository PromoReportCat =>
            _promoReportCat ??= new PromoReportCatRepository(this);
        public IPromoGrpRepository PromoGrp => _promoGrp ??= new PromoGrpRepository(this);
        public IPromoGrpDetailRepository PromoGrpDetail =>
            _promoGrpDetail ??= new PromoGrpDetailRepository(this);
    }
}
