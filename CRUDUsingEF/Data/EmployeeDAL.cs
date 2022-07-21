using CRUDUsingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingEF.Data
{
    public class EmployeeDAL
    {
        ApplicationDbContext db;
        public EmployeeDAL(ApplicationDbContext db)

        {
            this.db = db;
        }
        public List<Employee> GetAllProducts()
        {
            return db.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            Employee p = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }

        public int AddEmployee(Employee emp)
        {
            db.Employees.Add(emp);
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            Employee p = db.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name = emp.Name;
                p.Salary = emp.Salary;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            Employee p = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                db.Employees.Remove(p);
                result = db.SaveChanges();
            }
            return result;
        }

    }
}
