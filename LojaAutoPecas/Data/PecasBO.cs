using LojaAutoPecas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace LojaAutoPecas.Data
{
    public class PecasBO
    {

        private string GetConnectionString()
        {
            return (WebConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString);
        }

        public List<Pecas> GetPecas()
        {
            List<Pecas> pecas = new List<Pecas>();
            try
            {
                string connectionString = GetConnectionString();
                string commandSql = @"SELECT * FROM PecasAuto";

                SqlConnection sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();

                using (SqlCommand command = new SqlCommand(commandSql, sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Pecas _pecas = new Pecas();

                        _pecas.Id = Convert.ToInt32(reader["Id"]);
                        _pecas.Name = reader["Name"].ToString();
                        _pecas.Description = reader["Description"].ToString();
                        _pecas.Price = Convert.ToInt32(reader["Price"]);
                        _pecas.InStock = Convert.ToBoolean(reader["InStock"]);
                        pecas.Add(_pecas);

                    }
                }
                sqlConnection.Close();
                return (pecas);

            }
            catch (Exception err)
            {
                throw err;
            }


        }


        public Pecas GetById(int? id)
        {
            try
            {
                Pecas pc = new Pecas();

                string connectionString = GetConnectionString();
                string SqlCommand = @"SELECT ID, NAME, DESCRIPTION, PRICE, INSTOCK FROM PecasAuto WHERE ID = @id";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                using (SqlCommand command = new SqlCommand(SqlCommand, sqlConnection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        pc.Id = Convert.ToInt32(reader["Id"]);
                        pc.Name = reader["Name"].ToString();
                        pc.Description = reader["Description"].ToString();
                        pc.Price = Convert.ToInt32(reader["Price"]);
                        pc.InStock = Convert.ToBoolean(reader["InStock"]);

                    }

                }
                sqlConnection.Close();
                return pc;
            }


            catch (Exception err)
            {
                throw err;
            }

        }


        public void Create(Pecas pecas)
        {
            string connectionString = GetConnectionString();

            string SqlCommand = @"INSERT INTO PecasAuto (Id, Name, Description, Price, InStock) VALUES (@Id, @Name, @Description, @Price, @InStock)";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();


            using (SqlCommand command = new SqlCommand(SqlCommand, sqlConnection))
            {
                var newID = GetPecas().Last().Id + 1;

                command.Parameters.AddWithValue("@Id", newID);
                command.Parameters.AddWithValue("@Name", pecas.Name);
                command.Parameters.AddWithValue("@Description", pecas.Description);
                command.Parameters.AddWithValue("@Price", pecas.Price);
                command.Parameters.AddWithValue("@InStock", pecas.InStock);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }


        }

        public void Edit(Pecas pecas)
        {
            string connectionString = GetConnectionString();
            string SqlCommand = @"UPDATE PecasAuto SET NAME = @NAME, DESCRIPTION = @DESCRIPTION, PRICE = @PRICE, INSTOCK = @INSTOCK WHERE ID = @ID";


            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (SqlCommand command = new SqlCommand(SqlCommand, sqlConnection))
            {
                //var newId = GetPecas().Last().Id++;

                command.Parameters.AddWithValue("@Id", pecas.Id);
                command.Parameters.AddWithValue("@Name", pecas.Name);
                command.Parameters.AddWithValue("@Description", pecas.Description);
                command.Parameters.AddWithValue("@Price", pecas.Price);
                command.Parameters.AddWithValue("@InStock", pecas.InStock);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public void Delete(int Id)
        {
            string connectionString = GetConnectionString();
            string SqlCommand = @"DELETE FROM PecasAuto WHERE ID = @id";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (SqlCommand command = new SqlCommand(SqlCommand, sqlConnection))
            {
                command.Parameters.Add("@id", SqlDbType.Int).Value = Id;

                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<Pecas> Search(PecasBO model)
        {
            List<Pecas> pecas = new List<Pecas>();
            try
            {
                string connectionString = GetConnectionString();
                //string SqlCommand = @"SELECT ID, NAME, DESCRIPTION, PRICE, INSTOCK FROM PecasAuto WHERE ID = @id OR NAME = @name OR DESCRIPTION = @description";
                //string SqlCommand = @"SELECT ID, NAME, DESCRIPTION, PRICE, INSTOCK FROM PecasAuto WHERE ID = @id";
                string SqlCommand = @"SELECT ID, NAME, DESCRIPTION, PRICE, INSTOCK FROM PecasAuto WHERE NAME LIKE '@name%'";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                using (SqlCommand command = new SqlCommand(SqlCommand, sqlConnection))
                {
                    //depois que o ID estiver funcionando adicionar name e description
                   
                   
                                     
                    
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Pecas _pecas = new Pecas();

                        _pecas.Id = Convert.ToInt32(reader["Id"]);
                        _pecas.Name = reader["Name"].ToString();
                        _pecas.Description = reader["Description"].ToString();
                        _pecas.Price = Convert.ToInt32(reader["Price"]);
                        _pecas.InStock = Convert.ToBoolean(reader["InStock"]);
                        pecas.Add(_pecas);
                    }

                }
                sqlConnection.Close();
                return (pecas);
            }


            catch (Exception err)
            {
                throw err;
            }

        }

    }
}