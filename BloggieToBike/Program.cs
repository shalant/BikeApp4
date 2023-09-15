using BloggieToBike.Web.Data;
using BloggieToBike.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING", builder.Configuration.GetSection("ConnectionStrings").GetSection("BloggieToBikeDbConnectionString").Value);
Environment.SetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING", builder.Configuration.GetSection("ConnectionStrings").GetSection("BloggieToBikeAuthDbConnectionString").Value);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/NewBikeRoutes/Edit" );
    options.Conventions.AuthorizeAreaFolder("Identity", "/NewBikeRoutes");
    options.Conventions.AllowAnonymousToPage("/NewBikeRoutes/Index");
});
builder.Services.AddControllers();

builder.Services.AddDbContext<BloggieToBikeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BloggieToBikeDbConnectionString")));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BloggieToBikeAuthDbConnectionString")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default PW settings
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/AccessDenied";
});

//builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IBikeRouteRepository, BikeRouteRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepositoryCloudinary>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
//builder.Services.AddScoped<IBlogPostLikeRepository, BlogPostLikeRepository>();
builder.Services.AddScoped<IBikeRouteLikeRepository, BikeRouteLikeRepository>();
//builder.Services.AddScoped<IBlogPostCommentRepository, BlogPostCommentRepository>();
builder.Services.AddScoped<IBikeRouteCommentRepository, BikeRouteCommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
