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
    public sealed class CustomersTests
    {   
        [TestCase(1, "Robertson", "892 Southern Avenue")]
        [TestCase(2, "Arnold", "2904 Thorn Street")]
        public void AddCustomersWithExistingIdTest(int id, string name, string address)
        {
            Program res = new Program();

            Assert.Throws<ArgumentException>(() => res.AddCustomers(id, name, address));
        }

        [TestCase(3, "", "892 Southern Avenue")]
        [TestCase(4, "Robertson", null)]
        [TestCase(0, "", "")]
        public void AddCustomerNullAndEmptyValueTests(int id, string name, string address)
        {
            Program res = new Program();

            Assert.Throws<ArgumentNullException>(() => res.AddCustomers(id, name, address));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("Mason")]
        [TestCase("Blaese")]
        public void DeleteCustomerWithNullAndEmptyValues(string name)
        {
            Program res = new Program();

            Assert.Throws<ArgumentNullException>(() => res.DeleteCustomers(name));
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("Jones", "")]
        [TestCase("Reynolds", null)]
        [TestCase("West", "7205 Rashford Drive")]
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
