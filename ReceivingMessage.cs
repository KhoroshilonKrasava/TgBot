using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListTgBOT
{
    class ReceivingMessage
    {
        
        public string sendMessage(string message)
        {
            if (message != "")
                return message;
            else
                Console.WriteLine("null");
            return message = " ";
        }


    }
}
