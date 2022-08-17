using System.Threading.Tasks;

namespace YoutubeConsole
{
    internal class LoadCommand : Command
    {
        private Receiver _receiver;
        public LoadCommand(Receiver receiver)
        {
            _receiver = receiver;
        }
        public override void Run()
        { 
            Task task = _receiver.Operation();
            task.Wait();
        }
        public override void Cancel()
        {
            throw new System.NotImplementedException();
        }
    }
}