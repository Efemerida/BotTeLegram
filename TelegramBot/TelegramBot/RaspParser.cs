using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot
{
    internal class RaspParser : MainParser, IParsers
    {

        private List<Lesson> AllLessons = new List<Lesson>();
        private string day;
        private string data;

        private async Task<Task> ParseR()
        {
            data = "";
            day = "";
            AllLessons.Clear();


            var respounce = await GetPage("https://rasp.sstu.ru/rasp/group/16");
            HtmlParser hp = new HtmlParser();
            var doc = await hp.ParseDocumentAsync(respounce);


            var dayDate = doc.GetElementsByClassName("day day-current")[0].GetElementsByClassName("day-header")[0].Text().Trim();
            dayDate = dayDate.ToString();
   


            for (int i = 0; i < dayDate.Length; i++)
            {
                if ((dayDate[i] >= '0' && dayDate[i] <= '9') || (dayDate[i] == '.'))
                {
                    data += dayDate[i];
                }
                else day += dayDate[i];
            }

          
            var lessons = doc.GetElementsByClassName("day day-current")[0].GetElementsByClassName("day-lesson");

            
             for (int i = 0; i < lessons.Length; i++)
             {

                 if (String.IsNullOrEmpty(lessons[i].Text().Trim()))
                 {


                     AllLessons.Add(null);
                 }

                 else
                 {

                     AllLessons.Add(new Lesson(
                         lessons[i].GetElementsByClassName("lesson-hour")[0].Text().Trim().Remove(lessons[i].GetElementsByClassName("lesson-hour")[0].Text().Trim().Length-1, 1),
                         lessons[i].GetElementsByClassName("lesson-room")[0].Text().Trim(),
                         lessons[i].GetElementsByClassName("lesson-name")[0].Text().Trim(),
                         lessons[i].GetElementsByClassName("lesson-type")[0].Text().Trim(),
                         lessons[i].GetElementsByClassName("lesson-teacher")[0].Text().Trim()
                         ));

                 }



             }
                                   
            return  Task.CompletedTask;

        }

        public  string GetInform()
        {
            

            if ((int)DateTime.Now.DayOfWeek == 0) return "Сегодня выходной!!!!";

            ParseR().GetAwaiter().GetResult();

            string res = "Сегодня "  + data + " - " + day + "\nИ твои пары на сегодня:\n\n";

            foreach (Lesson lesson in AllLessons)
            {
                if (lesson != null) res+= lesson.ToString() + "\n";
            }
            return res;
        }
    }
}
