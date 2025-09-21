using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTechnology : ITechnology
    {
        SqlConnection con;
        SqlCommand cmd;
        public ADOTechnology()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public void DeleteTechnology(int id)
        {
            cmd.CommandText = $"delete from Technology where TechnologyId = {id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Technology> GetAllTechnologies()
        {
            cmd.CommandText = $"select * from Technology";
            con.Open();
            List<Technology> technology = new List<Technology>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Technology item = new Technology();
                item.TechnologyId = (int)(reader["TechnologyId"]);
                item.TechName = (string)(reader["TechName"]);
                item.TechLevel = (char)(reader["TechLevel"]);
                item.Duration = (int)(reader["Duration"]);
                technology.Add(item);
            }
            con.Close();
            return technology;
        }

        public List<Technology> GetTechnologiesByLevel(char level)
        {
            cmd.CommandText = $"select * from Technology where TechLevel = '{level}'";
            con.Open();
            List<Technology> technologies = new List<Technology>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Technology item = new Technology();
                item.TechnologyId = (int)(reader["TechnologyId"]);
                item.TechName = (string)(reader["TechName"]);
                item.TechLevel = (char)(reader["TechLevel"]);
                item.Duration = (int)(reader["Duration"]);
                technologies.Add(item);
            }
            con.Close();
            return technologies;
        }

        public Technology GetTechnology(int id)
        {
            cmd.CommandText = $"select * from Technology where = {id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Technology item = new Technology();
                item.TechnologyId = (int)(reader["TechnologyId"]);
                item.TechName = (string)(reader["TechName"]);
                item.TechLevel = (char)(reader["TechLevel"]);
                item.Duration = (int)(reader["Duration"]);
                con.Close();
                return item;
            }
            else
            {
                con.Close();
                throw new TrainingException("Technology Not Found ");
            }
        }

        public void NewTechnology(Technology technology)
        {
            cmd.CommandText = $"insert into Technology values({technology.TechnologyId},'{technology.TechName}','{technology.TechLevel}',{technology.Duration})";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTechnology(int id, Technology technology)
        {
            cmd.CommandText = $"update Technology set TechName = '{technology.TechName}',TechLevel = '{technology.TechLevel}', Duration = {technology.Duration} where TechnologyId = {technology.TechnologyId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
