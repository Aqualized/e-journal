using EjournalBack.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace EjournalBack.Web.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupAttendanceController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGroupRepository _groupRepository;
        
        public GroupAttendanceController(ILogger logger, IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery]string subjectName,
            [FromQuery]string groupNumber)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var group = await _groupRepository.GetGroupAsync(subjectName, groupNumber);
            return Ok(group);
        }
    }
}