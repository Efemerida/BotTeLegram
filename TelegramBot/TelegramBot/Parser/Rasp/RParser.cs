using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html;
using AngleSharp.Html.Dom;

namespace TelegramBot.Parser.Rasp
{
    public class RParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName!=null && item.ClassName.Contains("day day-current"));
        
            
            foreach(var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        
        }
    }
}
