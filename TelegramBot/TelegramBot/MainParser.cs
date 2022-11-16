using System;
using AngleSharp;
using AngleSharp.Dom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
namespace TelegramBot
{
    internal class MainParser
    {
        protected async Task<string> GetPage(string Url)
        {
            HttpClient client = new HttpClient();
            using var response = await client.GetAsync(Url);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

    }
}
