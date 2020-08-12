using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeRegister.Core.Models;
using EmployeeRegister.Core.Services.Contracts;
using EmployeeRegister.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegister.Controllers
{
    [Produces("application/json")]
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IWindmillDataService _windmillDataService;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, IWindmillDataService windmillDataService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _windmillDataService = windmillDataService;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>A list of employees</returns>
        /// <response code="200"></response>
        /// <response code="500">Internal server error</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var wind = await _windmillDataService.GetCurrentWind();
                var powerPrice = await _windmillDataService.GetCurrentPowerPrice();
                var windmills = await _windmillDataService.GetAllWindmills("Reidar", "kMObLyPfkU+n8A6dBLY1Nw==");
                await _windmillDataService.ChangeWindmillIsActivated("Reidar", "kMObLyPfkU+n8A6dBLY1Nw==", "03931163-a55b-4f64-b282-b483b5dba4d3", false);

                var all = await _employeeService.GetAll();
                return Ok(all);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Get an employee by id
        /// </summary>
        /// <returns>An employee</returns>
        /// <response code="200"></response>
        /// <response code="500">Internal server error</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var all = await _employeeService.Get(id);
                return Ok(all);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Create an employee
        /// </summary>
        /// <returns>The created employee</returns>
        /// <response code="200"></response>
        /// <response code="500">Internal server error</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Create([FromBody] EmployeeDto employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = _mapper.Map<Employee>(employee);
                var newEmployee = await _employeeService.Create(model);
                return Ok(newEmployee);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update an employee
        /// </summary>
        /// <returns>The updated employee</returns>
        /// <response code="200"></response>
        /// <response code="500">Internal server error</response>
        [AllowAnonymous]
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeDto employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id <= 0)
                    return BadRequest("The id must be grater than 0");

                var model = _mapper.Map<Employee>(employee);
                model.Id = id;
                var updatedEmployee = await _employeeService.UpdateEmployee(model);
                return Ok(updatedEmployee);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update an employee
        /// </summary>
        /// <returns>The updated employee</returns>
        /// <response code="200"></response>
        /// <response code="500">Internal server error</response>
        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("The id must be grater than 0");

                await _employeeService.DeleteEmployee(id);
                return Ok($"The employee with Id: {id} is deleted.");

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
