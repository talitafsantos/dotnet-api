using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyMicroservice.Filters {
    public class MyAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context == null) 
        {
            throw new ArgumentNullException(nameof(context));
        }
        
        string authHeader = context.HttpContext.Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(authHeader))
        {
            context.Result = new UnauthorizedResult();
        }
        else
        {
            // Aqui você deve validar o token. Como este é apenas um exemplo, vamos apenas verificar se o token é "valid".
            if (authHeader != "valid")
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}

}
