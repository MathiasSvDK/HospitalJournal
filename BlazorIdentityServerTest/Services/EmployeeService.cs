using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorIdentityServerTest.Models;

namespace BlazorIdentityServerTest.Services
{
    public class EmployeeService
    {
        public HospitalContext _hospitalContext { get; set; }
        public EmployeeService(HospitalContext _context)
        {
            _hospitalContext = _context;
        }

        public List<Employee> GetEmployees()
        {
            return _hospitalContext.Employees.ToList();
        }
        public List<Employee> GetEmployees(int id)
        {
            return _hospitalContext.Employees.Where(x => x.HospitalId == id).ToList();
        }


        public void AddEmployee(Employee emp)
        {
            _hospitalContext.Add(emp);
        }

        public void Save() {
            _hospitalContext.SaveChanges();
        }


        public int GetCount(int id) {
            return _hospitalContext.Employees.Where(x => x.HospitalId == id).Count();
        }

        public void Fire(Employee emp) {
            _hospitalContext.Remove(emp);
        }


        public string ConvertRole(int role)
        {
            switch (role)
            {
                case 0:
                    return "Admin";
                    break;
                case 1:
                    return "Læge";
                    break;
                case 2:
                    return "Sygeplejerske";
                    break;
                default:
                    return "Fejl";
            }
        }

        public string ConvertRole(string role)
        {
            switch (role)
            {
                case "0":
                    return "Admin";
                    break;
                case "1":
                    return "Læge";
                    break;
                case "2":
                    return "Sygeplejerske";
                    break;
                default:
                    return "Fejl";
            }
        }
    }
}