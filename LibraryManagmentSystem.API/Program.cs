using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Queries;
using LibraryManagmentSystem.Application.Books.Queries;
using LibraryManagmentSystem.Infrastructure.Persistance.DB;
using LibraryManagmentSystem.Infrastructure.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ApplicationContext>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllAuthorsQuery).Assembly)
    );
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllBooksQuery).Assembly)
);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.Run();