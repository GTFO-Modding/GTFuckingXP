namespace GTFuckingXP.Communication.Info
{
    public class CommunicationCommand
    {
        public CommunicationCommand(Commands command, object message)
        {
            Command = command;
            Message = message;
        }

        public Commands Command { get; set; }

        public object Message { get; set; }
    }
}
