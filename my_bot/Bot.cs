using System;
using Telegram.Bot;

namespace CSharpBot
{
    class Bot
    {
        private TelegramBotClient client;

        public Bot()
        {
            client = new TelegramBotClient("1407910466:AAHbtN0Rx0CQ9NhW2ZankVdmRmfRM02qu-Y");
            client.OnMessage += MessageProcessor;
        }
        /// <summary>
        /// Обработка входящего сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageProcessor(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            client.SendTextMessageAsync(e.Message.Chat.Id, $"Привет!");
            Console.WriteLine(e.Message.Text);
        }
        public void Run()
        {
            //запуск приема сообщений
            client.StartReceiving();
        }
    }
}

