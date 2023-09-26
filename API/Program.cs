using Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureApi(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(p => p
    .AllowAnyOrigin()
    .AllowAnyHeader() 
    .AllowAnyMethod()
);

app.MapControllers();

app.Run();
