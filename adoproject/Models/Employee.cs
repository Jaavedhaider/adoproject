using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adoproject.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public int deptid { get; set; }
        public string Department { get; set; }
    }
}
