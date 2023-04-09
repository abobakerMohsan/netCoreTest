using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
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

//builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddApplicationServices();

builder.Services.AddHealthChecks()
              .AddDbContextCheck<ProductDbContext>();

//services.AddScoped<ICurrentUserService, CurrentUserService>();

//builder.Services.AddSingleton<IDocumentExecuter, SubscriptionDocumentExecuter>();
//var connectionString = Configuration.GetConnectionString("ConferencePlannerDb");
//services.AddDbContext<ApplicationDbContext>((serviceProvider, optionsBuilder) => {
//    optionsBuilder.UseNpgsql(connectionString,
//        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
//    optionsBuilder.UseApplicationServiceProvider(serviceProvider);

//}, ServiceLifetime.Transient);





builder.Services.AddTransient<ProductDbContext>(provider => provider.GetService<ProductDbContext>());

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//builder.Services.AddSingleton<ISchema, AppSchema>();

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

//builder.Services.AddGraphQL(options =>
//                    options.ConfigureExecution((opt, next) =>
//                    {
//                        opt.EnableMetrics = true;
//                        return next(opt);
//                    }).AddSystemTextJson()
//                );



//builder.Services
//    .AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

builder.Services.AddControllers()
         // .AddNewtonsoftJson()
          .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IProductDbContext>());



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServer().AddDeveloperSigningCredential();



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
   // app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLNetProject v1"));
   // app.UseGraphQLAltair();
}

//app.UseCustomExceptionHandler();
//app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseOpenApi();


app.UseAuthentication();
app.UseIdentityServer();

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
