namespace ASP.NETCoreD08.Helper
{
    public class PrintV01 : IPrint
    {
        public Guid Id { get; set; }

        public PrintV01()
        {
            Id = Guid.NewGuid();
        }

        public void PrintDateTime()
        {
            Console.WriteLine($"Current Date and Time V01: {DateTime.Now}");
        }
    }
}
