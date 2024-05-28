using AutoMapper;
using manageServer.Entities;
using manageServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Services;
using System.Text.RegularExpressions;

namespace manageServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        //  GET: api/<DriverController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll()
        {
            var item = _employeeService.Get();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(_employeeService.Get()));
        }

        //  GET api/<DriverController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetOne(int id)
        {
            if (_employeeService.GetById(id) == null)
                return NotFound("עובד לא קיים");
            return Ok(_mapper.Map<EmployeeDto>(_employeeService.GetById(id)));
        }

        //  POST api/<DriverController>
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Employee>> PostAsync([FromBody] EmployeePostModel e)
        {
            try
            {
                var ecast = _mapper.Map<Employee>(e);
                if (e == null || !Regex.IsMatch(e.TZ, @"^\d{9}$") || !Regex.IsMatch(e.Name, @"^[א-תa-zA-Z]{2,100}$") || e.BirthDate == default || e.EntryDate == default)
                    return BadRequest("אחד או יותר מהפרטים שהוזנו שגוי");
                if (e.Roles.Any(x => x.StartDate.CompareTo(e.EntryDate) < 0))
                    return BadRequest("אחד או יותר מהתאריכים לא חוקי");
                if (ecast.Roles.Any(r => ecast.Roles.Count(x => x.RoleId == r.RoleId) > 1))
                    return BadRequest("לא ניתן לכתוב 2 תפקידים זהים לאותו עובד");
                return await _employeeService.AddEmployeeAsync(ecast);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //[Authorize]

        [HttpPut("{id}")]

        public async Task<ActionResult<Employee>> Put(int id, [FromBody] EmployeePostModel e)
        {
            try
            {
                var empToUpdate = _mapper.Map<Employee>(e);
                if (e == null || !Regex.IsMatch(e.TZ, @"^\d{9}$") || !Regex.IsMatch(e.Name, @"^[א-תa-zA-Z]{2,100}$") || e.BirthDate == default || e.EntryDate == default)
                    return BadRequest("אחד או יותר מהפרטים שהוזנו שגוי");
                if (e.Roles.Any(x => x.StartDate.CompareTo(e.EntryDate) < 0))
                    return BadRequest("אחד או יותר מהתאריכים לא חוקי");
                if (empToUpdate.Roles.Any(r => empToUpdate.Roles.Count(x => x.RoleId == r.RoleId) > 1))
                    return BadRequest("לא ניתן לכתוב 2 תפקידים זהים לאותו עובד");
                var updateedEmployee = await _employeeService.UpdateEmployeeAsync(id, empToUpdate);
                var newEmployee = _employeeService.GetById(updateedEmployee.Id);
                var empDto = _mapper.Map<EmployeeDto>(newEmployee);
                return Ok(empDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            if (await _employeeService.DeleteEmployeeAsync(id) != null)

                return Ok();
            return NotFound("עובד לא קים");
        }


    }

}
