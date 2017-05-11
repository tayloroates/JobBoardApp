﻿using System;
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
    public class ManyController : Controller
    {
        private ApplicationDbContext _db;

        public ManyController(ApplicationDbContext db)
        {
            this._db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(int id,[FromBody]User user)
        {
            _db.JobUser.Add(new JobUser
            {
                JobId = id,
                UserId = user.LastName
            });
            _db.SaveChanges();

            // success
            return Ok();
        }


    // PUT api/values/5
    [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}