using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using WebService.Models;

namespace WebService.Controllers
{
    //[EnableCors(origins: "http://localhost:49414/Home/Index", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        APIDbEntities db = new APIDbEntities();
        public IEnumerable<Employee> GetEmployee()
        {
            return db.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            return db.Employees.FirstOrDefault(e => e.EmpId == id);
        }
        public void Post(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
        }

        public void Put(int id, Employee e)
        {
            Employee emp=db.Employees.FirstOrDefault(em => em.EmpId == id);
            emp.EmpName = e.EmpName;
            emp.Gender = e.Gender;
            emp.Salary = e.Salary;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Employees.FirstOrDefault(em => em.EmpId == id);
            db.Employees.Remove(data);
            db.SaveChanges();
        }
    }
}
