using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeConsole
{
    public abstract class Command
    {
        public abstract void Run();
        public abstract void Cancel();
    }
}
