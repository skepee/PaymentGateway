using CKMerchant.Context;
using CKMerchant.Http;
using CKMerchant.Service;
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
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CKMerchant
{
    public class Startup
    {
        readonly string MyGatewayPolicy = "MyGatewayPolicy";

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Merchant Payment System", Version = "v1" });
            });

            services.AddHttpClient<HttpPaymentGateway>("Payment", x =>
            {
                x.BaseAddress = new Uri("https://localhost:62849/");
                x.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyGatewayPolicy,
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:4200/")
            //            .WithHeaders("Access-Control-Allow-Origin")
            //            .AllowAnyOrigin()
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //        });
            //});

            services.AddDbContext<CKMerchantContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IMerchantRepository, MerchantRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MerchantPayment v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/swagger/index.html", async context =>
                //{
                //    context.Response.Redirect("/index.html");
                //    await Task.FromResult(1).ConfigureAwait(false);
                //});
            });
        }
    }
}
