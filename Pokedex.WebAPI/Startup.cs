using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Pokedex.BLL.Contracts;
using Pokedex.BLL.Implementations;
using Pokedex.DataAccess.Context;
using Pokedex.DataAccess.Contracts;
using Pokedex.DataAccess.Implementations;

namespace Pokedex.WebAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            
            // BLL
            services.Add(new ServiceDescriptor(typeof(IPokemonGetService), typeof(PokemonGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPokemonCreateService), typeof(PokemonCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPokemonUpdateService), typeof(PokemonUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPokemonRemoveService), typeof(PokemonRemoveService), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(ISpeciesGetService), typeof(SpeciesGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISpeciesCreateService), typeof(SpeciesCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISpeciesUpdateService), typeof(SpeciesUpdateService), ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IMoveGetService), typeof(MoveGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMoveCreateService), typeof(MoveCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMoveUpdateService), typeof(MoveUpdateService), ServiceLifetime.Scoped));

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(IPokemonDataAccess), typeof(PokemonDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IMoveDataAccess), typeof(MoveDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ISpeciesDataAccess), typeof(SpeciesDataAccess), ServiceLifetime.Transient));

            // Db Context
            services.AddDbContext<PokedexContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Pokedex")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PokedexContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            context.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}