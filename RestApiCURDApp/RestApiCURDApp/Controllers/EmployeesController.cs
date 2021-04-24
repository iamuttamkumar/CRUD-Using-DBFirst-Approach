using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCURDApp.EmployeeData;
using RestApiCURDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCURDApp.Controllers
{
   
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            //return Ok(_employeeData.GetAllEmployee());
            var emp = _employeeData.GetAllEmployee();
            return Ok (emp);
        }

        [Route("api/[controller]/{Id}")]
        [HttpGet]
        public IActionResult GetEmployee(int Id)
        {
            var employee=_employeeData.GetEmployee(Id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee With Id {Id} is Not Found");
        }


        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult GetEmployee(Employee employee)
        {
           _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host+
                HttpContext.Request.Path + "/" + employee.Id,employee);
        }


        [Route("api/[controller]/{Id}")]
        [HttpDelete]
        public IActionResult DeleteEmployee(int Id)
        {
            var employee = _employeeData.GetEmployee(Id);
            if(employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee With Id:{Id} was Not Found.");
        }


        [Route("api/[controller]/{Id}")]
        [HttpPatch]
        public IActionResult EditEmployee(int Id,Employee employee)
        {
            var existingemployee = _employeeData.GetEmployee(Id);
           if(existingemployee != null)
            {
                employee.Id = existingemployee.Id;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);
        }
    }
}
