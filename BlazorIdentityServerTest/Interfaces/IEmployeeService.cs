using BlazorIdentityServerTest.Models;

namespace BlazorIdentityServerTest.Interfaces;

public interface IEmployeeService
{
    HospitalContext _hospitalContext { get; set; }

    ///<summary>
    /// Get all employees
    /// <returns>Returns a list of employees</returns>
    /// </summary>
    List<Employee> GetEmployees();

    ///<summary>
    /// Get all employees assigned to a specific hospital
    ///<param name="id">ID of the hospital</param>
    /// <returns>Returns a list of employees</returns>
    /// </summary>
    List<Employee> GetEmployees(int id);

    ///<summary>
    /// Add a new employee
    ///<param name="emp">Employee to be added</param>
    /// </summary>
    void AddEmployee(Employee emp);

    ///<summary>
    /// Save the changes to the database
    /// </summary>
    void Save();

    ///<summary>
    /// Get the number of employees at a hospital
    ///<param name="id">The ID of the hopsitla</param>
    /// <returns>The count of employees</returns>
    /// </summary>
    int GetCount(int id);

    ///<summary>
    /// Fire an employee. This will remove the employee completely.
    ///<param name="emp">The employee to be removed</param>
    /// </summary>
    void Fire(Employee emp);

    ///<summary>
    /// Convert a role number to a letter role
    ///<param name="role">The number of the role</param>
    /// <returns>A letter role</returns>
    /// </summary>
    string ConvertRole(int role);

    string ConvertRole(string role);
}