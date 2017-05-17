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
                    new Jobs { EmployerName = "Amazon", EmploymentType = "Full-Time", JobDescription = "Third-Party Vendor for Amazon Products", JobTitle = "Sales Ambassador", Location = "Houston, TX", Industry = "Sales/Retail", Salary = 10.00m },
                    new Jobs { EmployerName = "Mainstream Boutique", EmploymentType = "Part-Time", JobDescription = "Lives out Mainstream Boutique’s Values & Mission", JobTitle = "Part-time Fashion Stylist", Location = "Pearland, TX", Industry = "Beautician", Salary = 15.00m },
                    new Jobs { EmployerName = "Amazon Corporate LLC", EmploymentType = "Full-Time", JobDescription = "Do you want to influence the experience of millions of customers? Do you want to work in a collaborative environment that impacts products from across the company?.", JobTitle = "Software Development", Location = "US-WA-Seattle", Industry = "Sales/Retail", Salary = 13.00m },
                    new Jobs { EmployerName="Wells Fargo", EmploymentType="Full-Time", JobDescription= "This 40 hour Teller position is located at the Gessner & Braeswood location. At Wells Fargo,our vision is to satisfy our customers’ financial needs and help them succeed financially.In this role, you will help us deliver on our vision and build lifelong relationships with our customers.You also will demonstrate leadership through contributing to a company culture that supports customers in achieving their financial goals,team members in developing their careers,and communities in continuing to thrive.As part of a team that serves one in three American households, you will play a vital role in living our commitment to the highest ethical standards and maintaining the valued trust of our customers and communities. A teller provides exceptional customer service and spends almost all of his / her time working with Wells Fargo’s most important asset, our customers.Tellers are responsible for a variety of tasks including providing excellent customer service, processing account transactions effectively, helping resolve customer concerns in a timely fashion, following proper procedures to minimize errors and reduce fraud, and sharing the benefit our customers may receive when meeting with a banker, when appropriate.Tellers are expected to always balance their cash drawers, build great rapport with people, and be strong team players who take pride in performing well and enjoy helping others. Important Note: During the application process, ensure your contact information(email and phone number) is up to date and upload your current resume prior to submitting your application for consideration.If you are a Wells Fargo Team Member, in your Jobs Profile ensure that your email address is valid and updated to an address that can receive external emails outside of the banking network and is a different email address than the one you originally used when you joined WF.Initial contact with you will be made via e - mail.Please check your e - mail regularly for updates. Normal work schedules typically fall between 7AM - 6PM and may change based on business need.", Industry="Accounting", JobTitle="Teller", Location="Houston, TX", Salary= 15.00m },
                     new Jobs { EmployerName = "JP Morgan Chase", EmploymentType = "Full-Time", JobDescription = "Opportunity to design and develop applications within JPMorgan’s Global Banking technology team to deliver a world-class deal and document management platform, for the world’s #1 investment banking franchise. Become a part of the leadership team for the Houston Banking Java community, growing the footprint & impact over time", Industry = "Accounting", JobTitle = "Software", Location = "Houston, TX", Salary= 17.00m },
                      new Jobs { EmployerName = "HR Assistant", EmploymentType = "Part-Time", JobDescription = "Do you have at least 5-7 years of Administrative and/or HR experience? Have you currently helped out with the recruiting/onboarding process? If so, and you are currently searching for your next long-term career opportunity in the NW Houston area then this is the job for you!", Industry = "Human Resources", JobTitle = "Administrative/HR", Location = "Houston, TX", Salary= 25.00m},
                      new Jobs { EmployerName="Marketing Depot Inc", EmploymentType="Full-Time", JobDescription= "Work as a member of development team to build and maintain web sites and web applications. Work in a fast - paced environment working independently and as a team member. Must be able to take a PSD / JPEGs and build out: \r HTML, \r CSS, \r JavaScript, \r graphics, \r and program in PHP. Work closely with Sales and Marketing, take direction and provide positive input.", Industry="Software Developement", JobTitle="Back End Programmer", Location="Houston, TX", Salary= 60.00m },
                      new Jobs { EmployerName = "WinWire Technologies", EmploymentType = "Part-Time", JobDescription = "Work will include all aspects of software development lifecycle with a focus on Java development using J2EE standards. Candidate must have a solid understanding of middleware messaging technology with proven experience working in a multi-tiered environment. Candidate should be well versed in testing techniques and be able to produce comprehensive tests for all developed code. Candidate must also support and participate in system and integrated testing across sub-systems as the need arises. Candidate should be capable of producing solid documentation both inside code and external design specifications.", Industry = "Software Developer", JobTitle = "Java Developer", Location = "Dallas, TX", Salary = 50.00m },
                      new Jobs { EmployerName = "Dominie Luxury", EmploymentType = "Internship", JobDescription = "Luxury Brand seeking highly motivated, energetic individuals with a flair for fashion who love to interact with people and make money. All shifts and positions available from kiosk sales to product stock and staff management. Pay varies depending on position. No experience necessary, however, computer knowledge is a plus. On site training on product and inventory/POS system. Reply by email. hourly pay/ plus commission on sales", Industry = "Retail/Sales", JobTitle = "Luxury Sales Associate", Location = "Houston, TX", Salary = 12.00m },
                      new Jobs { EmployerName = "Assessments VUE", EmploymentType = "Part-Time", JobDescription = "Pearson VUE (www.pearsonvue.com) is the global leader in computer-based testing for information technology, academic, government and professional testing programs around the world. Pearson VUE provides a full suite of services from test development to data management, and delivers exams through the world’s most comprehensive and secure network of test centers in more than 180 countries, where we validate the skills and knowledge of millions of individuals every year. Pearson VUE offers a great environment to start or grow your career, we are now hiring for a Test Administrator to join our team based in Statesville NC.  Pearson VUE is a business of Pearson, the world's leading learning company with global-reach and market-leading businesses. Pearson is listed on both the London and New York stock exchanges (UK: PSON; NYSE: PSO). Pearson is an Equal Opportunity and Affirmative Action Employer and a member of E - verify.All qualified applicants, including minorities,mwomen, protected veterans, and individuals with disabilities are encouraged to apply.", Industry = "Business", JobTitle = "Test Center Administrator", Location = "Statesville, NC", Salary = 10.50m  }
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
