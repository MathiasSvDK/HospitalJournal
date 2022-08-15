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

        public string ConvertRole(int role) {
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
    }
}