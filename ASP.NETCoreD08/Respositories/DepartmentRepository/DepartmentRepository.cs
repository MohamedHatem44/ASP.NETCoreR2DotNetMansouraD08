using ASP.NETCoreD08.Data.Context;
using ASP.NETCoreD08.Models;

namespace ASP.NETCoreD08.Respositories.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        /*------------------------------------------------------------------*/
        private readonly AppDbContext _context;
        /*------------------------------------------------------------------*/
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        /*------------------------------------------------------------------*/
        //This method will return all the Departments from the Department table
        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        /*------------------------------------------------------------------*/
        //This method will return one Department's information from the Department table
        public Department? GetById(int DepartmentId)
        {
            return _context.Departments.Find(DepartmentId);
        }
        /*------------------------------------------------------------------*/
        //This method will Insert one Department object into the Department table
        public void Insert(Department department)
        {
            _context.Departments.Add(department);
        }
        /*------------------------------------------------------------------*/
        //This method is going to update the Department data in the database
        //It will receive the Department object as an argument
        public void Update(Department department)
        {
        }
        /*------------------------------------------------------------------*/
        //This method is going to remove the Department Information from the Database
        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
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
