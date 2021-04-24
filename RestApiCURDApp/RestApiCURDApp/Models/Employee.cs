using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCURDApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Name Can Be Only Be 30 Character")]
        public string Name { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
    }
}
