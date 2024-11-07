namespace Behavioral.Memento
{
    // Originator
    public class Originator
    {
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine($"Originator: Set state to {_state}");
            }
        }

        public Memento Save()
        {
            Console.WriteLine("Originator: Saving to Memento");
            return new Memento(_state);
        }

        public void Restore(Memento memento)
        {
            _state = memento.State;
            Console.WriteLine($"Originator: Restoring from Memento: {_state}");
        }
    }

    // Memento
    public class Memento
    {
        public string State { get; }

        public Memento(string state)
        {
            State = state;
        }
    }

    // Caretaker
    public class Caretaker
    {
        private List<Memento> _mementos = new List<Memento>();

        private Originator _originator;

        public Caretaker(Originator originator)
        {
            _originator = originator;
        }

        public void Backup()
        {
            Console.WriteLine("Caretaker: Saving Originator's state...");
            _mementos.Add(_originator.Save());
        }

        public void Undo()
        {
            if (_mementos.Count == 0)
            {
                return;
            }

            Memento memento = _mementos.Last();
            _mementos.Remove(memento);

            Console.WriteLine($"Caretaker: Restoring state to: {memento.State}");
            _originator.Restore(memento);
        }

        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");
            foreach (Memento memento in _mementos)
            {
                Console.WriteLine(memento.State);
            }
        }
    }

    // Client
    class MementoProgram
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker(originator);

            originator.State = "State1";
            originator.State = "State2";
            caretaker.Backup();

            originator.State = "State3";
            caretaker.Backup();

            originator.State = "State4";
            Console.WriteLine($"Current state: {originator.State}");

            caretaker.Undo();
            Console.WriteLine($"Current state: {originator.State}");

            caretaker.Undo();
            Console.WriteLine($"Current state: {originator.State}");

            caretaker.ShowHistory();
        }
    }
}