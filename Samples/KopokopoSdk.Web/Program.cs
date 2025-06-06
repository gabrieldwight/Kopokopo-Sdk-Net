using KopokopoSdk.Extensions;
using KopokopoSdk.Web.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.Configure<KopokopoApiConfiguration>(options =>
{
    builder.Configuration.GetSection("KopokopoApiConfiguration").Bind(options);
});

#if DEBUG
        builder.Services.AddKopokopoService(KopokopoSdk.Enums.Environment.Sandbox);
#else
        builder.Services.AddKopokopoService(KopokopoSdk.Enums.Environment.Live);
#endif

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
