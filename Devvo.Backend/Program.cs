using Devvo.Common.Model;
using Devvo.Common.DataTransferObject;
using Devvo.Backend.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var CONNECTION_STRING = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new ArgumentException("É necessário definir a string de conexão com o SQL Server na variável de ambiente CONNECTION_STRING");

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.AllowTrailingCommas = true;
    });

builder.Services.AddAutoMapper(config => {
    config.CreateMap<Entity, EntityDto>().ReverseMap();
    config.CreateMap<Anel, AnelDto>().ReverseMap();
});

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new () {
        Title = "Devvo API",
        Version = "v1",
        Description = "API para o Desafio Fullstack: A Forja dos Anéis de Poder",
        Contact = new ()
        {
            Name = "Brendo Costa",
            Email = "brendocosta@id.uff.br",
            Url = new Uri("https://github.com/BrendoCosta")
        },
        License = new ()
        {
            Name = "MIT",
            Url = new Uri("https://spdx.org/licenses/MIT.html")
        }
    });
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(CONNECTION_STRING);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Devvo API V1");
});
app.Run();
