public class MyActionFilter : IActionFilter
{
    private Stopwatch stopwatch;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        stopwatch = Stopwatch.StartNew();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        stopwatch.Stop();
        Console.WriteLine($"Ação executada em: {stopwatch.ElapsedMilliseconds} ms");
    }
}
