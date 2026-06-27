using CUTDataScienceClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CUTDataScienceClub.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configure Identity to use the ApplicationDbContext
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    // You can adjust password/sign-in options here as needed
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders();
builder.Services.AddScoped<IFileService, FileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Home}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();


app.Run();

// Seed roles and default users (Admin, Journalist) on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // Ensure roles exist
        var roleNames = Enum.GetNames(typeof(CUTDataScienceClub.Constants.Roles));
        foreach (var rn in roleNames)
        {
            var exists = roleManager.RoleExistsAsync(rn).GetAwaiter().GetResult();
            if (!exists)
            {
                roleManager.CreateAsync(new IdentityRole(rn)).GetAwaiter().GetResult();
            }
        }

        // Default credentials (change these in production)
        var adminEmail = "admin@cutdsc.local";
        var adminPassword = "Admin@1234"; // DEFAULT - change immediately
        var journalistEmail = "journalist@cutdsc.local";
        var journalistPassword = "Journalist@1234"; // DEFAULT - change immediately

        // Create admin user
        var adminUser = userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult();
        if (adminUser == null)
        {
            adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail, Name = "Administrator", EmailConfirmed = true };
            var createAdmin = userManager.CreateAsync(adminUser, adminPassword).GetAwaiter().GetResult();
            if (createAdmin.Succeeded)
            {
                userManager.AddToRoleAsync(adminUser, CUTDataScienceClub.Constants.Roles.Admin.ToString()).GetAwaiter().GetResult();
            }
        }

        // Create journalist user (maps to PublicityManager role)
        var jUser = userManager.FindByEmailAsync(journalistEmail).GetAwaiter().GetResult();
        if (jUser == null)
        {
            jUser = new ApplicationUser { UserName = journalistEmail, Email = journalistEmail, Name = "Journalist", EmailConfirmed = true };
            var createJ = userManager.CreateAsync(jUser, journalistPassword).GetAwaiter().GetResult();
            if (createJ.Succeeded)
            {
                userManager.AddToRoleAsync(jUser, CUTDataScienceClub.Constants.Roles.PublicityManager.ToString()).GetAwaiter().GetResult();
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB with roles/users.");
    }
}
