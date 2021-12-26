using GTFuckingXP.Communication.Info;
using GTFuckingXP.Managers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XpDevTool.BusinessLogic
{
    public class NamedPipeService
    {
        private readonly object _lock = new object();

        private readonly UnicodeEncoding _streamEncoding = new UnicodeEncoding();
        private NamedPipeClientStream _pipeClient;

        public NamedPipeService()
        {
        }

        public EventHandler<CommunicationCommand> ReceivedMessage;

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
            _ = SendMessageInternalAsync(new CommunicationCommand(Commands.GiveXp, addedXp));
        }

        internal async Task<(bool gotSend, Exception exc)> SendMessageInternalAsync(CommunicationCommand command)
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
                    await _pipeClient.ConnectAsync(2);
                }
                catch(Exception e)
                {
                    return (false, e);
                }
            }

            try
            {
                Monitor.Enter(_lock);
                var stream = (Stream)_pipeClient;
                var message = JsonConvert.SerializeObject(command);

                byte[] outBuffer = _streamEncoding.GetBytes(message);
                int len = outBuffer.Length;
                if (len > UInt16.MaxValue)
                {
                    len = (int)UInt16.MaxValue;
                }

                stream.WriteByte((byte)(len / 256));
                stream.WriteByte((byte)(len & 255));
                await stream.WriteAsync(outBuffer, 0, len);
                await stream.FlushAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
}
