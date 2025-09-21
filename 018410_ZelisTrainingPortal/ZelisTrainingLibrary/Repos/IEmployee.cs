using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface IEmployee
    {
        void NewEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        void UpdateEmployee(int id, Employee employee);
        List<Employee> GetEmployeesByDesignation(string designation);
        void DeleteEmployee(int id);
    }
}
