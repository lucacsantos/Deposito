using Deposito.Domain.Commands.Handlers;
using Deposito.Domain.Validators;
using Deposito.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();

builder.Services.AddCors(options =>
{ 
    options.AddPolicy("AllowAngular" , 
    policy =>
    {
        policy
         .WithOrigins("http://localhost:4200") 
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});
    

builder.Services.AddSingleton<FirestoreDb>(sp =>
{
    return FirebaseInitializer.InitializeFirestore();
});

builder.Services.AddSingleton<ProductFirestoreService>();
builder.Services.AddSingleton<ClientFirestoreService>();
builder.Services.AddSingleton<OrderFirestoreService>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly);
});

FirebaseInitializer.InitializeFirestore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
