namespace Behavioral.Mediator
{
    // Mediator
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }

    // ConcreteMediator
    public class ConcreteMediator : IMediator
    {
        private Component1 _component1;
        private Component2 _component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            _component1 = component1;
            _component1.SetMediator(this);
            _component2 = component2;
            _component2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacts on A and triggers following operations:");
                _component2.DoC();
            }

            if (ev == "D")
            {
                Console.WriteLine("Mediator reacts on D and triggers following operations:");
                _component1.DoB();
                _component2.DoC();
            }
        }
    }

    // Base Component
    public class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            _mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

    // Component1
    public class Component1 : BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");
            _mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");
            _mediator.Notify(this, "B");
        }
    }

    // Component2
    public class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");
            _mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");
            _mediator.Notify(this, "D");
        }
    }

    // Client
    class MediatorProgram
    {
        static void Main(string[] args)
        {
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            ConcreteMediator mediator = new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggers operation A.");
            component1.DoA();

            Console.WriteLine();
            Console.WriteLine("Client triggers operation D.");
            component2.DoD();

            Console.ReadKey();

        }
    }
}