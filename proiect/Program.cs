using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Helpers;
using proiect.Helpers.JwtUtils;
using proiect.Helpers.Middleware;
using proiect.Helpers.Seeders;
using proiect.Repositories.DatabaseRepository;
using proiect.Services.AddressService;
using proiect.Services.ItemService;
using proiect.Services.OrderItemService;
using proiect.Services.OrderService;
using proiect.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositories
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();

//Services
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderItemService, OrderItemService>();

//Seeder
builder.Services.AddTransient<AdminSeeder>();

//Auth
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient<IJwtUtils, JwtUtils>();

var app = builder.Build();
SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseMiddleware<JwtMiddleware>();

app.Run();

void SeedData(IHost app)
{
    var ScopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = ScopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<AdminSeeder>();
        service.SeedInitialAdmin();
    }
}
