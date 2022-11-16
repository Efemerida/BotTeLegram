using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    internal class SettingGroup : MainParser
    {
        public async Task<Task> ParseR(String group)
        {


            var respounce = await GetPage("https://rasp.sstu.ru");
            HtmlParser hp = new HtmlParser();
            var doc = await hp.ParseDocumentAsync(respounce);


            var dayDate = doc.GetElementsByClassName("col-auto group")[0].Text().Trim();

            Console.WriteLine(dayDate);
            return Task.CompletedTask;
        }

    }
}
