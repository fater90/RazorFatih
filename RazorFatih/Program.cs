using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RazorFatih.Data; // AppDbContext'inizin bulunduðu namespace
using RazorFatih.Components; // App.razor'un bulunduðu namespace (teyit ettiðiniz gibi)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Razor Pages ve Blazor Server için temel desteði saðlar.
builder.Services.AddRazorPages();

// Blazor Components'ý ekler ve interaktif Server render modunu etkinleþtirir.
// Bu, App.razor'un ana giriþ noktasý olduðunu belirtir.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// SQLite baðlantý dizesini kullanarak AppDbContext'i servislere ekler.
// appsettings.json dosyasýndan "DefaultConnection" okunur.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Eðer projenizi yeni oluþturduysanýz ve varsayýlan olarak gelen WeatherForecastService varsa, kaldýrabilirsiniz.
// builder.Services.AddSingleton<WeatherForecastService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Hata oluþtuðunda hata sayfasýna yönlendirme.
    app.UseExceptionHandler("/Error");
    // HTTPS isteklerini HTTP'ye yönlendirme.
    app.UseHsts();
}

// HTTPS yönlendirmeyi kullanýr.
app.UseHttpsRedirection();

// Statik dosyalarýn (CSS, JS, resimler vb.) sunulmasýný saðlar.
app.UseStaticFiles();

// Yönlendirme middleware'ini kullanýr.
app.UseRouting();

// Anti-forgery token desteðini ekler. Bu, form gönderme ve bazý Blazor etkileþimli bileþen hatalarýný engeller.
// UseRouting'den sonra, UseAuthorization'dan (eðer varsa) önce olmalýdýr.
app.UseAntiforgery();

// Blazor Web App'te componentlerin routinge nasýl baðlanacaðý.
// App bileþeninin ana giriþ noktasý olduðunu ve Server render modunu kullanacaðýný belirtir.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();