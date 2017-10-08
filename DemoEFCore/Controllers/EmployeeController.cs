using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoEFCore.DataAccessLayer;
using DemoEFCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoEFCore.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly MyDbContext _dbContext;

        public EmployeeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/employee
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_dbContext.Employee);
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_dbContext.Employee.SingleOrDefault(p => p.Id == id));
        }

        // POST api/employee
        [HttpPost]
        public IActionResult Post([FromBody]Employee entity)
        {
            _dbContext.Employee.Add(entity);
            _dbContext.SaveChanges();
            return Get(entity.Id);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Employee entity)
        {
            var oriEmployee = _dbContext.Employee.SingleOrDefault(c => c.Id == entity.Id);
            if (oriEmployee != null)
            {
                _dbContext.Entry(entity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var oriEmployee = _dbContext.Employee.SingleOrDefault(c => c.Id == id);
            if (oriEmployee != null)
            {
                _dbContext.Employee.Remove(oriEmployee);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
