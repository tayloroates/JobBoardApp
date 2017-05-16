using JobBoardApp.Data;
using JobBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApp.Services
{
    public class JobService
    {
        private ApplicationDbContext _db;

        public void JobController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Jobs> ListJobs()
        {
            return _db.Jobs.ToList();
        }

        public Jobs FindJob(int id)
        {
            return _db.Jobs.First(j => j.Id == id);
        }
    }
}
