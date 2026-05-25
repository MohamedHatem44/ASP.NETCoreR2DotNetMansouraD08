namespace ASP.NETCoreD08.ConsoleApp
{
    public class OrderService
    {
        //private readonly IPaymentService _paymentService = new PaymentService();
        //private readonly IOrderRepository _orderRepository = new OrderRepository();
        //private readonly IEmailService _emailService = new EmailService();

        private readonly IPaymentService _paymentService;
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;

        public OrderService(IPaymentService paymentService, IOrderRepository orderRepository, IEmailService emailService)
        {
            _paymentService = paymentService;
            _orderRepository = orderRepository;
            _emailService = emailService;
        }

        public void PlaceOrder(string orderId, string customerId, decimal amount)
        {
            // 1- Proccess Payment
            //Console.WriteLine($"Processing payment of {amount} for order {orderId}...");
            //var paymentService = new PaymentService();
            _paymentService.ProcessPayment(orderId, amount);

            // 2- Save Order To Database
            //Console.WriteLine($"Saving order {orderId} to database...");
            //var orderRepository = new OrderRepository();
            _orderRepository.SaveOrder(orderId);

            // 3- Send Email To Customer
            //Console.WriteLine($"Sending email to customer {customerId}...");
            //var emailService = new EmailService();
            _emailService.SendConfimationEmail(customerId);
        }
    }

    #region Payment Service
    public interface IPaymentService
    {
        void ProcessPayment(string orderId, decimal amount);
    }

    public class PaymentService : IPaymentService
    {
        public void ProcessPayment(string orderId, decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} for order {orderId}...");
        }
    }
    #endregion

    #region Order Repository
    public interface IOrderRepository
    {
        void SaveOrder(string orderId);
    }

    public class OrderRepository : IOrderRepository
    {
        public void SaveOrder(string orderId)
        {
            Console.WriteLine($"Saving order {orderId} to database...");
        }
    }
    #endregion

    #region Email Service
    public interface IEmailService
    {
        void SendConfimationEmail(string customerId);
    }

    public class EmailService : IEmailService
    {
        public void SendConfimationEmail(string customerId)
        {
            Console.WriteLine($"Sending email to customer {customerId}...");
        }
    } 
    #endregion
}
