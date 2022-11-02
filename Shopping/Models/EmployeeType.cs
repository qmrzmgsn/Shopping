using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class EmployeeType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
}
