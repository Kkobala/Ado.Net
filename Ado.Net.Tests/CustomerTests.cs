using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ADO.Net;
using ADO.NET.Model;
using ADO.NET.Repository;
using AdoNet;
using NUnit.Framework;

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace ADO.Net.Tests
{
    [TestFixture]
    public sealed class CustomerTests
    {
        // Add customers tests
        // [TestCase(1, "Robertson", "892 Southern Avenue", ExpectedResult = "Success")]
        // [TestCase(2, "Arnold", "2904 Thorn Street", ExpectedResult = "Success")]
       // [TestCase(3, "Spencer", "2151 Murphy Court", ExpectedResult = "Success")]
       // [TestCase(4, "Morales", "3380 Lightning Point Drive", ExpectedResult = "Success")]
       // [TestCase(5, "Jones", "4857 Blackwell Street", ExpectedResult = "Success")]
        // [TestCase(6, "Reynolds", "703 Ashford Drive", ExpectedResult = "Success")]
        public string AddCustomersTestSuccess(int id, string name, string address)
        {
            Program res = new Program();

            var result = res.AddCustomers(id, name, address);

            return result;
        }

        [TestCase(1, "Robertson", "892 Southern Avenue")]
        [TestCase(2, "Arnold", "2904 Thorn Street")]
        public void AddCustomersWithExistingIdTest(int id, string name, string address)
        {
            // Should return exception if the given id already exists in database
            Program res = new Program();

            Assert.Throws<ArgumentException>(() => res.AddCustomers(id, name, address));
        }

        [TestCase(3, "", "892 Southern Avenue")]
        [TestCase(4, "Robertson", null)]
        [TestCase(0, "", "")]
        public void AddCustomerNullAndEmptyValueTests(int id, string name, string address)
        {
            // Should return argument null exception
            Program res = new Program();

            Assert.Throws<ArgumentNullException>(() => res.AddCustomers(id, name, address));
        }

        // End of end customers tests

        // Delete customer tests
        // [TestCase("Robertson", ExpectedResult = "Success")]
        // [TestCase("Arnold", ExpectedResult = "Success")]
        public string DeleteCustomerTestSuccess(string name)
        {
            Program res = new Program();

            var result = res.DeleteCustomers(name);

            return result;
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("Mason")]
        [TestCase("Blaese")]
        public void DeleteCustomerWithNullAndEmptyValues(string name)
        {
            // Should return argument null exception
            Program res = new Program();

            Assert.Throws<ArgumentNullException>(() => res.DeleteCustomers(name));
        }

        // end of delete customer tests 

        // Update customers
        // [TestCase("Jones", "4900 Blackwull str", ExpectedResult = "Success")]
        // [TestCase("Reynolds", "720 Rashford Drive", ExpectedResult = "Success")]
        public string UpdateCustomersSuccess(string name, string address)
        {
            Program res = new Program();

            return res.UpdateCustomers(name, address);
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("Jones", "")]
        [TestCase("Reynolds", null)]
        [TestCase("West", "7205 Rashford Drive")]
        public void UpdateCustomersArgumentNullTests(string name, string address)
        {
            // Should return argument null exception if params are epmty or customer couldn't be found in database
            Program res = new Program();

            Assert.Throws<ArgumentNullException>(() => res.UpdateCustomers(name, address));
        }

        // end of update customers

        // Get all customers
        [TestCase]
#pragma warning disable S2699 // Tests should include assertions
        public void GetAllCustomers()
#pragma warning restore S2699 // Tests should include assertions
        {
            Program res = new Program();

            // I only retrieve the customers with this code
            res.GetAllCustomers();
        }

        // end of get all customers
    }
}
