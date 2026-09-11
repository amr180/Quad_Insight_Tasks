
using TaskManagement.API.Middleware;
using TaskManagement.Application;
using TaskManagement.Infrastructure;


var builder = WebApplication.CreateBuilder(args);


// بقي دول في Application (Services, MediatR, FluentValidation, Pipeline Behaviors)
builder.Services.AddApplicationServices();

// بقو في Infrastructure (DbContext, Repositories, UnitOfWork)
builder.Services.AddInfrastructureServices(builder.Configuration);

// Controllers
builder.Services.AddControllers();
// OpenAPI
builder.Services.AddOpenApi();

// Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - لازم عشان الفرونت (Angular على localhost:4200) يقدر يكلم الـ API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// HTTP Request Pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
   
}
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthorization();
app.MapControllers();


app.Run();


// Database
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));=> moved to Infrastructure project in DependencyInjection.cs

// Repositories
//builder.Services.AddScoped<IUserRepository, UserRepository>();=> moved to Infrastructure project in DependencyInjection.cs
//builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Unit Of Work
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();=> moved to Infrastructure project in DependencyInjection.cs


// Services


//builder.Services.AddScoped<IUserService, UserService>(); ==> moved to Application project in DependencyInjection.cs
//builder.Services.AddScoped<ITaskService, TaskService>();=>changed to use MediatR instead of service layer, so no need for this service anymore

//builder.Services.AddMediatR
//    (cfg =>cfg.RegisterServicesFromAssembly(typeof(CreateTaskCommandHandler).Assembly));=> moved to Application project in DependencyInjection.cs

//FluentValidation
//builder.Services.AddValidatorsFromAssembly(typeof(CreateTaskCommand).Assembly);=> moved to Application project in DependencyInjection.cs
// Pipeline Behavior 
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));=> moved to Application project in DependencyInjection.cs