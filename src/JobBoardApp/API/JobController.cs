using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobBoardApp.Data;
using JobBoardApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JobBoardApp.API
{
    [Route("api/[controller]")]
    public class JobController : Controller
    {
        private ApplicationDbContext _db;

        public JobController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Jobs> Get()
        {
            return _db.Jobs.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var job = _db.Jobs.Where(c => c.Id == id).FirstOrDefault();
            if (job == null)
                return NotFound();

            return Ok(job);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Jobs jobs)
        {
            if (jobs != null)
            {
                if (jobs.Id == 0)
                {
                    _db.Jobs.Add(jobs);
                    _db.SaveChanges();
                    return Created("/jobs/" + jobs.EmployerName, jobs);

                }
                else
                {

                    var original = _db.Jobs.FirstOrDefault(m => m.Id == jobs.Id);
                    original.EmployerName = jobs.EmployerName;
                    original.EmploymentType = jobs.EmploymentType;
                    original.JobDescription = jobs.JobDescription;
                    original.JobTitle = jobs.JobTitle;
                    original.Location = jobs.Location;
                    original.Salary = jobs.Salary;
                    _db.SaveChanges();
                    return Ok(jobs);
                }

            }


            return NotFound();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var jobs = _db.Jobs.FirstOrDefault(m => m.Id == id);
            if (jobs == null)
            {
                return NotFound();
            }
            _db.Jobs.Remove(jobs);
            _db.SaveChanges();
            return Ok();
        }
    }
}
