using System.Reflection;
using System.Text;
using Core6.Models.Contexts;
using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Core6.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ResurantApiCore6.Models.Auth;
using ResurantApiCore6.Models.Contexts;
using ResurantApiCore6.Models.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(Program)); 
        builder.Services.AddControllersWithViews();
        
        
        // Database Contexts
        builder.Services.AddScoped<DBContext>();


        builder.Services.AddScoped<ResponseResult>();
        builder.Services.AddScoped<IResturant, ResturantService>();
        builder.Services.AddScoped<IFood, FoodService>();
        builder.Services.AddScoped<IStackOverflow, StackOverflowService>();
        builder.Services.AddTransient<IdentityErrorDescriber, CustomIdentityErrorDescriber>();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Restaurant API",
                Version = "v1",
                Description = "An API to Show Restaurant an Foods",
                TermsOfService = new Uri("http://behesht724.ir/"),
                Contact = new OpenApiContact
                {
                    Name = "Navid Lotfian",
                    Email = "lotfian70@gmail.com",
                    Url = new Uri("https://navidlotfian.ir"),
                },
                License = new OpenApiLicense
                {
                    Name = "Mehrasaam CO",
                    Url = new Uri("http://behesht724.ir/"),
                }
            });

            options.CustomSchemaIds(t => t.FullName);
            options.ResolveConflictingActions(c => c.First());


            //Include 'SecurityScheme' to use JWT Authentication
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "bearer",
                BearerFormat = "JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });

            // using System.Reflection;
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        builder.Services.AddDbContext<AuthDBContext>();
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AuthDBContext>()
        .AddDefaultTokenProviders();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.InjectStylesheet("/css/site.css");  //Added Code
                    options.RoutePrefix = string.Empty;
                });
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