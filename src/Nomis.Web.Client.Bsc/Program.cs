using Nomis.Utils.Extensions;
using Nomis.Web.Client.Bsc.Extensions;
using Nomis.Web.Client.Bsc.Managers;
using Nomis.Web.Client.Common.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonConfigs();

builder.Services
    .AddSettings<WebApiSettings>(builder.Configuration)
    .AddTransient<IBscManager, BscManager>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
