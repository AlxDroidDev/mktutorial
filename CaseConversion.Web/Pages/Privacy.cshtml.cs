using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaseConversion.Web.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}