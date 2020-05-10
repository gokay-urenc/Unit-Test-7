using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionAsserts.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private List<string> _users;

        [TestInitialize]
        public void CreateData()
        {
            _users = new List<string>();

            _users.Add("Coach");
            _users.Add("Nick");
            _users.Add("Ellis");
        }

        [TestMethod]
        public void Items_and_their_rows_must_be_same()
        {
            List<string> newUsers = new List<string>();

            newUsers.Add("Coach");
            newUsers.Add("Nick");
            newUsers.Add("Ellis");

            CollectionAssert.AreEqual(_users, newUsers);
        }

        [TestMethod]
        public void Items_must_be_same_but_their_rows_could_be_different()
        {
            List<string> newUsers = new List<string>();

            newUsers.Add("Nick");
            newUsers.Add("Coach");
            newUsers.Add("Ellis");

            CollectionAssert.AreEquivalent(_users, newUsers);
        }

        [TestMethod]
        public void Items_must_be_different()
        {
            List<string> newUsers = new List<string>();

            newUsers.Add("Coach");
            newUsers.Add("Nick");
            newUsers.Add("Ellis");
            newUsers.Add("Zoey");

            CollectionAssert.AreNotEquivalent(_users, newUsers);
        }

        [TestMethod]
        public void Items_and_their_rows_must_be_different()
        {
            List<string> newUsers = new List<string>();

            newUsers.Add("Nick");
            newUsers.Add("Coach");
            newUsers.Add("Ellis");

            CollectionAssert.AreNotEqual(_users, newUsers);
        }

        [TestMethod]
        public void Users_values_must_not_be_null()
        {
            // _users.Add(null);
            CollectionAssert.AllItemsAreNotNull(_users);
        }

        [TestMethod]
        public void Users_must_be_unique()
        {
            // _users.Add("Coach");
            CollectionAssert.AllItemsAreUnique(_users);
        }

        [TestMethod]
        public void All_items_must_be_the_same_type()
        {
            ArrayList list = new ArrayList { "Coach", "Nick", "Ellis" /*, 5 */ };

            CollectionAssert.AllItemsAreInstancesOfType(list, typeof(string));
        }

        [TestMethod]
        public void Is_subset_of_test()
        {
            List<string> newUsers = new List<string>() { "Coach", "Nick" };
            List<string> oldUsers = new List<string>() { "Coach", "Zoey" };

            CollectionAssert.IsSubsetOf(newUsers, _users);
            CollectionAssert.IsNotSubsetOf(oldUsers, _users);
        }

        [TestMethod]
        public void Contains_test()
        {
            CollectionAssert.Contains(_users, "Coach");
            CollectionAssert.DoesNotContain(_users, "Zoey");
        }
    }
}