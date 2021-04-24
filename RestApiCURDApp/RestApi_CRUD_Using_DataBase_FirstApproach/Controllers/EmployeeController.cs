using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi_CRUD_Using_DataBase_FirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CRUD_Using_DataBase_FirstApproach.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       /* [HttpGet]
        public IEnumerable<Employee> Get()
        {
            using (var context = new EmployeeDataContext())
            {
                //Retreive Data
                var empList = context.Employees.ToList();
                return empList;
            }
        }*/
        [HttpGet]
        public IEnumerable<Employee> Get(int id)
        {
            using (var context = new EmployeeDataContext())
            {
                //Retreive Data
                var empList = context.Employees.Where(s => s.Id == id).ToList();
                return empList;
            }
        }
        /* [HttpPost]
         public IEnumerable<Employee> Post()
         {
             using (var context = new EmployeeDataContext())
             {
                 //Add Data
                 Employee employee = new Employee();
                 employee.Name = "Saheb";
                 employee.Age = 25;
                 employee.Salary = 23000;
                 employee.City = "Patna";
                 context.Employees.Add(employee);
                 context.SaveChanges();
                 Console.WriteLine("Data Inserted");
                 return context.Employees.Where(s => s.Id == 1).ToList();
             }
         }*/

        [HttpPost]
        public IEnumerable<Employee> Post(Employee employee)
        {            
            using (EmployeeDataContext context = new EmployeeDataContext())
            {
                Employee employee1 = new Employee()
                {
                    Name = employee.Name,
                    Age = employee.Age,
                    Salary=employee.Salary,
                    City=employee.City
                };
                context.Employees.Add(employee1);
                context.SaveChanges();
                return context.Employees.ToList();
            }
        }

        [HttpPut]
        public IEnumerable<Employee> Put(Employee employee,int id)
        {            
            using (var context = new EmployeeDataContext())
            {
              
                var existingEmployee = context.Employees.Where(s => s.Id == id)
                                                    .FirstOrDefault<Employee>();
               
                   existingEmployee.Name = employee.Name;
                   existingEmployee.Age = employee.Age;
                   existingEmployee.Salary = employee.Salary;
                   existingEmployee.City = employee.City;

                  context.SaveChanges();
                var empList = context.Employees.Where(s => s.Id == id).ToList();
                return empList;

            }
          
        }


        [HttpDelete]
        public IEnumerable<Employee> Delete(int id)
        {
            using (var context = new EmployeeDataContext())
            {
                Employee employee = context.Employees.Where(s => s.Id == id).FirstOrDefault();
                context.Employees.Remove(employee);
                context.SaveChanges();
                return context.Employees.ToList();
            }
        }


        /* [HttpPatch]
         public IEnumerable<Employee> Patch(int id)
         {
             using (var context = new EmployeeDataContext())
             {
                 Employee employee = context.Employees.Where(s => s.Id == id).FirstOrDefault();
                 employee.Name = "Uttam Babu";
                 context.SaveChanges();
                 return context.Employees.Where(s => s.Id == 1).ToList();
             }
         }*/

       
    }
}
