using ILogger = Serilog.ILogger;

namespace EjournalBack.Application.Services
{
    public class LoginService
    {
        private readonly ILogger _logger;

        public LoginService(ILogger logger)
        {
            _logger = logger;
        }

        
        
    }
}