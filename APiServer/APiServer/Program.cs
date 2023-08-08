using APiServer.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProducto, Producto>();
builder.Services.AddScoped<ICliente, ClientesL>();
builder.Services.AddScoped<IArticulos, ArticulosL>();
builder.Services.AddScoped<ITienda, TiendaL>();
builder.Services.AddScoped<IVentasL,VentasL>();
builder.Services.AddCors(options
    => {
        options.AddPolicy("nuevo", app => {
            app.AllowAnyOrigin()
            .AllowAnyHeader().AllowAnyMethod();
        });
    });
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APiServer v1"));

app.UseCors("nuevo");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
