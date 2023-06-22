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
