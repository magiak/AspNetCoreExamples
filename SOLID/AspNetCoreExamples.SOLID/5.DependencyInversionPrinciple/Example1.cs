using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreExamples.SOLID._5.DependencyInversionPrinciple
{
    public class Example1
    {
        public class Button
        {
            private Lamp lamp; // Violetes DIP - button depends on Lamp
            public void Poll()
            {
                if (true) // some condition
                {
                    lamp.TurnOn();
                }
            }
        }

        public class Lamp
        {
            public void TurnOn()
            {

            }
        }
    }
}
