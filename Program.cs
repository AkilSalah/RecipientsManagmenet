using Gestion_Destinataire.Data;
using Gestion_Destinataire.Mappers;
using Gestion_Destinataire.Service.Implementation;
using Gestion_Destinataire.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(DestinatairMapper));
builder.Services.AddScoped<IDestinataireService, DestinataireService>();

var app = builder.Build();

// Create database and run migrations with retry logic
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DBContext>();
    var maxRetries = 5;
    var delay = TimeSpan.FromSeconds(5);
    
    for (int i = 0; i < maxRetries; i++)
    {
        try
        {
            context.Database.EnsureCreated();
            Console.WriteLine("Database created/updated successfully");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Attempt {i + 1}: Error creating database: {ex.Message}");
            if (i == maxRetries - 1) throw;
            await Task.Delay(delay);
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Remove HTTPS redirection for Docker
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();