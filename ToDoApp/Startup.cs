using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ToDoEpam.DataAccess;
using ToDoEpam.ApplicationServices.API.Domain.Responses;
using ToDoEpam.DataAccess.CQRS;
using FluentValidation.AspNetCore;
using ToDoEpam.ApplicationServices.API.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp
{
        public class Startup
        {
                public Startup(IConfiguration configuration)
                {
                        Configuration = configuration;
                }



                public IConfiguration Configuration { get; }
                
                public void ConfigureServices(IServiceCollection services)
                {
                        services.AddFluentValidationAutoValidation();
                        services.AddFluentValidationClientsideAdapters();
                        services.AddValidatorsFromAssemblyContaining<AddToDoListRequestValidator>();

                        // Lests enter the controller on request validation
                        services.Configure<ApiBehaviorOptions>(options =>
                        {
                                options.SuppressModelStateInvalidFilter = true;
                        });

                        services.AddTransient<IQueryExecutor, QueryExecutor>();

                        services.AddTransient<ICommandExecutor, CommandExecutor>();

                        services.AddMediatR(typeof(ResponseBase<>));

                        services.AddDbContext<ToDoAppStorageContext>(
                opt => opt.UseSqlServer(this.Configuration.GetConnectionString("ToDoAppEpamConnection")));

                        services.AddControllers();

                        services.AddSwaggerGen(c =>
                        {
                                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoApp", Version = "v1" });
                        });
                }

                public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                {
                        if (env.IsDevelopment())
                        {
                                app.UseDeveloperExceptionPage();
                                app.UseSwagger();
                                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoApp v1"));
                        }

                        app.UseHttpsRedirection();

                        app.UseRouting();

                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                                endpoints.MapControllers();
                        });
                }
        }
}
