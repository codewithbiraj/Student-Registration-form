using Form.Data;
using Form.Dto;
using Form.Service.Implementation;
using Form.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Form.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentservice;

        public StudentController(IStudentService studentService)
        {
            _studentservice = studentService;
        }
        [HttpGet]

        public async Task<IActionResult> GetStudentsAsync()
        {
            var students =  await _studentservice.GetStudentsAsync();
            return Ok(students);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentAsync( [FromBody] StudentDto StudentDto)
        {
            var student = await _studentservice.AddStudentAsync( StudentDto);
            if (student == null)
                return NotFound("Student details not found");
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentsByIdAsync(int id,[FromBody] StudentDto StudentDto) {

            var student = await _studentservice.UpdateStudentsByIdAsync(id, StudentDto);
            if (student == null)
                return NotFound("Student details not found");
            return Ok(student);
        
        
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentByIdAsync(int id)
        {
            var student = await _studentservice.DeleteStudentByIdAsync(id);
            if (student == null)
                return NotFound("Student details not found");
            return Ok(student);
        }
        }
}
