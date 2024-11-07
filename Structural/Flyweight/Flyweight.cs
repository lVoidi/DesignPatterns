using System;
using System.Collections.Generic;

namespace Structural.Flyweight
{
    // Flyweight interface
    public interface IFlyweight
    {
        void Operation(int extrinsicState);
    }

    // ConcreteFlyweight class
    public class ConcreteFlyweight : IFlyweight
    {
        private string intrinsicState;

        public ConcreteFlyweight(string intrinsicState)
        {
            this.intrinsicState = intrinsicState;
        }

        public void Operation(int extrinsicState)
        {
            Console.WriteLine($"ConcreteFlyweight: IntrinsicState = {intrinsicState}, ExtrinsicState = {extrinsicState}");
        }
    }

    // FlyweightFactory class
    public class FlyweightFactory
    {
        private Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

        public IFlyweight GetFlyweight(string key)
        {
            if (!flyweights.ContainsKey(key))
            {
                flyweights[key] = new ConcreteFlyweight(key);
            }
            return flyweights[key];
        }
    }

    // Client code
    class FlyweightClient
    {
        static void Main(string[] args)
        {
            FlyweightFactory factory = new FlyweightFactory();

            IFlyweight flyweight1 = factory.GetFlyweight("A");
            flyweight1.Operation(1);

            IFlyweight flyweight2 = factory.GetFlyweight("B");
            flyweight2.Operation(2);

            IFlyweight flyweight3 = factory.GetFlyweight("A");
            flyweight3.Operation(3);

            Console.ReadKey();
        }
    }
}