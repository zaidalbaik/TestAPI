using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using TestAPI.Data;
using MQRS_lib.Models;
using MediatR;
using CQRS_lib.CQRS.Queries;
using CQRS_lib.CQRS.Commands;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMediator _mediator;
        public EmployeesController(AppDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AllEmployees()
        {
            try
            {
                var emps = await _mediator.Send(new GetAllEmployeesQuery());
                if (emps == null)
                    return BadRequest();

                return Ok(emps);
            }
            catch (Exception e)
            {
                //Handling Errors 

                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Employee(int id)
        {
            try
            {
                var empIsFound = await _dbContext.Employees.AnyAsync(e => e.Id == id);
                if (!empIsFound)
                    return BadRequest();

                var emp = await _dbContext.Employees.FindAsync(id);
                if (emp == null)
                    return BadRequest();

                return Ok(emp);
            }
            catch (Exception e)
            {
                //Handling Errors 

                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromForm] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var empIsFound = await _dbContext.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id);
                if (empIsFound == null)
                {
                    _mediator.Send(new InsertEmployeeCommand(employee));
                    return Ok(employee);
                }
                else
                {
                    // Employee was not added successfully
                    return StatusCode(500, "Internal server error. Unable to add the employee.");
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
