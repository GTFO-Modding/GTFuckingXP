using System.IO.Pipes;

namespace GTFuckingXP.Managers
{
    public class NamedPipeCommunicationManager
    {
        public const string NamedPipeServerStreamName = "XpNamedPipeName";
        private NamedPipeServerStream _server;

        public NamedPipeCommunicationManager()
        {
            if(!BepInExLoader.RundownDevMode.Value)
            {
                return;
            }

            _server = new NamedPipeServerStream(NamedPipeServerStreamName, PipeDirection.InOut, 1);
        }

        public void ListenForMessages()
        {

        }
    }
}
