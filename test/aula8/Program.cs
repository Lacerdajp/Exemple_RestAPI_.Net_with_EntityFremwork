using aula8.Models;
using aula8.Models.Context;
using aula8.Repositorys;
using aula8.Repositorys.Generic;
using aula8.Repositorys.Implementations;
using aula8.Services;
using aula8.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var conexao = builder.Configuration.GetConnectionString("SQLConnection");
builder.Services.AddDbContext<SqlContext>(x => x.UseSqlServer(
     builder.Configuration["ConnectionString:SQLConnection"]
    ));
builder.Services.AddApiVersioning();
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonServices, PersonServiceImplementation>();
builder.Services.AddScoped<IBookServices, BookServiceImplementations>();
//builder.Services.AddScoped<IRepository, PersonRespositoryImplmentation>();
//builder.Services.AddScoped<IBookRepository, BookRepositoryImplementation>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

}).AddXmlSerializerFormatters();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
