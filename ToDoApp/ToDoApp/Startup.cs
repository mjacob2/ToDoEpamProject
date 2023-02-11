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
