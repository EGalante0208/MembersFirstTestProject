using MembersFirstTestProject.Orchestrator.Implementations;
using MembersFirstTestProject.Orchestrator.Interfaces;
using MembersFirstTestProject.Repository.Implementations;
using MembersFirstTestProject.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(ITransactionOrchestration), typeof(TransactionOrchestration));
builder.Services.AddScoped(typeof(ITransactionRepository), typeof(TransactionRepository));
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = false);

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