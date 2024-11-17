
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddCarter();
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));

});

var app = builder.Build();

// Configure the http request pipeline 

app.MapCarter();

app.Run();
