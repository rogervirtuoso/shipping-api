using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Roger.ParseTheParcel.Infra.CrossCutting.IoC;
using Roger.Framework.DomainDrivenDesign.Web.Filters;
using Roger.Framework.Web.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
namespace Roger.ParseTheParcel.Api
{
    /// <summary>
    ///
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///
        /// </summary>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opts =>
            {
                opts.Filters.Add<ApiActionExceptionFilter>();
                opts.Filters.Add<ApiFaultResultCodeFilter>();
                opts.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                opts.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            });
           
            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "/ParseTheParcels/Api", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;

                //if (Directory.Exists(Path.Combine(lBasePath, "App_data")))
                var lXmlPath = Path.Combine(basePath, "App_Data", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".xml");
                c.IncludeXmlComments(lXmlPath);
            });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            RegisterServices(services);
            //AutoMapperConfig.RegisterMappings();
        }

        /// <summary>
        ///
        /// </summary>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor httpAccessor)
        {
            app.UsePathBase("/ParseTheParcels/Api");
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/ParseTheParcels/Api/swagger/v1/swagger.json", "/ParseTheParcels/Api"); });

            app.UseMvc();

        }

        private static void RegisterServices(IServiceCollection serviceCollection)
        {
            DependencyInjector.RegisterServices(serviceCollection);
        }
    }
}