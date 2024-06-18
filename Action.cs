using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ToDoListTgBOT
{
    abstract class Registration { }
    abstract class Verification { }
    abstract class RecordingToDB { }


    public class Action
    {

        private int AdminID = 1021464499;

        public async Task SendCaseForMe(ITelegramBotClient client, Update update)//метод для записи в бд
        {
            object textMessage = update.Message.Chat.Id;// для отображения в сообщении ID того кто пишет
            await client.SendTextMessageAsync(update.Message.Chat.Id, "ok ", replyToMessageId: update.Message?.MessageId);
            await client.SendTextMessageAsync(update.Message.Chat.Id = AdminID, $"User {textMessage} say {update.Message.Text}");



        }



    }




}

