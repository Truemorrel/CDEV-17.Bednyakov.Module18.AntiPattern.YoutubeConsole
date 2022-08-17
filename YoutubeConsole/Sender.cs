using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeConsole
{
    public class Sender
    {
        Command _command;
        public void SetCommand(Command command)
        {
            _command = command;
        }
        public void Run()
        {
            _command.Run();
        }

        public void Cancel()
        {
            _command.Cancel();
        }
    }
}
