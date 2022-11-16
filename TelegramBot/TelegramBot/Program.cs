using AngleSharp;
using AngleSharp.Dom;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace TelegramBot // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        public string group;

        private static ITelegramBotClient botClient = new TelegramBotClient("5632445882:AAG2myCALQz_LCBj2ue1TfQSV_4p7897Ylk");


        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Здоровенечко!");
                    return;
                }
                else if(message.Text.ToLower() == "rasp")
                {

                    IParsers rp1 = new RaspParser();

                    await botClient.SendTextMessageAsync(message.Chat, rp1.GetInform());
                    return;

                }
                else if (message.Text.ToLower() == "settings")
                {
                    Console.WriteLine("Введите вашу группу...");

                    

                }
                else await botClient.SendTextMessageAsync(message.Chat, "Ky");
            }

        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Бот в работеее " + botClient.GetMeAsync().Result.FirstName);


            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = { }
            };
            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );


            Console.ReadLine();

        }

    }
}