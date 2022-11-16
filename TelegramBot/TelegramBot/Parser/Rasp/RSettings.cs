
namespace TelegramBot.Parser.Rasp
{
    public class RSettings : IParserSettings
    {

        public RSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://rasp.sstu.ru/rasp/group/16";
        public string Prefix { get; set; } = "group";
        public int StartPoint { get;  set; }
        public int EndPoint { get; set ; }
    }
}
