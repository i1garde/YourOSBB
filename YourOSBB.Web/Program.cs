using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Infrastructure;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services;
using YourOSBB.Services.Interfaces;
using YourOSBB.Web.Models.Entities;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

        builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(connectionString, 
                b => b.MigrationsAssembly("YourOSBB.Web")));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IOsbbService, OsbbService>();
        builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
        builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
        builder.Services.AddScoped<IProposalService, ProposalService>();
        builder.Services.AddScoped<IComplaintService, ComplaintService>();
        builder.Services.AddScoped<ITariffService, TariffService>();
        builder.Services.AddScoped<IVotingService, VotingService>();
        builder.Services.AddScoped<RoleManager<ApplicationRole>>();

        builder.Services
            .AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<ApplicationRole>()
            .AddDefaultUI()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddControllersWithViews();
        builder.Services.AddHealthChecks();

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        //
        List<dynamic> hList = new List<dynamic>() { 1, "as"};
        foreach (var v in hList)
        {
            System.Console.WriteLine(v);
        }
        //

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        using (var scope = app.Services.CreateScope())
        {
            var roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var roles = new[] { "Admin", "OsbbHead", "Resident" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new ApplicationRole(role));
            }
        }

        app.Run();
    }
}