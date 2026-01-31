using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Repository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        StepsContext context;
        public EmployeeRepository(StepsContext _context)
        {
            context = _context;//new StepsContext();//paremeterless + onconggif==>static 
        }
        public void Add(Employee obj)
        {
            context.Employees.Add(obj);
        }

        public void Delete(int id)
        {
            Employee emp = GetById(id);
            context.Employees.Remove(emp);
        }

        public List<Employee> GetAll()
        {
           // return context.Employees.AsNoTracking().ToList();
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee obj)
        {
            Employee empfromDb = GetById(obj.Id);
            empfromDb.Name= obj.Name;
            empfromDb.Salary= obj.Salary;
            empfromDb.DepartmentId= obj.DepartmentId;
            empfromDb.ImageURl= obj.ImageURl;
        }
    }
}
