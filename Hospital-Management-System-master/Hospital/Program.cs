using Hospital;

var builder = WebApplication.CreateBuilder(args);

// Register Startup
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure middleware
startup.Configure(app, app.Environment);

app.Run();