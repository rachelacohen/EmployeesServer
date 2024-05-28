using AutoMapper;
using manageServer.Entities;
using manageServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace manageServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        //  GET: api/<DriverController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(_roleService.Get()));
        }

        //  GET api/<DriverController>/5
        [HttpGet("{id}")]
        public ActionResult<Role> GetOne(int id)
        {
            return _roleService.GetById(id);
        }

        //  POST api/<DriverController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] RolePostModel r)
        {
            try
            {
                var rcast = _mapper.Map<Role>(r);
                return Ok(await _roleService.AddRoleAsync(rcast));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> PutDriverAsync(int id, [FromBody] RolePostModel r)
        {
            try
            {
                var rcast = _mapper.Map<Role>(r);
                return await Task.Run(() => Ok(_roleService.UpdateRoleAsync(id, rcast)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> Delete(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return Ok();
        }
    }
}
