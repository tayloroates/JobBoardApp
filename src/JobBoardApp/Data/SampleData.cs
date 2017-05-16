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
                    new Jobs { EmployerName = "Amazon Corporate LLC", EmploymentType = "Full-Time", JobDescription = "Do you want to influence the experience of millions of customers? Do you want to work in a collaborative environment that impacts products from across the company?.", JobTitle = "Software Development", Location = "US-WA-Seattle", Industry = "Sales/Retail", Salary = 13m },
                    new Jobs { EmployerName="Wells Fargo", EmploymentType="Full-Time", JobDescription= "This 40 hour Teller position is located at the Gessner & Braeswood location. At Wells Fargo,our vision is to satisfy our customers’ financial needs and help them succeed financially.In this role, you will help us deliver on our vision and build lifelong relationships with our customers.You also will demonstrate leadership through contributing to a company culture that supports customers in achieving their financial goals,team members in developing their careers,and communities in continuing to thrive.As part of a team that serves one in three American households, you will play a vital role in living our commitment to the highest ethical standards and maintaining the valued trust of our customers and communities. A teller provides exceptional customer service and spends almost all of his / her time working with Wells Fargo’s most important asset, our customers.Tellers are responsible for a variety of tasks including providing excellent customer service, processing account transactions effectively, helping resolve customer concerns in a timely fashion, following proper procedures to minimize errors and reduce fraud, and sharing the benefit our customers may receive when meeting with a banker, when appropriate.Tellers are expected to always balance their cash drawers, build great rapport with people, and be strong team players who take pride in performing well and enjoy helping others. Important Note: During the application process, ensure your contact information(email and phone number) is up to date and upload your current resume prior to submitting your application for consideration.If you are a Wells Fargo Team Member, in your Jobs Profile ensure that your email address is valid and updated to an address that can receive external emails outside of the banking network and is a different email address than the one you originally used when you joined WF.Initial contact with you will be made via e - mail.Please check your e - mail regularly for updates. Normal work schedules typically fall between 7AM - 6PM and may change based on business need.", Industry="Accounting", JobTitle="Teller", Location="Houston, TX" },
                     new Jobs { EmployerName = "JP Morgan Chase", EmploymentType = "Full-Time", JobDescription = "Opportunity to design and develop applications within JPMorgan’s Global Banking technology team to deliver a world-class deal and document management platform, for the world’s #1 investment banking franchise. Become a part of the leadership team for the Houston Banking Java community, growing the footprint & impact over time", Industry = "Accounting", JobTitle = "Software", Location = "Houston, TX" },
                      new Jobs { EmployerName = "HR Assistant", EmploymentType = "", JobDescription = "Do you have at least 5-7 years of Administrative and/or HR experience? Have you currently helped out with the recruiting/onboarding process? If so, and you are currently searching for your next long-term career opportunity in the NW Houston area then this is the job for you!", Industry = "Human Resources", JobTitle = "Administrative/HR", Location = "Houston, TX" }
                );

                context.SaveChanges();

                context.User.AddRange(
                   new User { FirstName = "Anthony", LastName = "Goodman" },
                   new User { FirstName = "Taylor", LastName = "Oates" },
                   new User { FirstName = "Jarvis", LastName = "Lankin" }
               );
                context.SaveChanges();

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
