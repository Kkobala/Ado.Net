using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ADO.Net;
using ADO.NET.Model;
using ADO.NET.Store;
using AdoNet;
using NUnit.Framework;

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace ADO.Net.Tests
{
    [TestFixture]
    public sealed class AdoNetTests
    {   
        [TestCase(1, "Jim", "532 Back Street")]
        [TestCase(2, "Benedict", "221 Baker Street")]
        public void AddCustomersWithExistingIdTest(int id, string name, string address)
        {
            Program res = new Program();

            Assert.Throws<ArgumentException>(() => res.AddCustomers(id, name, address));
        }

        [TestCase(3, "", "532 Back Street")]
        [TestCase(4, "Jim", null)]
        [TestCase(0, "", "")]
        public void AddCustomerNullAndEmptyValueTests(int id, string name, string address)
        {
            Program res = new Program();

            Assert.Throws<ArgumentNullException>(() => res.AddCustomers(id, name, address));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("RDJ")]
        [TestCase("Isaac")]
        public void DeleteCustomerWithNullAndEmptyValues(string name)
        {
            Program res = new Program();

            Assert.Throws<ArgumentNullException>(() => res.DeleteCustomers(name));
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("Michael", "")]
        [TestCase("Jim", null)]
        [TestCase("West", "2963 New York")]
        public void UpdateCustomersArgumentNullTests(string name, string address)
        {
            Program res = new Program();

            Assert.Throws<ArgumentNullException>(() => res.UpdateCustomers(name, address));
        }

        [TestCase]
        public void GetAllCustomers()
        {
            Program res = new Program();

            res.GetAllCustomers();
        }
    }
}
