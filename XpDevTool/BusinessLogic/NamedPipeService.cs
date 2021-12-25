using GTFuckingXP.Communication.Info;
using GTFuckingXP.Managers;
using System;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace XpDevTool.BusinessLogic
{
    public class NamedPipeService
    {
        private readonly object _lock = new object();
        private NamedPipeClientStream _pipeClient;

        public NamedPipeService()
        {
        }

        public GameState AskForInGameGameState()
        {
            throw new NotImplementedException();
        }

        public string AskForJsonDirectoryPath()
        {
            throw new NotImplementedException();
        }

        public void ReloadLevelDataInGame()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentLevel(int newLevel)
        {
            throw new NotImplementedException();
        }

        public void AddXp(uint addedXp)
        {
            throw new NotImplementedException();
        }

        internal (bool gotSend, Exception exc) SendMessageInternal(CommunicationCommand command)
        {
            if(_pipeClient is null)
            {
                _pipeClient = new NamedPipeClientStream(".", NamedPipeCommunicationManager.NamedPipeServerStreamName,
                PipeDirection.InOut);
            }

            if(!_pipeClient.IsConnected)
            {
                try
                {

                }
                catch(Exception e)
                {

                }

            }

            return (false, null);
        }
    }
}
