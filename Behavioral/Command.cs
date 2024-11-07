namespace Behavioral.Command
{
    // Command
    public interface ICommand
    {
        void Execute();
    }

    // ConcreteCommand
    public class ConcreteCommand : ICommand
    {
        private Receiver _receiver;

        public ConcreteCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Action();
        }
    }

    // Receiver
    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver: Action");
        }
    }

    // Invoker
    public class Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

    // Client
    class CommandProgram
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            ConcreteCommand command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }
}