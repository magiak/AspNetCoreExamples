using System.Collections.Generic;

namespace AspNetCoreExamples.SOLID._2.OpenClosedPrinciple
{
    public class Example1_1
    {
        public static void MainExample()
        {
            var paymentProvider = new PaymentProvider();

            var movie = "Episode IV – A New Hope (1977)";
            var paymentService = paymentProvider.GetPayment(PaymentMethod.Card);
            paymentService.Pay(movie);
        }

        public enum PaymentMethod
        {
            Card,
            Cash,
            // ...
        }

        public class PaymentProvider
        {
            // Better would be to use DI and generic interfaces IPayment<Card>, IPayment<Cash>, ...
            private readonly Dictionary<PaymentMethod, IPaymentService> _strategy = new Dictionary<PaymentMethod, IPaymentService>
            {
                { PaymentMethod.Card, new CardPayment() },
                { PaymentMethod.Cash, new CashPayment() }
            };

            public IPaymentService GetPayment(PaymentMethod method)
            {
                return _strategy[method];
            }
        }

        public interface IPaymentService
        {
            public void Pay(string item);
        }

        public class CardPayment : IPaymentService
        {
            public void Pay(string item)
            {
                // ...
            }
        }

        public class CashPayment : IPaymentService
        {
            public void Pay(string item)
            {
                // ...
            }
        }

        // Other option
        //public abstract class PaymentMethod
        //{
        //    public static int Card = 1;
        //    public static int Cash = 2;

        //    public int Id { get; set; }
        //    public string Name { get; set; }

        //    public abstract IPaymentService GetService();
        //}
    }
}
