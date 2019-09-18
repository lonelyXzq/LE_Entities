using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    public static class CommandManager
    {
        private static Queue<ICommand> commands;
        private static Queue<IFeedback> feedbacks;
        private static Server server;

        static CommandManager()
        {
            commands = new Queue<ICommand>();
            feedbacks = new Queue<IFeedback>();
            server = new Server(1, "command server");
        }

        public static void SendCommand(ICommand command)
        {
            commands.Enqueue(command);
            //return -1;
        }

        public static IFeedback GetFeedback()
        {
            return feedbacks.Count == 0 ? null : feedbacks.Dequeue();
        }
    }
}
