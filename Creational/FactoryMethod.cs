using System;

namespace Creational
{
    // Product interface
    public interface IProduct
    {
        string Operation();
    }

    // Concrete Products
    public class ConcreteProductA : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProductA}";
        }
    }

    public class ConcreteProductB : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProductB}";
        }
    }

    // Creator abstract class
    public abstract class Creator
    {
        // Factory Method
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            var product = FactoryMethod();
            // Now, use the product.
            return "Creator: The same creator's code has just worked with " + product.Operation();
        }
    }

    // Concrete Creators
    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    // Client code
    class FactoryMethodClient
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the ConcreteCreatorA.");
            ClientCode(new ConcreteCreatorA());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreatorB.");
            ClientCode(new ConcreteCreatorB());
        }

        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class, but it still works.\n" + creator.SomeOperation());
        }
    }
}