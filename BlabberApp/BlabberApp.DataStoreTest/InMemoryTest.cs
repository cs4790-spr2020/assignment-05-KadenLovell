using BlabberApp.DataStore.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Exceptions;
using BlabberApp.Domain.Entities;
using System;
using System.Collections;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class InMemoryTest {
        private InMemory _inMemory = new InMemory();
        private UserAdapter _harness = new UserAdapter(new InMemory());

        private User _user;
        private readonly string _email = "foobar@example.com";

        [TestInitialize]
        public void Setup() {
            _user = new User(_email);
            _harness = new UserAdapter(new InMemory());
            _harness.RemoveAll();
        }

        [TestMethod]
        public void Canary() {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Not found")]
        public void TestCreate() {
            _inMemory.Create(_user);
            _inMemory.Update(_user);
            _inMemory.ReadAll();
            _inMemory.ReadByUserId(_user.Id.ToString());
            _inMemory.ReadByUserEmail("foobar@example.com");
            _inMemory.Delete(_user);
            _inMemory.DeleteAll();

            Assert.AreEqual(true, true);
        }
    }
}