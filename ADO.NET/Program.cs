using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using ADO.NET.Model;
using ADO.NET.Repository;

namespace AdoNet
{
    public class Program
    {
        #region GetConnectionString
        private static string GetConString()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region AddCustomer
        public string AddCustomers(int id, string name, string address)
        {
            CustomersRepo repo = new CustomersRepo();

            if (id == 0)
            {
                throw new ArgumentNullException(nameof(name), "Id must not be 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name must not be empty");
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address), "Address must not be empty");
            }

            var check = repo.GetCustomerByID(id);

            if (check != "Success")
            {
                throw new ArgumentException(nameof(name));
            }

            Customers customers = new Customers()
            {
                Id = id,
                Name = name,
                Address = address
            };

            var res = repo.AddCustomer(customers);

            return res;
        }
        #endregion

        #region DeleteCustomers
        public string DeleteCustomers(string name)
        {
            CustomersRepo repo = new CustomersRepo();

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Must not be empty nor null");
            }

            var check = repo.GetCustomerByName(name);

            if (check != "Found")
            {
                throw new ArgumentNullException(nameof(name), "Could not find the customer with given name");
            }

            var res = repo.DeleteCustomer(name);
            return res;
        }
        #endregion

        #region UpdateCustomers
        public string UpdateCustomers(string name, string address)
        {
            CustomersRepo repo = new CustomersRepo();

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name must not be empty");
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address), "Address must not be empty");
            }

            var check = repo.GetCustomerByName(name);
            if (check != "Found")
            {
                throw new ArgumentNullException(nameof(name), "Could not find the customer with given name");
            }

            var res = repo.UpdateCustomer(name, address);

            return res;
        }
        #endregion

        #region GetAllCustomers
        public string GetAllCustomers()
        {
            CustomersRepo repo = new CustomersRepo();

            return repo.GetAllCustomers();
        }
        #endregion
        static void Main()
        {
            Console.WriteLine("Hello ADO.NET!");

            SqlConnection connection = new SqlConnection(GetConString());
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed");
            }
            Console.Read();
        }
    }
}
