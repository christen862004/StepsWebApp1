using WebApp1.Models;

namespace WebApp1.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        StepsContext context;
        public DepartmentRepository(StepsContext _context)
        {
            context = _context;// new StepsContext();
        }

        public void Add(Department obj)
        {
            context.Departments.Add(obj);
        }

        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Departments.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();

        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            Department deptFromDb = GetById(obj.Id);
            deptFromDb.Name=obj.Name;
            deptFromDb.ManagerName = obj.ManagerName;

        }
    }
}
