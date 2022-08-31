using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorIdentityServerTest.Models;
using BlazorIdentityServerTest.Interfaces;

namespace BlazorIdentityServerTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        public HospitalContext _hospitalContext { get; set; }

        public EmployeeService(HospitalContext _context)
        {
            _hospitalContext = _context;
        }


        /// <summary>
        /// Get all employees
        /// <returns>Returns a list of employees</returns>
        /// </summary>
        public List<Employee> GetEmployees()
        {
            return _hospitalContext.Employees.ToList();
        }

        /// <summary>
        /// Get all employees assigned to a specific hospital
        /// <param name="id">ID of the hospital</param>
        /// <returns>Returns a list of employees</returns>
        /// </summary>
        public List<Employee> GetEmployees(int id)
        {
            return _hospitalContext.Employees.Where(x => x.HospitalId == id).ToList();
        }


        /// <summary>
        /// Add a new employee
        /// <param name="emp">Employee to be added</param>
        /// </summary>
        public void AddEmployee(Employee emp)
        {
            _hospitalContext.Add(emp);
        }


        /// <summary>
        /// Save the changes to the database
        /// </summary>
        public void Save()
        {
            _hospitalContext.SaveChanges();
        }


        /// <summary>
        /// Get the number of employees at a hospital
        /// <param name="id">The ID of the hopsitla</param>
        /// <returns>The count of employees</returns>
        /// </summary>
        public int GetCount(int id)
        {
            return _hospitalContext.Employees.Where(x => x.HospitalId == id).Count();
        }

        /// <summary>
        /// Fire an employee. This will remove the employee completely.
        /// <param name="emp">The employee to be removed</param>
        /// </summary>
        public void Fire(Employee emp)
        {
            _hospitalContext.Remove(emp);
        }


        ///<summary>
        /// Convert a role number to a letter role
        ///<param name="role">The number of the role</param>
        /// <returns>A letter role</returns>
        /// </summary>
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
                case 3:
                    return "Patient";
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
                case "3":
                    return "Patient";
                    break;
                default:
                    return "Fejl";
            }
        }
    }
}