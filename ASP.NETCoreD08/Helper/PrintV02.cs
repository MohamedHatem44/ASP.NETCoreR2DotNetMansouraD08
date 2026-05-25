namespace ASP.NETCoreD08.Helper
{
    public class PrintV02 : IPrint
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void PrintDateTime()
        {
            Console.WriteLine($"Current Date and Time V02: {DateTime.Now}");
        }

        public void PrintDateTimeUTC()
        {
            Console.WriteLine($"Current Date and Time V02 (UTC): {DateTime.UtcNow}");
        }
    }
}
