using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Handson.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(path);
            string filePath = Path.Combine(path, "exceptions.txt");

            File.AppendAllText(filePath, $"[{DateTime.Now}] {context.Exception.Message}{Environment.NewLine}");

            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
