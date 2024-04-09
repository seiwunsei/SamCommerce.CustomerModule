using SamCommerce.CustomerModule.Core.Services;
using SamCommerce.CustomerModule.Data.MySql;
using SamCommerce.CustomerModule.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    var databaseProvider = builder.Configuration.GetValue("DatabaseProvider", "MySql");
    var connectionString = builder.Configuration.GetConnectionString("SamCommerce3");
    switch (databaseProvider)
    {
        case "MySql":
            options.UseMySqlDatabase(connectionString); break;
    }
});

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<Func<ICustomerRepository>>(provider =>
    () => provider.CreateScope().ServiceProvider.GetRequiredService<ICustomerRepository>());
builder.Services.AddSingleton<Func<IMemberRepository>>(provider =>
    () => provider.CreateScope().ServiceProvider.GetRequiredService<ICustomerRepository>());
builder.Services.AddTransient<IMemberSearchService, MemberSearchService>();

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
