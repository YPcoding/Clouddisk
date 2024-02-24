using CInfrastructure.Persistence;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterSerilog();
builder.Services.AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices()
    .AddWebAPIServices()
    .AddAutoMapper();

var app = builder.Build();

app.UseInfrastructure(builder.Configuration);

//if (app.Environment.IsDevelopment())
//{
//    //��ʼ����������
//    using (var scope = app.Services.CreateScope())
//    {
//        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
//        await initializer.InitialiseAsync();
//        await initializer.SeedAsync();
//    }
//}
//��ʼ����������
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await initializer.InitialiseAsync();
    await initializer.SeedAsync();
}
await app.RunAsync();