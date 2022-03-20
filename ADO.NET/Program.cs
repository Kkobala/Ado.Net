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
        private static string GetConString()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }

        public string AddCustomers(int id, string name, string address)
        {
            CustomersRepo repo = new CustomersRepo();

            if (id == 0)
            {
                throw new ArgumentNullException(nameof(name), "Id should not be 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Empty name isn't allowed");
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address), "Address must not be empty");
            }

            var check = repo.GetCustomerByID(id);

            if (check != "Found")
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
        
        public string GetAllCustomers()
        {
            CustomersRepo repo = new CustomersRepo();

            return repo.GetAllCustomers();
        }
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
