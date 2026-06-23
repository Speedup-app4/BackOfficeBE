using System;
using System.Data;
using BackOffice.Controllers.Attribute;
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
using BackOffice.Middlewares;
using BackOffice.Repositories.Base;
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
using BackOffice.Services.Modules.Coupon;
using BackOffice.Services.Modules.Employees;
using BackOffice.Services.Modules.Menu;
using BackOffice.Services.Modules.Payment;
using BackOffice.Services.Modules.Products;
using BackOffice.Services.Modules.Refund;
using BackOffice.Services.Modules.Report;
using BackOffice.Services.Modules.Station;
using BackOffice.Services.Modules.System;
using BackOffice.Services.Modules.Table;
using BackOffice.Utils;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

//* Repository
builder.Services.AddScoped<IAutoIncRepository, AutoIncRepository>();
builder.Services.AddScoped<ISysInfoRepository, SysInfoRepository>();
builder.Services.AddScoped<IRevenueCenterRepository, RevenueCenterRepository>();
builder.Services.AddScoped<ISummaryGroupRepository, SummaryGroupRepository>();
builder.Services.AddScoped<IReportCatRepository, ReportCatRepository>();
builder.Services.AddScoped<IReportTypeRepository, ReportTypeRepository>();
builder.Services.AddScoped<ISalesTypeRepository, SalesTypeRepository>();
builder.Services.AddScoped<IPixelLookupRepository, PixelLookupRepository>();
builder.Services.AddScoped<IRefundReasonRepository, RefundReasonRepository>();
builder.Services.AddScoped<IStationInfoRepository, StationInfoRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<IPrintPortRepository, PrintPortRepository>();
builder.Services.AddScoped<IFormTemplateRepository, FormTemplateRepository>();
builder.Services.AddScoped<ITypeOfProdRepository, TypeOfProdRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductComboRepository, ProductComboRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IOrderCatRepository, OrderCatRepository>();
builder.Services.AddScoped<IMenuOrderPosRepository, MenuOrderPosRepository>();
builder.Services.AddScoped<IMenuProdPosRepository, MenuProdPosRepository>();
builder.Services.AddScoped<IMultiMenuNameRepository, MultiMenuNameRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmpDepartmentRepository, EmpDepartmentRepository>();
builder.Services.AddScoped<IShiftRuleRepository, ShiftRuleRepository>();
builder.Services.AddScoped<IJobPosRepository, JobPosRepository>();
builder.Services.AddScoped<IPayRollRepository, PayRollRepository>();
builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();
builder.Services.AddScoped<IMethodPayRepository, MethodPayRepository>();
builder.Services.AddScoped<IPayMethReportCatRepository, PayMethReportCatRepository>();
builder.Services.AddScoped<IPromoRepository, PromoRepository>();
builder.Services.AddScoped<IPromoCatRepository, PromoCatRepository>();
builder.Services.AddScoped<IPromoReportCatRepository, PromoReportCatRepository>();
builder.Services.AddScoped<IPromoGrpRepository, PromoGrpRepository>();
builder.Services.AddScoped<IPromoGrpDetailRepository, PromoGrpDetailRepository>();

//* Service
builder.Services.AddScoped<SysInfoService>();
builder.Services.AddScoped<RevenueCenterService>();
builder.Services.AddScoped<SummaryGroupService>();
builder.Services.AddScoped<ReportCatService>();
builder.Services.AddScoped<ReportTypeService>();
builder.Services.AddScoped<SalesTypeService>();
builder.Services.AddScoped<PixelLookupService>();
builder.Services.AddScoped<RefundReasonService>();
builder.Services.AddScoped<StationInfoService>();
builder.Services.AddScoped<SectionService>();
builder.Services.AddScoped<PrintPortService>();
builder.Services.AddScoped<FormTemplateService>();
builder.Services.AddScoped<TypeOfProdService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductComboService>();
builder.Services.AddScoped<QuestionService>();
builder.Services.AddScoped<OrderCatService>();
builder.Services.AddScoped<MenuOrderPosService>();
builder.Services.AddScoped<MenuProdPosService>();
builder.Services.AddScoped<MultiMenuNameService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<JobPosService>();
builder.Services.AddScoped<EmpDepartmentService>();
builder.Services.AddScoped<ShiftRuleService>();
builder.Services.AddScoped<SecurityService>();
builder.Services.AddScoped<MethodPayService>();
builder.Services.AddScoped<PayMethReportCatService>();
builder.Services.AddScoped<PromoService>();
builder.Services.AddScoped<PromoCatService>();
builder.Services.AddScoped<PromoGrpService>();

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
