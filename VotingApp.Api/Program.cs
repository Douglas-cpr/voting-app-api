using VotingApp.Application.Persistence;
using VotingApp.Infra.Persistence;
using BuberDinner.Application;
using BuberDinner.Infraestructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfraestructure();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
};



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
