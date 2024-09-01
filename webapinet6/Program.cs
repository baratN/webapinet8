using webapinet6.Extensions;
using NLog;
using webapinet6.Controllers;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat
    (Directory.GetCurrentDirectory(),
    "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.AddControllers();


// Add services to the container.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.MapControllers();


//USE IS TO CALL THE MIDDLEWARES 
#region USE/MAP
//app.Use(async (context, next) =>
//{
//await context.Response.WriteAsync(Environment.NewLine + "first use");
//await next();
//});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync(Environment.NewLine + "second use");
//    await next.Invoke();
//});


////MAP BRANCHES THE MIDDLEWARE COMPONENTS 
////ANYTHING AFTER THE MAP BRANCH WILL NOT BE EXECUTED
//app.Map("/maprequest", builder =>
//{

//    builder.Use(async (context, next) =>
//    {
//        await context.Response.WriteAsync(Environment.NewLine + "first use in Map");
//        await next.Invoke();
//    });

//    builder.Use(async (context, next) =>
//    {
//        await context.Response.WriteAsync(Environment.NewLine + "second use in Map");
//        await next.Invoke();
//    });

//    //this run method inside the Map request is mandatory for the Map request to work.
//    builder.Run(async context =>
//    {
//        Console.WriteLine(Environment.NewLine + $"Map branch response to the client in the Run method");
//        await context.Response.WriteAsync(Environment.NewLine + "Hello from the map branch.");
//    });
//});

//app.Map("/getemployee", builder =>
//{

//    builder.Use(async (context, next) =>
//    {
//        await context.Response.WriteAsync(Environment.NewLine + "first use in getemployee Map");
//        await next.Invoke();
//    });

//    builder.Use(async (context, next) =>
//    {
//        await context.Response.WriteAsync(Environment.NewLine + "second use in getemployee Map");
//        await next.Invoke();
//    });
//    builder.Run(async context =>
//    {
//        await context.Response.WriteAsync(Environment.NewLine + "Hello from the getemployee map branch.");
//    });
//}); 
#endregion

//app.UseAuthorization();
//app.MapControllers();

app.Run();

