using MonitoringManagerAPI.Extensions.Register;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
