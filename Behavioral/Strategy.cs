namespace Behavioral.Strategy
{
    // Strategy
    public interface IStrategy
    {
        void Algorithm();
    }

    // ConcreteStrategyA
    public class ConcreteStrategyA : IStrategy
    {
        public void Algorithm()
        {
            System.Console.WriteLine("ConcreteStrategyA: Algorithm");
        }
    }

    // ConcreteStrategyB
    public class ConcreteStrategyB : IStrategy
    {
        public void Algorithm()
        {
            System.Console.WriteLine("ConcreteStrategyB: Algorithm");
        }
    }

    // Context
    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Execute()
        {
            _strategy.Algorithm();
        }
    }

    // Client
    class StrategyProgram
    {
        static void Main(string[] args)
        {
            ConcreteStrategyA strategyA = new ConcreteStrategyA();
            ConcreteStrategyB strategyB = new ConcreteStrategyB();
            Context context = new Context(strategyA);

            context.Execute();
            context.SetStrategy(strategyB);
            context.Execute();
        }
    }
}