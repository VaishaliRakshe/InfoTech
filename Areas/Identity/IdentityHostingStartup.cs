﻿using System;
using InfoTech.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



[assembly: HostingStartup(typeof(InfoTech.Areas.Identity.IdentityHostingStartup))]
namespace InfoTech.Areas.Identity
{
    
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StudentDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("StudentDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                })
                    .AddEntityFrameworkStores<StudentDbContext>();
            });
        }
    }
}
    
