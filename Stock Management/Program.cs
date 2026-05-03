using StockManagement.Entity.DataHelper;
using StockManagement.Interface;
using StockManagement.Repository;
using StockManagement.Service;
using StockManagement.Services;
using StockManagement.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<DbHelper>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");



// Employee
builder.Services.AddScoped<IEmployeeRepository>(_ => new EmployeeRepository(connectionString));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// User
builder.Services.AddScoped<IUserRepository>(_ => new UserRepository(connectionString));
builder.Services.AddScoped<IUserService, UserService>();

// AdminInfo
builder.Services.AddScoped<IAdminInfoRepository>(_ => new AdminInfoRepository(connectionString));
builder.Services.AddScoped<IAdminInfoService, AdminInfoService>();

// RFPInfo
builder.Services.AddScoped<IRFPInfoRepository>(_ => new RFPInfoRepository(connectionString));
builder.Services.AddScoped<IRFPInfoService, RFPInfoService>();

// RFQInfo
builder.Services.AddScoped<IRFQInfoRepository>(_ => new RFQInfoRepository(connectionString));
builder.Services.AddScoped<IRFQInfoService, RFQInfoService>();

// IMIRCumulative (Imir) - cumulative records for inspected/approved items
builder.Services.AddScoped<IIMIRCumulativeRepository>(_ => new ImirRepository(connectionString));
builder.Services.AddScoped<IIMIRCumulativeService, IMIRCumulativeService>();

// InvoiceInfo
builder.Services.AddScoped<IInvoiceInfoRepository>(_ => new InvoiceInfoRepository(connectionString));
builder.Services.AddScoped<IInvoiceInfoService, InvoiceInfoService>();

// RequestForApprovalInfo
builder.Services.AddScoped<IRequestForApprovalInfoRepository>(_ => new RequestForApprovalInfoRepository(connectionString));
builder.Services.AddScoped<IRequestForApprovalInfoService, RequestForApprovalInfoService>();

// DMR (Daily Material Report) - master and detail repositories
builder.Services.AddScoped<IDMRRepository>(_ => new DMRRepository(connectionString));
builder.Services.AddScoped<IDailyMaterialInfoService, DailyMaterialInfoService>();
builder.Services.AddScoped<IDMRDetailRepository>(_ => new DMRDetailRepository(connectionString));
builder.Services.AddScoped<IDailyMaterialDetailService, DailyMaterialDetailService>();

// Vendor
builder.Services.AddScoped<IVendorRepository>(_ => new VendorRepository(connectionString));
builder.Services.AddScoped<IVendorService, VendorService>();

// Sapcode
builder.Services.AddScoped<ISapcodeRepository>(_ => new SapcodeRepository(connectionString));
builder.Services.AddScoped<ISapcodeService, SapcodeService>();

// PurchaseRequest
builder.Services.AddScoped<IPurchaseRequestRepository>(_ => new PurchaseRequestRepository(connectionString));
builder.Services.AddScoped<IPurchaseRequestService, PurchaseRequestService>();

// PurchaseOrder
builder.Services.AddScoped<IPurchaseOrderRepository>(_ => new PurchaseOrderRepository(connectionString));
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

// Material Allocation (Lines/Spools/Components) - static for now
builder.Services.AddScoped<ILineRepository, StockManagement.Repository.LineRepository>();
builder.Services.AddScoped<ILineService, StockManagement.Service.LineService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
name: "default",
pattern: "{controller=MatchFrontAnalysis}/{action=MatchFrontAnalysis}/{id?}");

app.Run();
