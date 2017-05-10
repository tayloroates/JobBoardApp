using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace JobBoardApp.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public string EmployerName { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string EmploymentType { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
    }
}
