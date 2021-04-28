using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Abstract;
using School.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Get All Students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _studentService.GetAllHotel();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        /// <summary>
        /// Get Student ById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await _studentService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Create an Student
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getbyname")]
        public async Task<IActionResult> GetByName(string name)
        {

            var result = await _studentService.GetByName(name);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Create an Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentService.Create(student);
                return Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update an Hotel
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Student student)
        {
            var result = await _studentService.Update(student);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        /// <summary>
        /// Delete an Student
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =await _studentService.GetById(id);
            if (result!=null)
            {
                await _studentService.Delete(id);
                return Ok();
            }
            return NotFound();
        }

    }
}
