namespace Behavioral.Observer
{
    // Subject
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // ConcreteSubject
    public class ConcreteSubject : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private int _state;

        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                Notify();
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    // Observer
    public interface IObserver
    {
        void Update();
    }

    // ConcreteObserver
    public class ConcreteObserver : IObserver
    {
        private ConcreteSubject _subject;

        public ConcreteObserver(ConcreteSubject subject)
        {
            _subject = subject;
        }

        public void Update()
        {
            Console.WriteLine($"ConcreteObserver: {_subject.State}");
        }
    }

    // Client
    class ObserverProgram
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();
            ConcreteObserver observer = new ConcreteObserver(subject);

            subject.Attach(observer);
            subject.State = 123;
        }
    }
}