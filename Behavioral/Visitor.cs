namespace Behavioral.Visitor
{
    // Visitor
    public interface IVisitor
    {
        void VisitConcreteElementA(ConcreteElementA element);
        void VisitConcreteElementB(ConcreteElementB element);
    }

    // ConcreteVisitorA
    public class ConcreteVisitorA : IVisitor
    {
        public void VisitConcreteElementA(ConcreteElementA element)
        {
            System.Console.WriteLine("ConcreteVisitorA: VisitConcreteElementA");
        }

        public void VisitConcreteElementB(ConcreteElementB element)
        {
            System.Console.WriteLine("ConcreteVisitorA: VisitConcreteElementB");
        }
    }

    // ConcreteVisitorB
    public class ConcreteVisitorB : IVisitor
    {
        public void VisitConcreteElementA(ConcreteElementA element)
        {
            System.Console.WriteLine("ConcreteVisitorB: VisitConcreteElementA");
        }

        public void VisitConcreteElementB(ConcreteElementB element)
        {
            System.Console.WriteLine("ConcreteVisitorB: VisitConcreteElementB");
        }
    }

    // Element
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // ConcreteElementA
    public class ConcreteElementA : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
    }

    // ConcreteElementB
    public class ConcreteElementB : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
    }

    // ObjectStructure
    public class ObjectStructure
    {
        private List<IElement> _elements = new List<IElement>();

        public void Attach(IElement element)
        {
            _elements.Add(element);
        }

        public void Detach(IElement element)
        {
            _elements.Remove(element);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (IElement element in _elements)
            {
                element.Accept(visitor);
            }
        }
    }

    // Client
    class VisitorProgram
    {
        static void Main(string[] args)
        {
            ObjectStructure objectStructure = new ObjectStructure();
            objectStructure.Attach(new ConcreteElementA());
            objectStructure.Attach(new ConcreteElementB());

            ConcreteVisitorA visitorA = new ConcreteVisitorA();
            ConcreteVisitorB visitorB = new ConcreteVisitorB();

            objectStructure.Accept(visitorA);
            objectStructure.Accept(visitorB);

            // Output:
            // ConcreteVisitorA: VisitConcreteElementA
            // ConcreteVisitorA: VisitConcreteElementB
            // ConcreteVisitorB: VisitConcreteElementA
            // ConcreteVisitorB: VisitConcreteElementB
        }
    }
}