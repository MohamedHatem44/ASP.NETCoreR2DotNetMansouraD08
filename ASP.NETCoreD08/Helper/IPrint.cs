namespace ASP.NETCoreD08.Helper
{
    public interface IPrint
    {
        public Guid Id { get; set; }
        void PrintDateTime();
    }
}