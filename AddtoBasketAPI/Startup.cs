using AddtoBasketAPI.Extensions;
using AddtoBasketAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace AddtoBasketAPI
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
            services.AddDbContext<BasketContext>(opt => opt.UseInMemoryDatabase("BasketDb"));

            services.AddScoped<StockService>();
            services.AddScoped<ProductService>();
            services.AddScoped<Service.BasketService>();

            services.AddControllers()
                .AddNewtonsoftJson();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Basket Service",
                        Description = "Basket Service",
                        Version = "",
                        Contact = new OpenApiContact
                        {
                            Name = "Çağdaş Karaca",
                            Email = "",
                        }
                    }
                );

                c.IncludeXmlComments(PlatformServices.Default.Application.ApplicationBasePath + "AddtoBasketAPI.xml");

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); app.UseRouting();

            app.UseHttpsRedirection();

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket Service Api");
                    c.RoutePrefix = "";
                });

            app.UseEndpoints(x => x.MapControllers());

        }
    }
}
