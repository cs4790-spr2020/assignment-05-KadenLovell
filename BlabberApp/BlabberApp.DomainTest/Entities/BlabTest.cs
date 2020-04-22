using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities {
    [TestClass]
    public class BlabTest {
        private Blab harness;
        public BlabTest() {
            harness = new Blab();
        }
        [TestMethod]
        public void TestSetGetMessage() {
            // Arrange
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            harness.Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestChangeUser() {
            // Arrange
            var expected = new User {
                Id = Guid.NewGuid(),
            };
            harness.User.Id = expected.Id;
            // Act
            string actual = harness.User.Id.ToString();
            // Assert
            Assert.AreEqual(expected.Id, expected.Id);
        }

        [TestMethod]
        public void TestGetSetDateTime() {
            // Arrange
            var expected = DateTime.Now;
            harness.DTTM = expected;
            // Act
            DateTime actual = harness.DTTM;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestId() {
            // Arrange
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestDTTM() {
            // Arrange
            Blab Expected = new Blab();
            // Act
            Blab Actual = new Blab();
            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }
    }
}
