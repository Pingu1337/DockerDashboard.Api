using Domain;
using Host.Authentication;
using Host.Startup;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiKeyAuthentication(builder.Configuration);
builder.Services.AddSwaggerGen(c =>
    {
        c.IncludeXmlComments(Paths.XmlCommentsFilePath);
        c.AddApiKeyAuthentication();
    }
);

builder.Services.AddDomain(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly)
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();