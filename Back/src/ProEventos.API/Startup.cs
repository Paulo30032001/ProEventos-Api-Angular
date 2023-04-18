using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProEventos.Persistence.Contextos;
using ProEventos.Application;
using ProEventos.Application.Contratos;
using ProEventos.Persistence;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contratos;
namespace ProEventos.API
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
            // UseSqlite=é um DbContextOptionsBuilder então temos criar alguem que recebe esse DbContextOptionsBuilder que no casso é o nosso DbContextOptions(ou DbContextOptionsBuilder tanto faz) ele vai determinar as nossas tabelas no banco 
            services.AddDbContext<ProEventosContext>(
                Options =>
                 Options.UseMySQL(Configuration.GetConnectionString("ProEventos.APIContext")) // por enquanto vamos deixar sem conexão
                 )
                 ;    //  ADICIONAMOS O CONTEXTO 

            //PRIMEIRO INTERFACE DEPOIS A CLASSE QUE A IMPLEMENTA(CUMPRE O CONTRATO)
            services.AddScoped<IEventosService, EventosService>();
            services.AddScoped<IGeralPersistence, GeralPersistence>();  
            services.AddScoped<IEventosPersistence, EventosPersistence>();  
            services.AddControllers()
            .AddNewtonsoftJson(
                    //Configurações de Serialize(converão pra json)
                                        // Quando for uma referencia que gerar um loop 
               x=>x.SerializerSettings.ReferenceLoopHandling= 
               Newtonsoft.Json.ReferenceLoopHandling.Ignore
               //IGNORE
            );
            
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(
              x => x.AllowAnyHeader() // dado de qualquer configuração de cabeçalho do meu header
               .AllowAnyMethod() // vinda de qualquer metodo get,post ...
               .AllowAnyOrigin() // de qualquer origem
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
