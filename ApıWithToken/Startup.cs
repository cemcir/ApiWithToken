using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.Domain;
using ApıWithToken.Domain.Repository;
using ApıWithToken.Domain.Services;
using ApıWithToken.Domain.UnitOfWork;
using ApıWithToken.Security.Token;
using ApıWithToken.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApıWithToken
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
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>),typeof(GenericService<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepositories<>),typeof(GenericRepositories<>));
            services.AddScoped(typeof(IGenericsService<>), typeof(GenericsService<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors(opts => {

                opts.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });
                /*
                opts.AddPolicy("abcPolicy", builder =>
                {
                    builder.WithOrigins("http://www.abc.com").AllowAnyHeader().AllowAnyMethod();
                });
                */
            });

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtbeareroptions=>
            {
                jwtbeareroptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew=TimeSpan.Zero
                };

            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApiWithTokenDBContext>(options=>{
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors();
            app.UseMvc();
        }
    }
}
