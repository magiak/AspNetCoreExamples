namespace AspNetCoreExamples.SOLID._5.DependencyInversionPrinciple
{
    public class Example1_1
    {
        public class Button
        {
            private ISwitchableDevice device;

            public void Poll()
            {
                if (true) // some condition
                {
                    device.TurnOn();
                }
            }
        }

        public interface ISwitchableDevice
        {
            void TurnOn();
        }

        public class Lamp : ISwitchableDevice
        {
            public void TurnOn()
            {

            }
        }

        public class Motor : ISwitchableDevice
        {
            public void TurnOn()
            {

            }
        }
    }
}
