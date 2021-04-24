using RestApiCURDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCURDApp.EmployeeData
{
   public interface IEmployeeData
    {
        public List<Employee> GetAllEmployee();

        public Employee GetEmployee(int Id);
        Employee AddEmployee(Employee employee);
        public void DeleteEmployee(Employee employee);

        public Employee EditEmployee(Employee employee);
      
    }
}
