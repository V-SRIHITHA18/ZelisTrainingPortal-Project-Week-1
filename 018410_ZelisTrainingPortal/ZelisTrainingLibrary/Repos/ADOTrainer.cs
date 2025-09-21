using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainer : ITrainer
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOTrainer()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public void DeleteTrainer(int id)
        {
            cmd.CommandText = $"delete from Trainer where TrainerId = {id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public List<Trainer> GetAllTrainers()
        {
            cmd.CommandText = $"select * from Trainer";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Trainer> trainers = new List<Trainer>();
            while (reader.Read())
            {
                Trainer trainer = new Trainer();
                trainer.TrainerId = (int)(reader["TrainerId"]);
                trainer.TrainerName = (string)(reader["Name"]);
                trainer.TrainerType = (char)(reader["Type"]);
                trainer.Email = (string)(reader["Email"]);
                trainer.Phone = (string)(reader["Phone"]);
                trainers.Add(trainer);
            }
            con.Close();
            return trainers;
        }

        public Trainer GetTrainer(int id)
        {
            cmd.CommandText = $"select * from Trainer where TrainerId = {id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Trainer trainer = new Trainer();
            if (reader.HasRows)
            {
                reader.Read();
                trainer.TrainerId = (int)(reader["TrainerId"]);
                trainer.TrainerName = (string)(reader["Name"]);
                trainer.TrainerType = (char)(reader["Type"]);
                trainer.Email = (string)(reader["Email"]);
                trainer.Phone = (string)(reader["Phone"]);
                con.Close();
                return trainer;
            }
            else
            {
                con.Close();
                throw new TrainingException("Trainer Not Found ");
            }

        }

        public List<Trainer> GetTrainersByType(char type)
        {
            cmd.CommandText = $"select * from Trainer where TrainerType = '{type}'";
            con.Open();
            List<Trainer> trainers = new List<Trainer>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainer trainer = new Trainer();
                trainer.TrainerId = (int)(reader["TrainerId"]);
                trainer.TrainerName = (string)(reader["Name"]);
                trainer.TrainerType = (char)(reader["Type"]);
                trainer.Email = (string)(reader["Email"]);
                trainer.Phone = (string)(reader["Phone"]);
                trainers.Add(trainer);
            }
            con.Close();
            return trainers;
        }

        public void NewTrainer(Trainer trainer)
        {
            cmd.CommandText = $"insert into Trainer values({trainer.TrainerId},'{trainer.TrainerName}','{trainer.TrainerType}','{trainer.Email}','{trainer.Phone}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTrainer(int id, Trainer trainer)
        {
            cmd.CommandText = $"update Trainer set TrainerName = '{trainer.TrainerName}', TrainerType = '{trainer.TrainerType}', Email = '{trainer.Email}', Phone = '{trainer.Phone}' where TrainerId = {trainer.TrainerId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
