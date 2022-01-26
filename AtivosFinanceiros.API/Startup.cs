using AtivosFinanceiros.API.ViewModels;
using AtivosFinanceiros.Domain.Entities;
using AtivosFinanceiros.Infra.Context;
using AtivosFinanceiros.Infra.Interfaces;
using AtivosFinanceiros.Infra.Repositories;
using AtivosFinanceiros.Services.DTO;
using AtivosFinanceiros.Services.Interfaces;
using AtivosFinanceiros.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtivosFinanceiros.API
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

            services.AddSingleton(d => Configuration);
            services.AddDbContext<AtivosFinanceirosContext>(options => 
                            options.UseSqlServer(Configuration["ConnectionStrings:AtivosFinanceiros"]), ServiceLifetime.Transient);

            services.AddScoped<IAcaoRepository, AcaoRepository>();
            services.AddScoped<IFIIRepository, FIIRepository>();

            services.AddScoped<IBaseService<AcaoDTO>, AcaoService>();
            services.AddScoped<IBaseService<FIIDTO>, FIIService>();

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Acao, AcaoDTO>().ReverseMap();
                cfg.CreateMap<FII, FIIDTO>().ReverseMap();
                cfg.CreateMap<CriarViewModel, FIIDTO>().ReverseMap();
                cfg.CreateMap<AtualizarViewModel, FIIDTO>().ReverseMap();
                cfg.CreateMap<CriarViewModel, AcaoDTO>().ReverseMap();
                cfg.CreateMap<AtualizarViewModel, AcaoDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "AtivosFinanceiros.API", 
                    Version = "v1",
                    Description = "Ativos Financeiros Api realizado com .Net 5, EntityFrameworkCore, FluentValidation e AutoMapper"
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AtivosFinanceiros.API v1"));
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
