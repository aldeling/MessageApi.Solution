using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
  public class StartUp
  {
      public StartUp(IConfiguration configuration)
      {
        IConfiguration Configuration = configuration;
      }

      public void ConfigureServices(IServiceCollection services)
      {
          services.AddCors();
          services.AddControllers();
          services.AddAuthentication(options =>
          {
              options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
          })
          .AddJwtBearer(options =>
          {
              options.SaveToken = true;
              options.RequireHttpsMetadata = false;
              options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidAudience = "http://localhost:5174",
                  ValidIssuer = "http://localhost:5174",
                  ClockSkew = TimeSpan.Zero,// It forces tokens to expire exactly at token expiration time instead of 5 minutes later
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyNameIsJamesBond007"))
              };
          });
      }

        // public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        // {
        //     if (env.IsDevelopment())
        //     {
        //         app.UseDeveloperExceptionPage();
        //     }
        //     else
        //     {
        //         app.UseExceptionHandler("/Home/Error");
        //         // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //         app.UseHsts();
        //     }
        //     app.UseHttpsRedirection();
        //     app.UseStaticFiles();

        //     app.UseRouting();

        //     app.UseAuthentication();
        //     app.UseAuthorization();

        //     app.UseEndpoints(endpoints =>
        //     {
        //         endpoints.MapControllerRoute(
        //             name: "default",
        //             pattern: "{controller=Home}/{action=Index}/{id?}");
        //     });
        // } 
  }
} 
