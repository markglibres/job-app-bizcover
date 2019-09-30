using System.Reflection;
using AutoMapper;
using BizCover.Api.Cars.Application.Commands.Handlers;
using BizCover.Api.Cars.Application.Mappers;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Api.Cars.Application.Services;
using BizCover.Repository.Cars;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BizCover.Api.Cars
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
            services.AddAutoMapper(typeof(Startup), typeof(CarMapperProfile));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "BizCover Car API", Version = "v1"}); });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(AddCarCommandHandler).Assembly);

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarRepository, CarRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "BizCover Car API V1"); });

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}