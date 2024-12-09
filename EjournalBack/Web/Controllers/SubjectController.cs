using EjournalBack.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace EjournalBack.Web.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISubjectRepository _subjectRepository;
        
        public SubjectController(ILogger logger, ISubjectRepository repository)
        {
            _subjectRepository = repository;
            _logger = logger;
        }

        [HttpGet("student")]
        public async Task<IActionResult> GetStudentSubjects(
            [FromQuery]int studentId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var subjects = await _subjectRepository.GetStudentSubjects(studentId);
            return Ok(subjects);
        }

        [HttpGet("group")]
        public async Task<IActionResult> GetGroupSubjects(
            [FromQuery]string groupNumber)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var subjects = await _subjectRepository.GetGroupSubjects(groupNumber);
            return Ok(subjects);
        }

        [HttpGet("teacher")]
        public async Task<IActionResult> GetTeacherSubjects(
            [FromQuery]int teacherId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var subjects = await _subjectRepository.GetTeacherSubjects(teacherId);
            return Ok(subjects);
        }
    }
}