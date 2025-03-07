using BlogMicroservice.ApiGateway.Extensions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthServiceAuthentication(builder.Configuration);


builder.Services.AddOcelot();






var app = builder.Build();

app.UseOcelot();

app.Run();
