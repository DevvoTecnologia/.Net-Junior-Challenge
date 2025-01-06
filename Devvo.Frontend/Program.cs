using Devvo.Common.DataTransferObject;
using Devvo.Frontend.Services;

var API_URL = Environment.GetEnvironmentVariable("API_URL") ?? throw new ArgumentException("É necessário definir a URL da API na variável de ambiente API_URL");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEntityCrudService<AnelDto>, EntityCrudService<AnelDto>>(_ => {
    return new EntityCrudService<AnelDto>(API_URL, "aneis");
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
