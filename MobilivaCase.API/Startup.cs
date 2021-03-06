using AgileManagement.Persistence.EF;
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
using MobilivaCase.Application;
using MobilivaCase.Core.data;
using MobilivaCase.Core.domain;
using MobilivaCase.Domain;
using MobilivaCase.Domain.models;
using MobilivaCase.Domain.repositories;
using MobilivaCase.Infrastructure;
using MobilivaCase.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilivaCase.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MobilivaCase.API", Version = "v1" });
            });
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseMySQL(Configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IOrderDetailRepository, EFOrderDetailsRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<IGetProductService, GetProductService>();
            services.AddScoped<ICreateOrderService, CreateOrderService>();
            services.AddMemoryCache();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IRabbitMQConfiguration, RabbitMQConfiguration>();
            services.AddScoped<IObjectConvertFormat, ObjectConvertFormatManager>();
            services.AddScoped<IMailSender, MailSender>();
            //services.AddScoped<IDataModel<Order>, UsersDataModel>();
            services.AddScoped<ISmtpConfiguration, SmtpConfiguration>();
            services.AddScoped<IPublisherService, PublisherManager>();
            services.AddScoped<IConsumerService, ConsumerManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MobilivaCase.API v1"));
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
