using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Models.Mappers;
using Models.Mappers.Interfaces;
using Repositories;
using Repositories.Connections;
using Repositories.Connections.Interfaces;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;

// Responsavel por fazer as configura��es do projeto

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            services.AddTransient<IEstagTestConnection>(db =>
                new EstagTestConnection(Configuration.GetConnectionString("EstagTest"))
            );

            #region Repositories
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPersonService, PersonService>();
            #endregion

            #region Mappers
            services.AddSingleton<IPersonMapper, PersonMapper>();
            #endregion

            #region [Cors]
            services.AddCors();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            #region [Cors]
            app.UseCors(c => {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
                
            });
            #endregion

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
