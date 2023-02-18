using DbSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;

namespace DbSample.Pages
{
    public class testModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int sn { get; set; }
        private readonly IConfiguration _configuration;
        public testModel(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public IActionResult OnGet()
        {
            string s = "";

            List<test> list = test.getTable(_configuration, sn);

            s = JsonConvert.SerializeObject(list);

            return Content(s, "text/json");
        }
    }
}
