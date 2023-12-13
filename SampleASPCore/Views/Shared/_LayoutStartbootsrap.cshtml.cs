using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SampleASPCore.Views.Shared
{
    public class _LayoutStartbootsrap : PageModel
    {
        private readonly ILogger<_LayoutStartbootsrap> _logger;

        public _LayoutStartbootsrap(ILogger<_LayoutStartbootsrap> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}