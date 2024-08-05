using webapinet6.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();


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
app.UseCors("CorsPolicy");
app.Run(async context => { await context.Response.WriteAsync("hello world"); }) ;
//app.UseAuthorization();
//app.MapControllers();

app.Run();

