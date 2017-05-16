using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApp.Models
{
    public class JobUser
    {
        public Jobs Jobs { get; set; }
        public int JobId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
