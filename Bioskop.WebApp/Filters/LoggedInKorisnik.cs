﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bioskop.WebApp.Filters
{
    public class LoggedInKorisnik:ActionFilterAttribute
    {
        // izvrsava se pre izvrsavanja akcije ili posle
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetInt32("userid") == null) {
                context.HttpContext.Response.Redirect("/Korisnik/Login");
                return;
            }
        }
    }
}
