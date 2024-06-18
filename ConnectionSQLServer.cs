using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ToDoListTgBOT
{
    class ConnectionSQLServer
    {
        private object _id = null;
        public object ID { get { return _id; } set { } } // Проверка на наличие в бд
        private static string connection = "Data Source=NIKITAPC;Initial Catalog=ToDoList;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);


        public async Task RecordingSQL(ITelegramBotClient client, Update update) // запись сообщения в бд с его id
        {
            string MessegeFromUser = update.Message.Text;// костыль для передачи данных меж классами. пофиксить
            long ChatIdUser = update.Message.Chat.Id;// костыль для передачи данных меж классами. пофиксить
            Console.WriteLine(MessegeFromUser);
            string sqlCommandRecording = $"INSERT INTO qwe (Users_id,Cases) values ('{ChatIdUser}','{MessegeFromUser}')";
            SqlCommand command = new SqlCommand(sqlCommandRecording, sqlConnection);
            command.CommandText = sqlCommandRecording;
            await sqlConnection.OpenAsync();
            Console.WriteLine(sqlConnection.State);
            command.Connection = sqlConnection;
            await command.ExecuteNonQueryAsync();
            sqlConnection.Close();
            Console.WriteLine(sqlConnection.State);
        }
        public async Task Registration(ITelegramBotClient client, Update update)
        {
            long ChatId = update.Message.Chat.Id;
            string sqlCommandAddChatId = $"INSERT INTO Users (Chat_ID) values ('{ChatId}')";
            await sqlConnection.OpenAsync();
            SqlCommand command2 = new SqlCommand(sqlCommandAddChatId, sqlConnection);
            await command2.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }
        public async Task Authentication(ITelegramBotClient client, Update update)
        {
            long ChatIdUser = update.Message.Chat.Id;
            string sqlCommandSelect = $"select Chat_id from Users where Chat_id in ('{ChatIdUser}');";
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                _id = null;
                await sqlConnection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlCommandSelect, sqlConnection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows) // если есть данные
                {
                    while (await reader.ReadAsync()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        _id = id;
                    }
                }
                reader.Close();


            }
        }
    }
}