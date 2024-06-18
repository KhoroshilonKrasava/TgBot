using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ToDoListTgBOT
{


    public class Host
    {
        private TelegramBotClient _bot;
        public Host(string token) => _bot = new TelegramBotClient(token);
        public void Start() => _bot.StartReceiving(UpdateHandler, ErrorHandler);
        ConnectionSQLServer connectionSql = new ConnectionSQLServer();

        private async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken arg3)
        {
            await connectionSql.Authentication(client, update);
            if (connectionSql.ID == null)
            {
                await connectionSql.Registration(client, update);
                Console.WriteLine("if");
            }
            else
            {
                await connectionSql.RecordingSQL(client, update);
                Console.WriteLine("else");
            }


        }

        private async Task ErrorHandler(ITelegramBotClient client, Exception exeption, CancellationToken arg3)
        {
            Console.WriteLine("Ошибка" + exeption);
            await Task.CompletedTask;
        }
        

    }
}
