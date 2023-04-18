using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Persistence;
using Products.Application;
using Products.Infrastructure;
using System;
using Projects.Api.Filters;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//using Products.Application.Features.Users.Commands.CreateUser;

using Products.Api.GraphQL.Schemas;
using MediatR;
using System.Reflection;
using GraphQL;
using GraphQL.Server;
//using GraphQL.MicrosoftDI;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQL.Server.Ui.Playground;
using Products.Application.Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddInfrastructure(configuration, builder.Environment);
builder.Services.AddPersistence(configuration);
builder.Services.AddApplication();


builder.Services.AddHealthChecks()
              .AddDbContextCheck<ProductDbContext>();



builder.Services.AddTransient<ProductDbContext>(provider => provider.GetService<ProductDbContext>());

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//GraphQL
builder.Services.AddScoped<AppSchema>();
// add notes schema
//builder.Services.AddSingleton<ISchema, AppSchema>(services => new AppSchema(new SelfActivatingServiceProvider(services)));
// register graphQL
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true;
})
    .AddSystemTextJson()
    .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped);


builder.Services.AddControllers()
          // .AddNewtonsoftJson()
          .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IProductDbContext>());



//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddIdentityServer().AddDeveloperSigningCredential();



#region ADICIONANDO LOGIN

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "DevFreela.API",
//        Version = "v1",
//        Description = "Repository developed during the ASP .NET Core Training course maintained by the company Luis Dev. In this project, concepts of development of Web APIs using .NET 6, Clean Architecture, CQRS, Entity Framework Core, Dapper, Repository Pattern, Unit Tests, Authentication and Authorization with JWT, Messaging and Microservices were applied."
//    });

//    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

//    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

//    //c.IncludeXmlComments(xmlPath);

//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "JWT Authorization header usando o esquema Bearer."
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                 {
//                     {
//                           new OpenApiSecurityScheme
//                             {
//                                 Reference = new OpenApiReference
//                                 {
//                                     Type = ReferenceType.SecurityScheme,
//                                     Id = "Bearer"
//                                 }
//                             },
//                             new string[] {}
//                     }
//                 });
//});

#region PARA ADICIONAR AUTENTICAÇÃO

//builder.Services
//  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//  .AddJwtBearer(options =>
//  {
//      options.TokenValidationParameters = new TokenValidationParameters
//      {
//          ValidateIssuer = true,
//          ValidateAudience = true,
//          ValidateLifetime = true,
//          ValidateIssuerSigningKey = true,

//          ValidIssuer = builder.Configuration["JWT:Issuer"],
//          ValidAudience = builder.Configuration["JWT:Audience"],
//          IssuerSigningKey = new SymmetricSecurityKey
//        (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//      };
//  });

#endregion

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLNetProject v1"));
    // app.UseGraphQLAltair();
}

//app.UseCustomExceptionHandler();
//app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseRouting();
//Enable CORS
app.UseCors("AllowAll");
app.UseHealthChecks("/health");

//app.UseAuthentication();
//app.UseIdentityServer();
app.UseAuthorization();


app.MapControllers();
app.UseGraphQL<AppSchema>("/ui/graphal");
app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
//app.UseGraphQL();
//app.UseGraphQL<ISchema>("/ui/graphal");
//app.UseGraphQL<AppSchema>("/ui/graphal");
//app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
//app.UseGraphQLPlayground("/ui/graphal");


app.Run();



//namespace Products.Api
//{
//    public static class Program
//    {
//        public static void Main(string[] args)
//        {
//            //Read Configuration from appSettings
//            var config = new ConfigurationBuilder()
//                .AddJsonFile("appsettings.json")
//                .Build();

//            //Initialize Logger
//            Log.Logger = new LoggerConfiguration()
//                .ReadFrom.Configuration(config)
//                .WriteTo.Console()
//                .CreateLogger();

//            var host = CreateHostBuilder(args).Build();
//            using (var scope = host.Services.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
//                try
//                {
//                    Log.Information("Application Starting");
//                }
//                catch (Exception ex)
//                {
//                    Log.Warning(ex, "An error occurred starting the application");
//                }
//                finally
//                {
//                    Log.CloseAndFlush();
//                }
//            }
//            host.Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//            .UseSerilog() //Uses Serilog instead of default .NET Logger
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.UseStartup<Startup>();
//            });
//    }
//}