using WebApp1.Models;

namespace WebApp1.Repository
{
    public class EmployeeFRomMEmeoryREpository : IEmployeeRepository
    {
        public void Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>() { new Employee() {Id=1,Name="Ahmed"}, new Employee() { Id = 2, Name = "Sara" } };
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
