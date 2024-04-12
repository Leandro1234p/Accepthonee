using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace AcceptPhone.Helper
{
    public static class UserClaimHelper
    {
        public static string GetEmail(this IIdentity identity)
        {
            if(identity == null)
                return string.Empty;
            var claim = (ClaimsIdentity)identity;
            return claim.FindFirst("Email")?.Value;
        }
    }
}