using onChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002")
            .AllowCredentials();
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Allow All",
//        builder =>
//        {
//            builder
//            .AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//        });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow All");

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("ClientPermission");
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.UseWebSockets();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("Hubs/MyHub");
});

app.Run();
