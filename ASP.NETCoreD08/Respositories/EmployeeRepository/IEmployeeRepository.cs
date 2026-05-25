using ASP.NETCoreD08.Models;

namespace ASP.NETCoreD08.Respositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int EmployeeId);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        void SaveChanges();
    }
}