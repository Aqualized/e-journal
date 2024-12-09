using System.Net;

namespace EjournalBack.Web.Models.Responses
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}