using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Serilog ile ilgili Appsettings.json a yazdýðýmýz komutlarý konfigüre ettik
IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// Serilog Konfigürasyonu
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();


//// Temel Serilog Konfigürasyonu
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console() // Konsola loglama
//    .WriteTo.File("log.txt") // txt dosyasýna loglama
//    .WriteTo.Seq("http://localhost:5341/") // Seq de loglama
//    .MinimumLevel.Information()
//    .Enrich.WithProperty("ApplicationName","Logging in ASPNETCORE Project") // Enrich ile kendi istediðimiz Propertyleri ekleyebiliyoruz.
//    .Enrich.WithMachineName()
//    .CreateLogger();
//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseSerilogRequestLogging(); // ????

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
