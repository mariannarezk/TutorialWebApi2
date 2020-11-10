using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutorialWebApi2.Models;

namespace TutorialWebApi2.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public EmployeeController(DatabaseContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_context.Employees.ToList());
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            var emp = this._context.Employees.Where(m => m.Id == id).FirstOrDefault();
            return Ok(emp);
        }
        [HttpPost]
        public ActionResult<Employee> post(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        [HttpPut]
        public ActionResult<Employee> put(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id}")]

        public ActionResult<Employee> delete(int id)
        {
            Employee employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
    }
}
