using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RazorFatih.Data; // AppDbContext'inizin bulundu�u namespace
using RazorFatih.Components; // App.razor'un bulundu�u namespace (teyit etti�iniz gibi)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Razor Pages ve Blazor Server i�in temel deste�i sa�lar.
builder.Services.AddRazorPages();

// Blazor Components'� ekler ve interaktif Server render modunu etkinle�tirir.
// Bu, App.razor'un ana giri� noktas� oldu�unu belirtir.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// SQLite ba�lant� dizesini kullanarak AppDbContext'i servislere ekler.
// appsettings.json dosyas�ndan "DefaultConnection" okunur.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// E�er projenizi yeni olu�turduysan�z ve varsay�lan olarak gelen WeatherForecastService varsa, kald�rabilirsiniz.
// builder.Services.AddSingleton<WeatherForecastService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Hata olu�tu�unda hata sayfas�na y�nlendirme.
    app.UseExceptionHandler("/Error");
    // HTTPS isteklerini HTTP'ye y�nlendirme.
    app.UseHsts();
}

// HTTPS y�nlendirmeyi kullan�r.
app.UseHttpsRedirection();

// Statik dosyalar�n (CSS, JS, resimler vb.) sunulmas�n� sa�lar.
app.UseStaticFiles();

// Y�nlendirme middleware'ini kullan�r.
app.UseRouting();

// Anti-forgery token deste�ini ekler. Bu, form g�nderme ve baz� Blazor etkile�imli bile�en hatalar�n� engeller.
// UseRouting'den sonra, UseAuthorization'dan (e�er varsa) �nce olmal�d�r.
app.UseAntiforgery();

// Blazor Web App'te componentlerin routinge nas�l ba�lanaca��.
// App bile�eninin ana giri� noktas� oldu�unu ve Server render modunu kullanaca��n� belirtir.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();