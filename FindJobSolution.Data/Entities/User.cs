using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public JobSeeker JobSeeker { get; set; }
        public Recruiter Recruiter { get; set; }
        //public List<Message> messages { get; set; }
    }
}