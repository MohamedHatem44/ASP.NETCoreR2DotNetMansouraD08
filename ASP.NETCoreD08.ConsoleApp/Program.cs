using System.ComponentModel;

namespace ASP.NETCoreD08.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var orderService = new OrderService(
            //        new PaymentService(),
            //        new OrderRepository(),
            //        new EmailService()
            //    );

            // Dependency Injection (DI)
            // Resolve dependencies and create instances of services
            // IPaymentService paymentService => new PaymentService();
            // IOrderRepository orderRepository => new OrderRepository();
            // IEmailService emailService => new EmailService();

            // Ask Implementation of Services => Create Instance => Which Implementation of Service I Want To Use
            //var orderService = container.Resolve<OrderService>();

            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<ICar, Ford>();
        }
    }
}
