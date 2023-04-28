using aula8.Configurations;
using aula8.Hypermedia.Enricher;
using aula8.Hypermedia.Filters;
using aula8.Models;
using aula8.Models.Context;
using aula8.Repositorys;
using aula8.Repositorys.Generic;
using aula8.Repositorys.Implementations;
using aula8.Services;
using aula8.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;

var filterOptions=new HyperMediaFilterOptions();
var builder = WebApplication.CreateBuilder(args);
var tokenConfigurations = new TokenConfiguration();
// Add services to the container.
var conexao = builder.Configuration.GetConnectionString("SQLConnection");
builder.Services.AddDbContext<SqlContext>(x => x.UseNpgsql(
     builder.Configuration["ConnectionString:SQLConnection"]
    ));
builder.Services.AddApiVersioning();
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddScoped<IPersonServices, PersonServiceImplementation>();
builder.Services.AddScoped<IBookServices, BookServiceImplementations>();
builder.Services.AddScoped<ILoginServices, LoginServiceImplementations>();
builder.Services.AddTransient<ITokenInterface, TokenImplements>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRespositoryImplmentation>();
//builder.Services.AddScoped<IBookRepository, BookRepositoryImplementation>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());
builder.Services.AddSingleton(filterOptions);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
    
}).AddXmlSerializerFormatters();
builder.Services.AddSwaggerGen();
new ConfigureFromConfigurationOptions<TokenConfiguration>(
    builder.Configuration.GetSection("TokenConfigurations")
    ).Configure(tokenConfigurations);

builder.Services.AddSingleton(tokenConfigurations);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfigurations.Issuer,
        ValidAudience = tokenConfigurations.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
    };
});
builder.Services.AddAuthorization(
    auth =>
    {
        auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser().Build());
    }
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();
app.UseAuthorization(); 
app.UseCors();
app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=values}/v{version}/{id?}");
app.Run();
