using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.DataStore.Exceptions;
using BlabberApp.Domain.Entities;
using System;
using System.Collections;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class UserAdapter_InMemory_UnitTests {
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
        public void TestAdd() {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            var actual = _harness.GetById(_user.Id);
            //Assert
            Assert.AreEqual(_user.Id, actual.Id);
        }

        [TestMethod]
        public void TestAddAndGetAll() {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            //Act
            var users = (ArrayList)_harness.GetAll();
            var actual = (User)users[0];
            //Assert
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
        }


        [TestMethod]
        public void TestUpdateUser() {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            _user.ChangeEmail("foobar@example.com");
            _user.ChangeEmail("newfoobar@example.com");
            var actual = _harness.GetById(_user.Id);
            //Assert
            Assert.AreEqual("newfoobar@example.com", actual.Email);
        }

        [TestMethod]
        public void TestGetByEmail() {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            var actual = _harness.GetByEmail(_user.Email);
            //Assert
            Assert.AreEqual(_user.Id, actual.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAdapterNotFoundException), "There is no row at position 0.")]
        public void TestRemoveUser() {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            _harness.RemoveAll();
            var actual = _harness.GetByEmail(_user.Email);
        }
    }
}
