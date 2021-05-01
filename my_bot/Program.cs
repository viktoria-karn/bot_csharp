using System;

namespace CSharpBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск бота в консольном режиме. Нажмите Enter для завершения");
            Bot bot = new Bot();
            bot.Run();
            Console.ReadLine();
        }
    }
}
