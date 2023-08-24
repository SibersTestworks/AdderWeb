var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
builder.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod()
));
var a = builder.Configuration.GetSection("DefaultConnection").Value;
builder.Services.AddDbContext<AdderWebContext>(options =>
        options.UseSqlServer(a));

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));  
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

builder.Services.AddScoped<IUnitOfWork, AdderWebUnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
