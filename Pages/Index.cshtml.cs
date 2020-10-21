using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnctJikanwari;
using SnctJikanwari.JikanwariContents;
using SnctJikanwari.JikanwariContents.Jugyo;

namespace SnctPageCore.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<IJugyo> DayJugyos { get; private set; }
        public string DayTitle { get; private set; }

        public async void OnGet()
        {
            var date = DateTime.Today.SkipHoliday();
            var (jugyo, dayOfWeek) = await JikanwariManager.GetJikanwari("IS4", date);
            DayTitle = date.ToString("yyyy/MM/dd (ddd)", new CultureInfo("ja-JP")) + "時間割" +
                       (date.Date.DayOfWeek == dayOfWeek ? "" : $" ({DayOfWeekToStringJp(dayOfWeek)}曜授業)");
            DayJugyos = jugyo;
        }

        private static string DayOfWeekToStringJp(DayOfWeek dayOfWeek)
        {
            // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
            return dayOfWeek switch
            {
                DayOfWeek.Monday => "月",
                DayOfWeek.Tuesday => "火",
                DayOfWeek.Wednesday => "水",
                DayOfWeek.Thursday => "木",
                DayOfWeek.Friday => "金",
                _ => throw new ArgumentException()
            };
        }
    }
}