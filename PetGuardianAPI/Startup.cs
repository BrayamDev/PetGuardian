using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using PetGuardianAPI.AzureService;

namespace PetGuardianAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) 
        {

            //CORS
            services.AddCors();

            services.AddControllers().AddNewtonsoftJson();
            services.AddEndpointsApiExplorer();
            //Automapper
            services.AddAutoMapper(typeof(Startup));
            //Servicio de la base de datos
            services.AddDbContext<ApplicationDbContext>(options=>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Servicio de guardar el archivo *Configuracion de servicios*
            services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivoLocal>();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            //CORS 
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200");
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
