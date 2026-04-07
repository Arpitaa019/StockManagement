using StockManagement.Entity.DataHelper;
using StockManagement.Interface;
using StockManagement.Repository;
using StockManagement.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<DbHelper>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Product
builder.Services.AddScoped<IProductRepository>(_ => new ProductRepository(connectionString));
builder.Services.AddScoped<IProductService, ProductService>();

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

// IMRInfo
builder.Services.AddScoped<IIMRInfoRepository>(_ => new IMRInfoRepository(connectionString));
builder.Services.AddScoped<IIMRInfoService, IMRInfoService>();

// InvoiceInfo
builder.Services.AddScoped<IInvoiceInfoRepository>(_ => new InvoiceInfoRepository(connectionString));
builder.Services.AddScoped<IInvoiceInfoService, InvoiceInfoService>();

// RequestForApprovalInfo
builder.Services.AddScoped<IRequestForApprovalInfoRepository>(_ => new RequestForApprovalInfoRepository(connectionString));
builder.Services.AddScoped<IRequestForApprovalInfoService, RequestForApprovalInfoService>();

// DailyMaterialInfo + Detail
builder.Services.AddScoped<IDailyMaterialInfoRepository>(_ => new DailyMaterialInfoRepository(connectionString));
builder.Services.AddScoped<IDailyMaterialInfoService, DailyMaterialInfoService>();
builder.Services.AddScoped<IDailyMaterialDetailRepository>(_ => new DailyMaterialDetailRepository(connectionString));
builder.Services.AddScoped<IDailyMaterialDetailService, DailyMaterialDetailService>();

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
pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
