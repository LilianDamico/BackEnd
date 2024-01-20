using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IManagementService _managementService;

        public ManagementController(IManagementService managementService)
        {
            _managementService = managementService;
        }

       

       

        [HttpGet("{id:int}", Name = "GetManagement")]
        public async Task<ActionResult<Management>> GetManagement(int id)
        {
            try
            {
                var management = await _managementService.GetManagement(id);
                if (management == null)
                {
                    return NotFound();
                }
                return Ok(management);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Management management)
        {
            try
            {
                await _managementService.CreateManagement(management);
                return CreatedAtRoute("GetManagement", new { id = management.Id }, management);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Management management)
        {
            try
            {
                if (management.Id == id)
                {
                    await _managementService.UpdateManagement(management);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var management = await _managementService.GetManagement(id);
                if (management != null)
                {
                    await _managementService.DeleteManagement(management);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
