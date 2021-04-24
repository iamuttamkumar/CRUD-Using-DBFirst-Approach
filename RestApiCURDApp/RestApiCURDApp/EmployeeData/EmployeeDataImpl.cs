using RestApiCURDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCURDApp.EmployeeData
{
    public class EmployeeDataImpl : IEmployeeData
    {
        public List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id=101,Name="Uttam Kumar",Location="Hyderabad",Salary=40000},
            new Employee(){Id=102,Name="Gautam Kumar",Location="Bengalore",Salary=20000},
            new Employee(){Id=103,Name="Sonu",Location="Hyderabad",Salary=30000},
            new Employee(){Id=104,Name="Sujit",Location="Patna",Salary=50000},
            new Employee(){Id=105,Name="Binod",Location="Pune",Salary=30000}
        };
        public Employee AddEmployee(Employee employee)
        {           
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);

        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public List<Employee> GetAllEmployee()
        {
            return employees;
        }

        public Employee GetEmployee(int Id)
        {
            return employees.SingleOrDefault(e => e.Id ==Id);
        }       
    }
}
