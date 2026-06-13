using System.Data;
using BackOffice.Controllers.Attribute;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Coupon;
using BackOffice.Middlewares;
using BackOffice.Repositories;
using BackOffice.Repositories.Base;
using BackOffice.Repositories.Coupon;
using BackOffice.Services;
using BackOffice.Services.Coupon;
using BackOffice.Utils;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsApi",
        policy =>
        {
            policy
                .SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        }
    );
});

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Không tìm thấy chuỗi kết nối 'DefaultConnection' trong appsettings.json"
    );

SqlMapper.AddTypeMap(typeof(string), DbType.String);
DefaultTypeMap.MatchNamesWithUnderscores = true;

SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

builder.Services.AddNpgsqlDataSource(connectionString);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<HeaderSwagger>();
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//* Đăng ký các Services lõi (Core/Infrastructure)
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//* Đăng ký Services Nghiệp vụ
builder.Services.AddScoped<IAutoIncRepository, AutoIncRepository>();

builder.Services.AddScoped<ISysInfoRepository, SysInfoRepository>();
builder.Services.AddScoped<SysInfoService>();
builder.Services.AddScoped<IRevenueCenterRepository, RevenueCenterRepository>();
builder.Services.AddScoped<RevenueCenterService>();
builder.Services.AddScoped<ISummaryGroupRepository, SummaryGroupRepository>();
builder.Services.AddScoped<SummaryGroupService>();
builder.Services.AddScoped<IReportCatRepository, ReportCatRepository>();
builder.Services.AddScoped<ReportCatService>();
builder.Services.AddScoped<IReportTypeRepository, ReportTypeRepository>();
builder.Services.AddScoped<ReportTypeService>();
builder.Services.AddScoped<ISalesTypeRepository, SalesTypeRepository>();
builder.Services.AddScoped<SalesTypeService>();
builder.Services.AddScoped<IPixelLookupRepository, PixelLookupRepository>();
builder.Services.AddScoped<PixelLookupService>();

builder.Services.AddScoped<IRefundReasonRepository, RefundReasonRepository>();
builder.Services.AddScoped<RefundReasonService>();

builder.Services.AddScoped<IStationInfoRepository, StationInfoRepository>();
builder.Services.AddScoped<StationInfoService>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<SectionService>();
builder.Services.AddScoped<IPrintPortRepository, PrintPortRepository>();
builder.Services.AddScoped<PrintPortService>();
builder.Services.AddScoped<IFormTemplateRepository, FormTemplateRepository>();
builder.Services.AddScoped<FormTemplateService>();
builder.Services.AddScoped<ITypeOfProdRepository, TypeOfProdRepository>();
builder.Services.AddScoped<TypeOfProdService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IProductComboRepository, ProductComboRepository>();
builder.Services.AddScoped<ProductComboService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<QuestionService>();
builder.Services.AddScoped<IOrderCatRepository, OrderCatRepository>();
builder.Services.AddScoped<OrderCatService>();
builder.Services.AddScoped<IMenuOrderPosRepository, MenuOrderPosRepository>();
builder.Services.AddScoped<MenuOrderPosService>();
builder.Services.AddScoped<IMenuProdPosRepository, MenuProdPosRepository>();
builder.Services.AddScoped<MenuProdPosService>();
builder.Services.AddScoped<IMultiMenuNamesRepository, MultiMenuNamesRepository>();
builder.Services.AddScoped<MultiMenuNamesService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IJobPosRepository, JobPosRepository>();
builder.Services.AddScoped<JobPosService>();
builder.Services.AddScoped<IPayRollRepository, PayRollRepository>();

builder.Services.AddScoped<IEmpDepartmentRepository, EmpDepartmentRepository>();
builder.Services.AddScoped<EmpDepartmentService>();
builder.Services.AddScoped<IShiftRuleRepository, ShiftRuleRepository>();
builder.Services.AddScoped<ShiftRuleService>();
builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();
builder.Services.AddScoped<SecurityService>();

builder.Services.AddScoped<IMethodPayRepository, MethodPayRepository>();
builder.Services.AddScoped<MethodPayService>();
builder.Services.AddScoped<IPayMethReportCatRepository, PayMethReportCatRepository>();
builder.Services.AddScoped<PayMethReportCatService>();

builder.Services.AddScoped<IPromoRepository, PromoRepository>();
builder.Services.AddScoped<PromoService>();

builder.Services.AddScoped<IPromoCatRepository, PromoCatRepository>();
builder.Services.AddScoped<PromoCatService>();

builder.Services.AddScoped<IPromoReportCatRepository, PromoReportCatRepository>();

builder.Services.AddScoped<IPromoGrpRepository, PromoGrpRepository>();
builder.Services.AddScoped<PromoGrpService>();

builder.Services.AddScoped<IPromoGrpDetailRepository, PromoGrpDetailRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//* Middleware
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestMetricsService>();

app.UseCors("CorsApi");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
