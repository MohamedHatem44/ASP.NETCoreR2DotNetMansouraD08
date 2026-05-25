using ASP.NETCoreD08.Models;

namespace ASP.NETCoreD08.Respositories.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department? GetById(int DepartmentId);
        void Insert(Department department);
        void Update(Department department);
        void Delete(Department department);
        void SaveChanges();
    }
}
