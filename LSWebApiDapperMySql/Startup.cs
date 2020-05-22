using LSWebApiDapperMySql.Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using System;

namespace LSWebApiDapperMySql
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Api Produtos",
                    Version = "v1",
                    Description = "Exempli de API REST Usando Dapper e MySql",
                    Contact = new OpenApiContact
                    {
                        Name = "Leandro Salomão",
                        Url = new Uri("https://github.com/lsalomao")
                    }
                });

            });

            services.AddSingleton(new MySqlConnection(AppSettingsConfiguration.DataBase.ConnectionStringMySql));
            services.AddSingleton<IProdutoRepository, ProdutoRepository>();
            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API .Net Core, Dapper e MySql");               

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
