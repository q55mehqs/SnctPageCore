using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnctJikanwari.JikanwariContents.Jugyo;

namespace SnctPageCore.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<IJugyo> DayJugyos { get; private set; }
        public async void OnGet()
        {
            var (jugyo, _) = await SnctJikanwari.JikanwariContents.JikanwariManager.GetJikanwari("IS4", DateTime.Today);
            DayJugyos = jugyo;
        }
    }
}