using myPortal.Authentication.Api.Endpoint;
using myPortal.Authentication.Infrastructure;
using myPortal.Authentication.Application;
using myPortal.Authentication.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddRequestService();
builder.Services.AddInfrastructureServices();
builder.Services.AddPortalDbServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddFirebaseServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();


builder.Services.AddCors(option => {
    option.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins("https://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseMiddleware<FirebaseAuthenticationMiddleware>();

app.UseAuthorization();



app.MapAuthEndpoint();
app.MapCustomerAccountEndpoint();
app.MapTenantEndpoint();

app.Run();

