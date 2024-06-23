using BikeStores2.Application.Services;
using BikeStores2.Frontend;
using BikeStores2.Infrastructure.Data;
using BikeStores2.Infrastructure.ExternalServices;
using TabBlazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDatabaseService(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddHttpClients();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<HostEnvironmentService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<PDFService>();

builder.Services.AddTabler();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
