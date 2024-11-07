using System;

namespace Structural.Decorator
{
    // Component
    public interface IComponent
    {
        string Operation();
    }

    // ConcreteComponent
    public class ConcreteComponent : IComponent
    {
        public string Operation()
        {
            return "ConcreteComponent";
        }
    }

    // Decorator
    public abstract class Decorator : IComponent
    {
        protected IComponent _component;

        public Decorator(IComponent component)
        {
            _component = component;
        }

        public virtual string Operation()
        {
            return _component.Operation();
        }
    }

    // ConcreteDecoratorA
    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    // ConcreteDecoratorB
    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }

    // Client code
    class DecoratorClient
    {
        static void Main(string[] args)
        {
            IComponent component = new ConcreteComponent();
            Console.WriteLine("Client: I've got a simple component:");
            Console.WriteLine(component.Operation());

            IComponent decorator1 = new ConcreteDecoratorA(component);
            Console.WriteLine("Client: Now I've got a decorated component:");
            Console.WriteLine(decorator1.Operation());

            IComponent decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a double-decorated component:");
            Console.WriteLine(decorator2.Operation());
        }
    }
}