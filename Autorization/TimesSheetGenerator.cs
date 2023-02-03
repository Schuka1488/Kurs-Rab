using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization
{
    public struct WorkTimeEmployee
    {
        public int Id;
        public long Hours;
        public string FullName;
        public string Role;
    }
    public struct TabelDate
    {
        public DateTime time;
        public string mark;
        public string id;
    }
    public struct TabelMark
    {
        public string mark;
        public string id;
    }
    public class TimeSheetGenerator
    {
        static string GetRuDayOfWeek(DateTime time)
        {
            string res = "NULL";
            switch (time.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Пн";
                case DayOfWeek.Tuesday:
                    return "Вт";
                case DayOfWeek.Wednesday:
                    return "Ср";
                case DayOfWeek.Thursday:
                    return "Чт";
                case DayOfWeek.Friday:
                    return "Пт";
                case DayOfWeek.Saturday:
                    return "Сб";
                case DayOfWeek.Sunday:
                    return "Вс";
            }
            return res;
        }
        public static TabelMark[] ConvertMarksToTabelFormat(int year, int month, TabelDate[] dates)
        {
            int maxDays = DateTime.DaysInMonth(year, month);
            TabelMark[] marks = new TabelMark[maxDays];
            int dateCounter = 0;
            int day = 1;
            for (int i = 0; i < maxDays; i++)
            {
                TabelDate d;
                if (dates.Length <= dateCounter)
                {
                    d = new TabelDate();
                }
                else
                {
                    d = dates[dateCounter];
                }
                DateTime current = DateTime.Parse($"{year}-{month}-{day}");
                if (d.time.ToString("yyyy-MM-dd") == current.ToString("yyyy-MM-dd"))
                {
                    marks[i].mark = d.mark;
                    marks[i].id = d.id;
                    day++;
                    dateCounter++;
                    continue;
                }
                if (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
                {
                    marks[i].mark = "В";
                    marks[i].id = "NULL";
                    day++;
                    continue;
                }
                marks[i].mark = "Н";
                marks[i].id = "NULL";
                day++;
            }
            return marks;
        }
        static string GenerateHtmlDaysOfWeek(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            string style = "table, th, td {border: 2px solid; text-align: center;}";
            string res = $"<html><head><meta charset=\"UTF-8\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><style>{style}</style></head><body><table><th colspan=\"33\" align=\"center\">Табель учёта рабочего времени</th><tr><td rowspan=\"2\">ФИО</td><td rowspan=\"2\">Должность</td>";
            for (int i = 0; i < days; i++)
            {
                res += $"<td>{i + 1}</td>";
            }
            res += "<td rowspan=\"2\">Часов всего</td></tr>";
            for (int i = 0; i < days; i++)
            {
                string dayOfWeek = GetRuDayOfWeek(new DateTime(year, month, i + 1));
                res += $"<td>{dayOfWeek}</td>";
            }
            res += "</tr>";
            return res;
        }
        public void PushHTMLContent(WorkTimeEmployee data, TabelMark[] days)
        {
            string res = "<tr>";
            string jsRes = "";
            res += $"<td>{data.FullName}</td><td>{data.Role}</td>";
            int nId = 0;
            foreach (TabelMark day in days)
            {
                res += $"<td><button onclick=\'js{data.Id}d{nId}()\' name=\"{data.Id}d{nId}\">{day.mark}</button></td>";
                jsRes += $"var js{data.Id}d{nId}" +
                    "= function()" +
                    "{" +
                    "var btnId =" + $"\"{data.Id} {nId}\";" +
                    $"var empId = \"{data.Id}\";" +
                    $"var day = \"{nId}\";" +
                    $"var table_id = \"{day.id}\";" +
                    $"CefSharp.PostMessage(\"{day.id}|{data.Id}|{nId}\");" +
                    "};";
                nId++;
            }
            res += $"<td>{data.Hours}</td>";
            res += "</tr>";
            html += res;
            js += jsRes;

        }
        string html;
        string js;
        public TimeSheetGenerator(int year, int month)
        {
            html += GenerateHtmlDaysOfWeek(year, month);
            js = "";
        }
        public string GenCode()
        {
            string res = html += $"</table><script>{js}</script></body></html>";
            return res;
        }
    }
}
