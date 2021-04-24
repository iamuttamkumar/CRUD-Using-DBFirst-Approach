using RestApiCURDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCURDApp.EmployeeData
{
    public class SqlEmployeeDataImpl : IEmployeeData
    {
        private EmployeeDBContext _employeeDBContext;
        public SqlEmployeeDataImpl(EmployeeDBContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            _employeeDBContext.Employees.Add(employee);
            _employeeDBContext.SaveChanges();
            return employee;
        }
        public void DeleteEmployee(Employee employee)
        {
            _employeeDBContext.Employees.Remove(employee);
            _employeeDBContext.SaveChanges();               
        }
        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeDBContext.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;               
                _employeeDBContext.Employees.Update(existingEmployee);
                _employeeDBContext.SaveChanges();
            }
            return employee;
           
        }
        public List<Employee> GetAllEmployee()
        {
           return _employeeDBContext.Employees.ToList();
        }
        public Employee GetEmployee(int Id)
        {            
            var employee= _employeeDBContext.Employees.Find(Id);
            return employee;
        }
    }
}
