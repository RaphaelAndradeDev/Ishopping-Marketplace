using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ishopping.MVC
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
            {
                // A sessão está nula ou vazia, não existe usuário logado.
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "Account",
                        action = "Login"
                    })
                );
            }
            else
            {
                // Usuário não tem permissão.
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "Profiles",
                        action = "Create"

                    })
                );
            }
        }
    }
}