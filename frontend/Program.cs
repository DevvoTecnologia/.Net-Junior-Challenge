var builder = WebApplication.CreateBuilder(args);

// Habilita Razor Pages
builder.Services.AddRazorPages();

// Adiciona HttpClient para chamadas HTTP
builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
