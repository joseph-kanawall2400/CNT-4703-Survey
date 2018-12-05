using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Website
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(action =>
            {
                action.AddDefaultPolicy(new CorsPolicyBuilder()
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://www.jkanawall.net", "http://localhost").Build());
            });
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
            // app.UseCors(builder => builder.WithOrigins("http://www.jkanawall.net", "http://localhost"));
        }
    }
}
