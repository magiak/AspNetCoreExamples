namespace AspNetCoreExamples.SOLID._2.OpenClosedPrinciple
{
    public class Example1
    {
        public static void MainExample()
        {
            var paymentService = new PaymentService();

            var movie = "Episode IV – A New Hope (1977)";

            paymentService.Pay(PaymentMethod.Card, movie);
        }

        public enum PaymentMethod
        {
            Card,
            Cash,
            // ...
        }

        public class PaymentService
        {
            public void Pay(PaymentMethod paymentMethod, string movie)
            {
                if (paymentMethod == PaymentMethod.Card)
                {
                    // ...
                }
                else if (paymentMethod == PaymentMethod.Cash)
                {
                    // ...
                }
                else if (true)
                {
                    // ...
                }
                // more else if statements
            }
        }
    }
}
