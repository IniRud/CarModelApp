using CarModelApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarModelApp.Data
{
    public class CarDAO : ICarOption
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //skip id when inserting, auto increamented
                    string sqlQuery = "DELETE FROM dbo.Vehicles WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                //associate id with parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 30).Value = id;


                connection.Open();
               

                int deletedID = command.ExecuteNonQuery();

                return deletedID;
            }
        }


        public List<CarModel> GetAllCars()
        {
            List<CarModel> carList = new List<CarModel>();
            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Vehicles";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new oblect and add it to the list to return
                        CarModel car = new CarModel();
                        car.Id = reader.GetInt32(0);
                        car.Model = reader.GetString(1);
                        car.Production = reader.GetInt32(2);

                        carList.Add(car);
                    }
                }
            }

            return carList;
        }

        public CarModel GetCarById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Vehicles WHERE Id = @id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                // associate id with parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                CarModel car = new CarModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        car.Id = reader.GetInt32(0);
                        car.Model = reader.GetString(1);
                        car.Production = reader.GetInt32(2);


                    }
                }
                return car;
            }
        }

        public int Insert(CarModel carModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //skip id when inserting, auto increamented
                string sqlQuery = "INSERT INTO dbo.Vehicles VALUES(@Model, @Production)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                // associate id with parameter
                command.Parameters.Add("@Model", System.Data.SqlDbType.VarChar, 30).Value = carModel.Model;
                command.Parameters.Add("@Production", System.Data.SqlDbType.Int, 1000).Value = carModel.Production;

                connection.Open();
                //SqlDataReader reader = command.ExecuteReader(); no more reading

                int newID = command.ExecuteNonQuery();

                return newID;
            }
        }

        public List<CarModel> SearchCar(string search)
        {
            throw new NotImplementedException();
        }

        public int Update(CarModel carModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //skip id when inserting, auto increamented
                string sqlQuery = "";
                if (carModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Vehicles VALUES(@Model, @Production)";
                }
                else
                {
                    //update
                    sqlQuery = "UPDATE dbo.Vehicles SET Model = @Model, Production = @Production WHERE Id = @Id";
                }


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                // associate id with parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 30).Value = carModel.Id;
                command.Parameters.Add("@Model", System.Data.SqlDbType.VarChar, 30).Value = carModel.Model;
                command.Parameters.Add("@Production", System.Data.SqlDbType.Int, 1000).Value = carModel.Production;

                connection.Open();
                //SqlDataReader reader = command.ExecuteReader(); no more reading

                int newID = command.ExecuteNonQuery();

                return newID;
            }
        }
    }
}