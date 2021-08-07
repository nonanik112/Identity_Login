using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserLogin.Areas.Identity.Data;
using UserLogin.Data;

[assembly: HostingStartup(typeof(UserLogin.Areas.Identity.IdentityHostingStartup))]
namespace UserLogin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserLoginDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserLoginDbContextConnection")));

                services.AddDefaultIdentity<LoginUser>(options => 
                {
                    
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<UserLoginDbContext>();
            });
        }
    }
}