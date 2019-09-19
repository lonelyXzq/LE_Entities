using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    public class Feedback
    {
        private readonly ICommand command;

        private readonly bool IsSuccess;

        private readonly string reason;

        public Feedback(ICommand command, bool isSuccess, string reason)
        {
            this.command = command;
            IsSuccess = isSuccess;
            this.reason = reason;
        }

        public ICommand Command => command;

        public bool IsSuccess1 => IsSuccess;

        public string Reason => reason;
    }
}
