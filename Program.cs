using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
//using Telegram.Bot.Types;
using System.Data;
using System.Net;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using VideoLibrary;
using MediaToolkit.Model;
using MediaToolkit;
using System.IO;
using YoutubeExtractor;
using VkNet;

namespace ToDoListTgBOT
{

    public class Program

    {
        static string token = "";

        static void Main()
        {
            Host lihoBot = new Host(token);
            lihoBot.Start();
            Console.ReadLine();
        }


    }
}
