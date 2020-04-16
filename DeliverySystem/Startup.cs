using AutoMapper;
using DeliverySystem.Data.EF;
using DeliverySystem.Data.Interfaces;
using DeliverySystem.Data.Repositories;
using DeliverySystem.Helpers;
using DeliverySystem.Logic.Interfaces;
using DeliverySystem.Logic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;

namespace DeliverySystem
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "*";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Food Delivery System V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();

            services.AddDbContext<DeliveryContext>(opt =>
                          opt.UseSqlServer("Server=tcp:ilbontestserver.database.windows.net,1433;Initial Catalog=ilbonTestDb;Persist Security Info=False;User ID=ilbon;Password=1D41BBDA-031F;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;"));
            //opt.UseSqlServer(Configuration.GetConnectionString("SB-Aval-Dev:SqlConnectionString")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Delivery System",
                    Description = "Food delivery system with role-separated functionality",
                    TermsOfService = "https://example.com/",
                    Version = "V1.0.0.5",
                    Contact = new Contact()
                    {
                        Name = "Illia Bondar",
                        Email = "i.bondar@ukma.edu.ua",
                        Url = "https://www.linkedin.com/in/%D0%B8%D0%BB%D1%8C%D1%8F-%D0%B1%D0%BE%D0%BD%D0%B4%D0%B0%D1%80%D1%8C-9825b1152/",
                    },
                    License = new License()
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license",
                    }

                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddTransient<IDeliveryService, DeliveryService>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MainProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}