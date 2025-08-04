
using HahnSoftware.Application;
using HahnSoftware.Application.Books.Commands;
using HahnSoftware.Application.Books.QueriesHandlers;
using HahnSoftware.Infrastructure;
using MediatR;
using System.Reflection.Metadata;

namespace HahnSoftware.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Dependency injection
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            // Enable the CORS for the front-end
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AngularFrontEnd", policy =>
                {
                    policy.WithOrigins("http://localhost:4200");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowCredentials();
                });
            });

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

            app.UseCors("AngularFrontEnd");

            app.Run();
        }
    }
}