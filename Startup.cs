using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Units;
using BirthdayAPI.Infrastructure.Persistence.Context;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Service.Services.Abstractions;
using BirthdayAPI.Core.Service.Units;
using BirthdayAPI.Core.Service.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BirthdayAPI.Core.Service.Services;
using BirthdayAPI.Core.Service.Repositories;
using BirthdayAPI.Infrastructure.Middlewares;
using BirthdayAPI.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using FluentValidation;
using BirthdayAPI.Core.Service.Query.Sorting;

namespace BirthdayAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Disabling local language for fluent validation (english is used instead)
            ValidatorOptions.Global.LanguageManager.Enabled = false;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Fluent Validation
            services.AddMvc(setup =>
            {
                setup.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(mvcConfiguration =>
            {
                mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            // Swagger
            services.AddSwaggerGen();

            // Database
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Local")));

            // AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            // Registering for dependency injection

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped(typeof(ISortHelper<>), typeof(SortHelper<>));

            // Exception handling middleware

            services.AddTransient<ExceptionHandlingMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Birthday API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<ExceptionHandlingMiddleware>();

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
