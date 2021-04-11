using dotNETBD.Adapter;
using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Pessoa.Repositorio;
using dotNETBD.Bordas.Pessoa.UseCase;
using dotNETBD.Bordas.Repositorio;
using dotNETBD.Context;
using dotNETBD.Repositorios;
using dotNETBD.Services;
using dotNETBD.UseCase.Pessoa;
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

namespace dotNETBD
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
            //Conexao com o banco de dados
            services.AddEntityFrameworkNpgsql().AddDbContext<LocalDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("postgresDotNet")));
            //Injetando o IPessoaServices e o PessoaServices no container
            services.AddScoped<IPessoaServices , PessoaServices>();

            //Injetando os UseCase
            services.AddScoped<IAdicionarPessoaUseCase , AdicionarPessoaUseCase>();
            services.AddScoped<IAtualizarPessoaUseCase , AtualizarPessoaUseCase>();
            services.AddScoped<IDeletarPessoaUseCase , DeletarPessoaUseCase>();
            services.AddScoped<IRetornarPessoaPorIDUseCase , RetornarPessoaPorIDUseCase>();
            services.AddScoped<IRetornarTodasPessoasUseCase , RetornarTodasPessoasUseCase>();


            services.AddScoped<IRepositorioPessoaAdd , RepositorioPessoaAdd>();
            services.AddScoped<IRepositorioAtualizarPessoa , RepositorioAtualizarPessoa>();
            services.AddScoped<IRepositorioDeletarPessoa , RepositorioDeletarPessoa>();
            services.AddScoped<IRepositorioRetornarPessoaPorID, RepositorioRetornarPessoaPorID>();


            services.AddScoped<IAdicionarPessoaAdapter , AdicionarPessoaAdapter>();
            services.AddScoped<IAtualizarPessoaAdapter , AtualizarPessoaAdapter>();
            services.AddScoped<IDeletarPessoaAdapter , DeletarPessoaAdapter>();
            services.AddScoped<IRetornarPessoaPorIDAdapter, RetornarPessoaPorIDAdapter>();


            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotNETBD", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotNETBD v1"));
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
