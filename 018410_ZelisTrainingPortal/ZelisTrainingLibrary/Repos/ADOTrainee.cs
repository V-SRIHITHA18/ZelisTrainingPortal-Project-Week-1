using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;
using Microsoft.Data.SqlClient;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainee : ITrainee
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOTrainee()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public void DeleteTrainee(int id)
        {
            cmd.CommandText = $"delete from Trainee where TrainerId = {id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public List<Trainee> GetAllTrainees()
        {
            cmd.CommandText = $"select * from Trainee";
            con.Open();
            List<Trainee> trainees = new List<Trainee>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.TrainingId = (int)(reader["TrainingId"]);
                trainee.EmpId = (int)(reader["EmpId"]);
                trainee.Status = (char)(reader["Status"]);
                trainees.Add(trainee);
            }
            con.Close();
            return trainees;

        }
        

        public List<Training> GetAllTrainingsByTrainee(int id)
        {
            cmd.CommandText = $"select * from Tarining where TrainingId = {id}";
            con.Open();
            List<Training> training = new List<Training>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Training item = new Training();
                item.TrainingId = (int)(reader["TrainingId"]);
                item.TrainerId = (int)(reader["TrainerId"]);
                item.StartDate = (DateOnly)(reader["StartDate"]);
                item.EndDate = (DateOnly)(reader["EndDate"]);
                training.Add(item);
            }
            con.Close();
            return training;
        }

        public Trainee GetTrainee(int id)
        {
            cmd.CommandText = $"select * from Trainee where TrainingId = {id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Trainee item = new Trainee();
                item.TrainingId = (int)(reader["TrainingId"]);
                item.EmpId = (int)(reader["EmpId"]);
                item.Status = (char)(reader["Status"]);
                con.Close();
                return item;
            }
            else
            {
                con.Close();
                throw new TrainingException("Trainee Not Found ");
            }
        }

        public List<Trainee> GetTraineesByStatus(char status)
        {
            cmd.CommandText = $"select * from Trainee where Status = '{status}'";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Trainee> trainees = new List<Trainee>();
            while (reader.Read())
            {
                Trainee item = new Trainee();
                item.TrainingId = (int)(reader["TrainingId"]);
                item.EmpId = (int)(reader["EmpId"]);
                item.Status = (char)(reader["Status"]);
                trainees.Add(item);
            }
            con.Close();
            return trainees;
        }

        public Employee GetTrainerDetails(int id)
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
                throw new TrainingException("Trainer Not Found ");
            }
        }

        public void NewTrainee(Trainee trainee)
        {
            cmd.CommandText = $"insert into Trainee values({trainee.TrainingId},{trainee.EmpId},'{trainee.Status}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void UpdateTrainee(int id, Trainee trainee)
        {
            cmd.CommandText = $"update Trainee set Status = '{trainee.Status}' where TrainingId = {id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
