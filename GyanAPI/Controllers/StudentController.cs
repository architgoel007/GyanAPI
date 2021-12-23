using GyanAPI.APIResponse;
using GyanAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GyanAPI.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        public ILogger<StudentController> _logger { get; }
        public IApiResponses ApiResponses { get; }
        public StudentController(IStudent student, ILogger<StudentController> logger, IApiResponses apiResponses)
        {
            _student = student;
            _logger = logger;
            ApiResponses = apiResponses;
        }

        //Get All record by API
        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            try
            {
                return await _student.GetStudents();
            }
            catch (Exception)
            {
                _logger.LogError($"Error:(ex)");
                throw;
            }
        }

        //Get record by id API
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                Student st = _student.GetStudent(id);
                // return Ok(st);
                return Ok(ApiResponses.SuccessResponse(st, "Success!"));
            }
            catch (Exception)
            {
                _logger.LogError($"Error:(ex)");
                // throw new Exception();
                return Ok(ApiResponses.ServerError($"Student Not Found With Id:{id}"));
            }
        }
        //Add record by API
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            try
            {
                //throw new Exception();
                return Ok(ApiResponses.SuccessResponse(await _student.AddStudent(student), "Success!"));
            }
            catch (Exception)
            {
                _logger.LogError($"Error:(ex)");
                return Ok(ApiResponses.ServerError("User Already Exists!"));
            }
        }

        //Update complete record by id API
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            try
            {
                return Ok(ApiResponses.SuccessResponse(_student.UpdateStudent(student), "Success"));
            }
            catch (Exception)
            {
                _logger.LogError($"Error:(ex)");
                return Ok(ApiResponses.ServerError("Not Found!"));
            }
        }

        //Delete record by id API
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var ExisitingStudent = _student.GetStudent(id);
                if (id != 0 && id > 0)
                {
                    _student.DeleteStudent(ExisitingStudent);
                    return Ok();
                }
                return NotFound($"Student Not Found With Id:{id}");
            }
            catch (Exception)
            {
                _logger.LogError($"Error:(ex)");
                return null;
            }
        }

        [HttpGet]
       public async Task<IEnumerable<Country>> GetCountry()
        {
            try
            {
                return await _student.GetCountry();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
