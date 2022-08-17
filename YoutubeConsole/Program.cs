using System;
using System.Threading.Tasks;
using YoutubeExplode;


namespace YoutubeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                throw new ArgumentException("необходимо ввести url");
            };
            var sender = new Sender();
            var videoContent = new VideoContent(args[0]);
            var fileContent = new FileContent();
            var receiver = new ReceiverContent(videoContent, fileContent);
            var loadCommand = new LoadCommand(receiver);
            sender.SetCommand(loadCommand);
            sender.Run();
        }
    }
}
