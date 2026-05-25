using ASP.NETCoreD08.Data.Context;
using ASP.NETCoreD08.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreD08.Respositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        /*------------------------------------------------------------------*/
        private readonly AppDbContext _context;
        /*------------------------------------------------------------------*/
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        /*------------------------------------------------------------------*/
        //This method will return all the Employees from the Employee table
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.Department).ToList();
        }
        /*------------------------------------------------------------------*/
        //This method will return one Employee's information from the Employee table
        public Employee? GetById(int EmployeeId)
        {
            return _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == EmployeeId);
        }
        /*------------------------------------------------------------------*/
        //This method will Insert one Employee object into the Employee table
        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        /*------------------------------------------------------------------*/
        //This method is going to update the Employee data in the database
        public void Update(Employee employee)
        {
        }
        /*------------------------------------------------------------------*/
        //This method is going to remove the Employee Information from the Database
        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
        /*------------------------------------------------------------------*/
        //This method will make the changes permanent in the database
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        /*------------------------------------------------------------------*/
    }
}
