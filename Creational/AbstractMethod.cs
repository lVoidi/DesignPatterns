namespace Creational
{
    // Abstract Product
    public interface IButton
    {
        void Render();
    }

    // Concrete Product
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a button in Windows style.");
        }
    }

    public class MacOSButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a button in MacOS style.");
        }
    }

    // Abstract Factory
    public interface IGUIFactory
    {
        IButton CreateButton();
    }

    // Concrete Factory
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }
    }

    public class MacOSFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }
    }

    // Client
    public class Application
    {
        private readonly IButton _button;

        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
        }

        public void Render()
        {
            _button.Render();
        }
    }

    // Usage
    class AbstractMethodClient
    {
        static void Main(string[] args)
        {
            IGUIFactory factory;
            string os = "Windows"; // This could be determined at runtime

            if (os == "Windows")
            {
                factory = new WindowsFactory();
            }
            else
            {
                factory = new MacOSFactory();
            }

            Application app = new Application(factory);
            app.Render();
        }
    }
}