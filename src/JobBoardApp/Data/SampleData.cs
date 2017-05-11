using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using JobBoardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApp.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }


            if (!context.Jobs.Any())
            {
                context.Jobs.AddRange(
                    new Jobs { EmployerName = "Amazon", EmploymentType = "Full-Time", JobDescription = "Third-Party Vendor for Amazon Products", JobTitle = "Sales Ambassador", Location = "Houston, TX", Industry = "Sales/Retail", Salary = 10m },
                    new Jobs { EmployerName = "Mainstream Boutique", EmploymentType = "Part-Time", JobDescription = "Lives out Mainstream Boutique’s Values & Mission", JobTitle = "Part-time Fashion Stylist", Location = "Pearland, TX", Industry = "Beautician", Salary = 15m },
                    new Jobs { EmployerName = "Amazon Corporate LLC", EmploymentType = "Full-Time", JobDescription = "Do you want to influence the experience of millions of customers? Do you want to work in a collaborative environment that impacts products from across the company?.", JobTitle = "Software Development", Location = "US-WA-Seattle", Industry = "Sales/Retail", Salary = 13m }
                );

                context.SaveChanges();

                // context.User.AddRange(
                //    new User { FirstName = "Anthony", LastName = "Goodman" },
                //    new User { FirstName = "Taylor", LastName = "Oates" },
                //    new User { FirstName= "Jarvis", LastName = "Lankin"}
                //);
                // context.SaveChanges();

                // add many-to-many
                context.JobUser.AddRange(
                    new JobUser
                    {
                        JobId = context.Jobs.FirstOrDefault(m => m.EmployerName == "Amazon").Id,
                        User = mike
                    },
                    new JobUser
                    {
                        JobId = context.Jobs.FirstOrDefault(m => m.EmployerName == "Amazon Corporate LLC").Id,
                        User = mike
                    },
                    new JobUser
                    {
                        JobId = context.Jobs.FirstOrDefault(m => m.EmployerName == "Mainstream Boutique").Id,
                        User = stephen
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
