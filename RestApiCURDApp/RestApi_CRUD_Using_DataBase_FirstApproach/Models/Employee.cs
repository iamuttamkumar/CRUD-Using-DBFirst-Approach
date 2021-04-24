using System;
using System.Collections.Generic;

#nullable disable

namespace RestApi_CRUD_Using_DataBase_FirstApproach.Models
{
    public partial class Employee
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal? Age { get; set; }
        public int? Salary { get; set; }
        public string City { get; set; }
    }
}
