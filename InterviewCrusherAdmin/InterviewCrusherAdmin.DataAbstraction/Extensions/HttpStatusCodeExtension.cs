using System.Net;

namespace InterviewCrusherAdmin.DataAbstraction.Extensions
{
  public static class HttpStatusCodeExtension
  {
    public static string GetDescription(this HttpStatusCode httpStatusCode)
    {
      switch (httpStatusCode)
      {
        case HttpStatusCode.OK:
          return "OK";
        case HttpStatusCode.Created:
          return "Created";
        case HttpStatusCode.Accepted:
          return "Accepted";
        case HttpStatusCode.NoContent:
          return "No Content";
        case HttpStatusCode.BadRequest:
          return "Bad Request";
        case HttpStatusCode.Unauthorized:
          return "Unauthorized";
        case HttpStatusCode.Forbidden:
          return "Forbidden";
        case HttpStatusCode.NotFound:
          return "Not Found";
        case HttpStatusCode.MethodNotAllowed:
          return "Method Not Allowed";
        case HttpStatusCode.Conflict:
          return "Conflict";
        case HttpStatusCode.InternalServerError:
          return "Internal Server Error";
        default:
          return "Unknown";
      }
    }
  }
}
