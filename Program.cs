using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using League.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRazorPages();
builder.Services.AddDbContext<LeagueContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("LeagueContext")));

var app = builder.Build();
CreateDbIfNotExists(app);

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
//Allow usage of cookies.
app.UseSession();
app.MapRazorPages();
if (Environment.GetEnvironmentVariable("HTTPS_PORT") is string https_port)
{
    string url = $"https://localhost:{https_port}/{Environment.GetEnvironmentVariable("GOTO_PAGE") ?? ""}";
    Console.WriteLine($"Opening '{url}'");
    Process.Start(new ProcessStartInfo
    {
        FileName = url,
        UseShellExecute = true
    });
}
app.Run();

static void CreateDbIfNotExists(IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LeagueContext>();
    // context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}