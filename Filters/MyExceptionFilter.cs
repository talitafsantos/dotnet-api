using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyMicroservice.Filters {
        public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new
            {
                error = "Ocorreu um erro ao processar sua requisição."
            });
        }
    }
}