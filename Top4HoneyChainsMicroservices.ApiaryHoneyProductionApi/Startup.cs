using Microsoft.OpenApi.Models;

namespace Top4HoneyChainsMicroservices.ApiaryHoneyProductionApi
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Authentication API",
					Version = "v1",
					Description = "Authentication Web API",
					TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Hasan Kıvrakdal",
						Email = "hsnkivrakdal@gmail.com"
					},
					License = new OpenApiLicense
					{
						Name = "Employee API LICX",
						Url = new Uri("https://example.com/license"),
					}
				});
			});
			services.AddControllers();
		}



		public void Configure(IApplicationBuilder app)
		{

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API");
			});

			app.UseRouting();

			app.UseDeveloperExceptionPage();

			app.UseStaticFiles();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
