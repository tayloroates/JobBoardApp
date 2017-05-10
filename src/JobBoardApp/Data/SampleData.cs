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
                    new Jobs { EmployerName = "Amazon", EmploymentType = "Full-Time", JobDescription = "Third-Party Vendor for Amazon Products", JobTitle = "Sales Ambassador", Location = "Houston, TX", Salary = 10m },
                    new Jobs { EmployerName = "Mainstream Boutique", EmploymentType = "Part-Time", JobDescription = "Lives out Mainstream Boutique’s Values & Mission,Customer Experience Focused, Celebrates the successes of our team, customers, and community, Passion for fashion, Community Builder, Brand Ambassador", JobTitle = "Part-time Fashion Stylist", Location = "Pearland, TX", Salary = 15m },
                    new Jobs { EmployerName= "Amazon Corporate LLC", EmploymentType="Full-Time", JobDescription= "Do you want to influence the experience of millions of customers? Do you want to work in a collaborative environment that impacts products from across the company? Our team owns services that enable customers to track and control their deliveries on Amazon retail sites. As a member of this team, you will design and develop software to collaborate with Amazon’s numerous backend systems and directly impact customers. Your solutions will provide the data needed to anticipate and resolve customer's questions before they are asked. You will have the opportunity to collaborate with business partners and guide the design of our systems. At Amazon, we are known for our customer obsession. We need your ideas and your ability to take initiative and produce results as we continuously improve the customer experience.", JobTitle= "Software Development", Location= "US-WA-Seattle", Salary= 13m }
                );

                context.SaveChanges();
            }
        }
    }
}
