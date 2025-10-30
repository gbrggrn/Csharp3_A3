using Csharp3_A3.Data;
using Csharp3_A3.DataAccess;
using Csharp3_A3.Services;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
			{
				options.LoginPath = "/Account/Login";
				options.AccessDeniedPath = "/Account/AccessDenied";
			});

			builder.Services.AddAuthentication();

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
			
			//Register Repositories
			builder.Services.AddScoped<StaffRepository>();
			builder.Services.AddScoped<PatientRepository>();
			builder.Services.AddScoped<AccountRepository>();
			builder.Services.AddScoped<AppointmentsRepository>();
			builder.Services.AddScoped<ContentRepository>();
			builder.Services.AddScoped<NewsRepository>();
			builder.Services.AddScoped<UserRepository>();

			//Register Services
			builder.Services.AddScoped<HospitalService>();
			builder.Services.AddScoped<PatientService>();
			builder.Services.AddScoped<StaffService>();
			builder.Services.AddScoped<NewsService>();
			builder.Services.AddScoped<AccountService>();
			builder.Services.AddScoped<AppointmentService>();
			builder.Services.AddScoped<UserService>();
			builder.Services.AddScoped<ContentService>();

			var app = builder.Build();

			using (var scope = app.Services.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				context.Database.Migrate();
				await DemoData.InitializeAsync(scope.ServiceProvider);
			}

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}