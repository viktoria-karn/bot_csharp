using System;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

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
            switch (e.Message.Type)
            {
                
                case Telegram.Bot.Types.Enums.MessageType.Contact:
                    string phone = e.Message.Contact.PhoneNumber;
                    client.SendTextMessageAsync(e.Message.Chat.Id, $"Твой телефон {phone}");
                    Console.WriteLine(phone);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    if (e.Message.Text.Substring(0, 1) == "/")
                    {
                        CommandProcessor(e.Message);
                    }
                    else{
                        client.SendTextMessageAsync(e.Message.Chat.Id, $"Ты мне сказал {e.Message.Text} ,но я этого пока не понимаю");
                        Console.WriteLine(e.Message.Text);
                    }
                    break;
            }
          
        }
        /// <summary>
        /// обработка команд
        /// </summary>
        /// <param name=""></param>
        private void CommandProcessor(Telegram.Bot.Types.Message message)
        {
            string command = message.Text.Substring(1).ToLower();

            switch (command)
            {
                case "start":
                    var button = new KeyboardButton("Поделись телефоном");
                    var array = new KeyboardButton[] {button};
                    button.RequestContact = true; //кнопка запрашивает контакт
                    var reply = new ReplyKeyboardMarkup(array,true,true);
                    client.SendTextMessageAsync(message.Chat.Id, $"Привет,{message.Chat.FirstName} ,введи свой номер телефона",replyMarkup:reply);
                    break;
                default:
                    client.SendTextMessageAsync(message.Chat.Id, $"Ты мне сказал {message.Text} ,но я этого пока не понимаю");
                    break;


            }

        }
        public void Run()
        {
            //запуск приема сообщений
            client.StartReceiving();
        }
    }
}

