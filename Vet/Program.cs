//Para usar MySql como servicio
using Microsoft.EntityFrameworkCore;
//Para usar la conexión con la bd
using Vet.Data;
//Para usar las interfaces
using Vet.Services;

var builder = WebApplication.CreateBuilder(args);
//Para que reciba las peticiones de cualquier origen y método
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Para el mapeo de la carpeta controllers
builder.Services.AddControllers();

//Registramos a MySql como servicio y conectamos al dbcontext
builder.Services.AddDbContext<VetContext> (options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

//Para agregar y usar las interfaces
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IVetRepository, VetRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IQuoteRepository, QuoteRepository>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Agregamos el mapeo
app.MapControllers();

//Para usar los cors 
app.UseCors("AllowAnyOrigin");


app.Run();


