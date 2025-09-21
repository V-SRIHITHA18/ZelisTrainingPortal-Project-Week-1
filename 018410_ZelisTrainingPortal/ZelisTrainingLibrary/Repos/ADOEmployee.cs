using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOEmployee : IEmployee
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOEmployee()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public void DeleteEmployee(int id)
        {
            cmd.CommandText = $"delete from Employee where EmpId = {id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Employee> GetAllEmployees()
        {
            cmd.CommandText = $"select * from Employee";
            con.Open();
            List<Employee> employees = new List<Employee>();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("List Of All Employess........");
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmpId = (int)(reader["EmpId"]);
                employee.EmpName = (string)(reader["EmpName"]);
                employee.Designation = (string)(reader["Designation"]);
                employee.Email = (string)(reader["Email"]);
                employee.Phone = (string)(reader["Phone"]);
                employees.Add(employee);
            }
            con.Close();
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            cmd.CommandText = $"select * from Employee where EmpId = {id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Employee employee = new Employee();
                employee.EmpId = (int)(reader["EmpId"]);
                employee.EmpName = (string)(reader["EmpName"]);
                employee.Designation = (string)(reader["Designation"]);
                employee.Email = (string)(reader["Email"]);
                employee.Phone = (string)(reader["Phone"]);
                con.Close();
                return employee;

            }
            else
            {
                con.Close();
                throw new TrainingException("Employee Not Found ");
            }
        }

        public List<Employee> GetEmployeesByDesignation(string designation)
        {
            cmd.CommandText = $"Select * from Employee where Designation = '{designation}'";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmpId = (int)(reader["EmpId"]);
                employee.EmpName = (string)(reader["EmpName"]);
                employee.Designation = (string)(reader["Designation"]);
                employee.Email = (string)(reader["Email"]);
                employee.Phone = (string)(reader["Phone"]);
                employees.Add(employee);
            }
            con.Close();
            return employees;
        }
        

        public void NewEmployee(Employee employee)
        {
            cmd.CommandText = $"insert into Employee values({employee.EmpId}, '{employee.EmpName}', '{employee.Designation}','{employee.Email}','{employee.Phone}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            cmd.CommandText = $"update Employee Set EmpName = '{employee.EmpName}', Designation = '{employee.Designation}', Email = '{employee.Email}', Phone = '{employee.Phone}' where EmpId = {employee.EmpId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
