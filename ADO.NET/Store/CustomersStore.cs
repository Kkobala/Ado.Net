using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using ADO.NET.Model;
using Microsoft.Extensions.Configuration;

namespace ADO.NET.Store
{
    public class CustomersStore
    {
        private static string GetConString()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }

        public string GetCustomerByID(int id)
        {
            string sql = "SELECT COUNT(*) FROM dbo.Customers WHERE Id = @id";

            StringBuilder sb = new StringBuilder();

            try
            {
                int rowsAffected = 0;

                // new connection
                using SqlConnection cnn = new SqlConnection(GetConString());
                // new sqlCommand
                using SqlCommand cmd = new SqlCommand(sql, cnn);
                //add parameter for select query
                cmd.Parameters.Add(new SqlParameter("@id", id));

                //open connection and execute
                cnn.Open();
                rowsAffected = (int)cmd.ExecuteScalar();

                if (rowsAffected == 0)
                {
                    sb.Append("Can't Find customer cause key exists");
                    return sb.ToString();
                }

                sb.Append("Found");

                cnn.Close();

                return sb.ToString();

            }
            catch (SqlException ex)
            {
                // Error handling
                // Even though this won't write it to console, I still wrote it for showcasing how to log the error.
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    sb.AppendLine($"Index #: {i}");
                    sb.AppendLine($"Type: {ex.Errors[i].GetType().FullName}");
                    sb.AppendLine($"Message: {ex.Errors[i].Message}");
                    sb.AppendLine($"Source: {ex.Errors[i].Source}");
                    sb.AppendLine($"Number: {ex.Errors[i].Number}");
                    sb.AppendLine($"State: {ex.Errors[i].State}");
                    sb.AppendLine($"Class: {ex.Errors[i].Class}");
                    sb.AppendLine($"Server: {ex.Errors[i].Server}");
                    sb.AppendLine($"Procedure: {ex.Errors[i].Procedure}");
                    sb.AppendLine($"LineNumber: {ex.Errors[i].LineNumber}");
                }

                Console.WriteLine(sb.ToString());

                throw new ArgumentException(nameof(sb), sb.ToString());
            }
        }
        public string GetCustomerByName(string name)
        {
            string sql = "SELECT COUNT(*) FROM dbo.Customers WHERE Name = @name";

            StringBuilder sb = new StringBuilder();

            try
            {
                int rowsAffected = 0;

                // new connection
                using SqlConnection cnn = new SqlConnection(GetConString());
                // new sqlCommand
                using SqlCommand cmd = new SqlCommand(sql, cnn);
                //add parameter for select query
                cmd.Parameters.Add(new SqlParameter("@name", name));

                //open connection and execute
                cnn.Open();
                rowsAffected = (int)cmd.ExecuteScalar();

                if (rowsAffected == 0)
                {
                    sb.AppendLine("Could not find the customer with given name");
                    return sb.ToString();
                }

                sb.Append("Found");

                return sb.ToString();
            }
            catch (SqlException ex)
            {
                // Error handling
                // Even though this won't write it to console, I still wrote it for showcasing how to log the error.
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    sb.AppendLine($"Index #: {i}");
                    sb.AppendLine($"Type: {ex.Errors[i].GetType().FullName}");
                    sb.AppendLine($"Message: {ex.Errors[i].Message}");
                    sb.AppendLine($"Source: {ex.Errors[i].Source}");
                    sb.AppendLine($"Number: {ex.Errors[i].Number}");
                    sb.AppendLine($"State: {ex.Errors[i].State}");
                    sb.AppendLine($"Class: {ex.Errors[i].Class}");
                    sb.AppendLine($"Server: {ex.Errors[i].Server}");
                    sb.AppendLine($"Procedure: {ex.Errors[i].Procedure}");
                    sb.AppendLine($"LineNumber: {ex.Errors[i].LineNumber}");
                }

                Console.WriteLine(sb.ToString());

                throw new ArgumentException(nameof(sb), sb.ToString());
            }
        }

        public string AddCustomer(Customers body)
        {
            //The insert query
            string sql = "INSERT INTO dbo.Customers (Id, Name, Address) VALUES ( @Id, @Name, @Address)";

            StringBuilder sb = new StringBuilder();

            try
            {
                //new connection
                using SqlConnection cnn = new SqlConnection(GetConString());
                //new sqlCommand
                using SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.Text;

                //add the parameters for insert query
                cmd.Parameters.Add(new SqlParameter("@Id", body.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", body.Name));
                cmd.Parameters.Add(new SqlParameter("@Address", body.Address));

                //open the connection and execute your query
                cnn.Open();
                cmd.ExecuteNonQuery();

                sb.Append("Success");

                cnn.Close();

                return sb.ToString();
            }
            catch (SqlException ex)
            {
                // Error handling
                // Even though this won't write it to console, I still wrote it for showcasing how to log the error.
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    sb.AppendLine($"Index #: {i}");
                    sb.AppendLine($"Type: {ex.Errors[i].GetType().FullName}");
                    sb.AppendLine($"Message: {ex.Errors[i].Message}");
                    sb.AppendLine($"Source: {ex.Errors[i].Source}");
                    sb.AppendLine($"Number: {ex.Errors[i].Number}");
                    sb.AppendLine($"State: {ex.Errors[i].State}");
                    sb.AppendLine($"Class: {ex.Errors[i].Class}");
                    sb.AppendLine($"Server: {ex.Errors[i].Server}");
                    sb.AppendLine($"Procedure: {ex.Errors[i].Procedure}");
                    sb.AppendLine($"LineNumber: {ex.Errors[i].LineNumber}");
                }

                Console.WriteLine(sb.ToString());

                throw new ArgumentException(nameof(sb), sb.ToString());
            }
        }

        public string DeleteCustomer(string name)
        {
            string sql = "DELETE FROM Customers WHERE Name = @name";

            StringBuilder sb = new StringBuilder();

            try
            {
                //new connection
                using SqlConnection cnn = new SqlConnection(GetConString());
                //new command
                using SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.Text;

                //add the parameter for delete query
                cmd.Parameters.Add(new SqlParameter("Name", name));

                //Open the connection and execute your query
                cnn.Open();
                cmd.ExecuteNonQuery();

                sb.Append("Success");

                cnn.Close();

                return sb.ToString();
            }
            catch (SqlException ex)
            {
                //Error handling
                //Even though this won't write it to console, I still wrote it for showcasing how to log the error.
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    sb.AppendLine($"Index #: {i}");
                    sb.AppendLine($"Type: {ex.Errors[i].GetType().FullName}");
                    sb.AppendLine($"Message: {ex.Errors[i].Message}");
                    sb.AppendLine($"Source: {ex.Errors[i].Source}");
                    sb.AppendLine($"Number: {ex.Errors[i].Number}");
                    sb.AppendLine($"State: {ex.Errors[i].State}");
                    sb.AppendLine($"Class: {ex.Errors[i].Class}");
                    sb.AppendLine($"Server: {ex.Errors[i].Server}");
                    sb.AppendLine($"Procedure: {ex.Errors[i].Procedure}");
                    sb.AppendLine($"LineNumber: {ex.Errors[i].LineNumber}");
                }

                Console.WriteLine(sb.ToString());

                throw new ArgumentException(nameof(sb), sb.ToString());
            }

        }

        public string UpdateCustomer(string name, string address)
        {
            //The insert query
            string sql = "UPDATE dbo.Customers set Address = @address WHERE Name = @name";

            StringBuilder sb = new StringBuilder();

            try
            {
                //new connection
                using SqlConnection cnn = new SqlConnection(GetConString());
                //new sqlCommand
                using SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.Text;

                //add the parameters for insert query
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@address", address));

                //open the connection and execute your query
                cnn.Open();
                cmd.ExecuteNonQuery();

                sb.Append("Success");

                cnn.Close();

                return sb.ToString();
            }
            catch (SqlException ex)
            {
                // Error handling
                // Even though this won't write it to console, I still wrote it for showcasing how to log the error.
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    sb.AppendLine($"Index #: {i}");
                    sb.AppendLine($"Type: {ex.Errors[i].GetType().FullName}");
                    sb.AppendLine($"Message: {ex.Errors[i].Message}");
                    sb.AppendLine($"Source: {ex.Errors[i].Source}");
                    sb.AppendLine($"Number: {ex.Errors[i].Number}");
                    sb.AppendLine($"State: {ex.Errors[i].State}");
                    sb.AppendLine($"Class: {ex.Errors[i].Class}");
                    sb.AppendLine($"Server: {ex.Errors[i].Server}");
                    sb.AppendLine($"Procedure: {ex.Errors[i].Procedure}");
                    sb.AppendLine($"LineNumber: {ex.Errors[i].LineNumber}");
                }

                Console.WriteLine(sb.ToString());

                throw new ArgumentException(nameof(sb), sb.ToString());
            }
        }

        public string GetAllCustomers()
        {
            string sql = "SELECT Id, Name, Address FROM dbo.Customers";

            StringBuilder sb = new StringBuilder();

            SqlConnection cnn = new SqlConnection(GetConString());

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                sb.AppendLine("Id: " + dr["Id"].ToString());
                sb.AppendLine("Name: " + dr["Name"].ToString());
                sb.AppendLine("Address: " + dr["Address"].ToString());
            }

            return sb.ToString();
        }
    }
}
