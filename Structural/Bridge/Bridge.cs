using System;

namespace Structural
{
    // Abstraction
    public abstract class RemoteControl
    {
        protected IDevice device;

        protected RemoteControl(IDevice device)
        {
            this.device = device;
        }

        public abstract void TurnOn();
        public abstract void TurnOff();
    }

    // Refined Abstraction
    public class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public override void TurnOn()
        {
            device.On();
        }

        public override void TurnOff()
        {
            device.Off();
        }

        public void SetChannel(int channel)
        {
            device.SetChannel(channel);
        }
    }

    // Implementor
    public interface IDevice
    {
        void On();
        void Off();
        void SetChannel(int channel);
    }

    // Concrete Implementor
    public class TV : IDevice
    {
        public void On()
        {
            Console.WriteLine("TV is On");
        }

        public void Off()
        {
            Console.WriteLine("TV is Off");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine($"TV channel set to {channel}");
        }
    }

    // Concrete Implementor
    public class Radio : IDevice
    {
        public void On()
        {
            Console.WriteLine("Radio is On");
        }

        public void Off()
        {
            Console.WriteLine("Radio is Off");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine($"Radio channel set to {channel}");
        }
    }

    class BridgeClient
    {
        static void Main(string[] args)
        {
            IDevice tv = new TV();
            RemoteControl remoteControl = new AdvancedRemoteControl(tv);
            remoteControl.TurnOn();
            remoteControl.TurnOff();

            IDevice radio = new Radio();
            remoteControl = new AdvancedRemoteControl(radio);
            remoteControl.TurnOn();
            remoteControl.TurnOff();
        }
    }
}