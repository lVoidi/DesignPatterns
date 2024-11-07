using System;

namespace Structural
{
    // Subject
    public interface ISubject
    {
        void Request();
    }

    // RealSubject
    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    // Proxy
    public class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public void Request()
        {
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            Console.WriteLine("Proxy: Logging request.");
            _realSubject.Request();
        }
    }

    // Client
    public class ProxyClient
    {
        public void ClientCode(ISubject subject)
        {
            subject.Request();
        }
    }

    class ProxyProgram
    {
        static void Main(string[] args)
        {
            ProxyClient client = new();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy();
            client.ClientCode(proxy);
        }
    }
}