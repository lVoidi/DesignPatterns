namespace Behavioral.State 
{
    // Context
    public class Context
    {
        private State _state = null;

        public Context(State state)
        {
            TransitionTo(state);
        }

        public void TransitionTo(State state)
        {
            _state = state;
            _state.SetContext(this);
        }

        public void Request1()
        {
            _state.Handle1();
        }

        public void Request2()
        {
            _state.Handle2();
        }
    }

    // State
    public abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            _context = context;
        }

        public abstract void Handle1();
        public abstract void Handle2();
    }

    // ConcreteStateA
    public class ConcreteStateA : State
    {
        public override void Handle1()
        {
            System.Console.WriteLine("ConcreteStateA handles request1.");
            System.Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            _context.TransitionTo(new ConcreteStateB());
        }

        public override void Handle2()
        {
            System.Console.WriteLine("ConcreteStateA handles request2.");
        }
    }

    // ConcreteStateB
    public class ConcreteStateB : State
    {
        public override void Handle1()
        {
            System.Console.WriteLine("ConcreteStateB handles request1.");
        }

        public override void Handle2()
        {
            System.Console.WriteLine("ConcreteStateB handles request2.");
            System.Console.WriteLine("ConcreteStateB wants to change the state of the context.");
            _context.TransitionTo(new ConcreteStateA());
        }
    }
}