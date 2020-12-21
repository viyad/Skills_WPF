using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICTPRG403_ICTPRG404_ICTPRG410.Data;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private Repository _repo;

        [TestInitialize]
        public void Init()
        {
            _repo = new Repository();
            _repo.ResetDatabase();
        }

        [TestMethod]
        public void GetPeople()
        {
            //add logic to test (Assert.IsTrue) the number of people instances returned 
            //from the GetPeople() method is greater than zero
            List<Person> people = (List<Person>)_repo.GetPeople();
            Assert.IsTrue(people.Count > 0);
        }

        [TestMethod]
        public void InsertPerson()
        {
            //add the logic to test (Assert.AreEqual) the 
            //number of rows affected returned from the Repository InsertPerson method is equal to one (1)
            //Use the values provided below
            //FirstName: Sue, LastName: White, Height: 6.1, Weight: 65
            var insert = new Person { FirstName = "Sue", LastName = "White", Height = 6.1, Weight = 65 };
            Assert.AreEqual(_repo.InsertPerson(insert), 1);
        }

        [TestMethod]
        public void UpdatetPerson()
        {
            //add the logic to test (Assert.AreEqual) the number of rows affected 
            //returned from UpdatePerson is equal to one (1).
            //Update the Person record with an Id of 2, i.e. GetPeople().First(p=>p.Id == 2), and update with the values provided below
            //Id: 2, FirstName: Sally, LastName: Blue, Height: 5.3, Weight: 51
            var update = _repo.GetPeople().First(p => p.Id == 2);
            update.FirstName = "Sally";
            update.LastName = "Blue";
            update.Height = 5.3;
            update.Weight = 51;
            Assert.AreEqual(_repo.UpdatePerson(update), 1);
        }

        [TestMethod]
        public void DeletetPerson()
        {
            //add the logic to test (Assert.AreEqual) the number of rows affected returned 
            //from DeletePerson is equal to one (1).
            //Delete the Person record with an Id of 4 i.e. GetPeople().First(p=>p.Id == 4).
            var delete = _repo.GetPeople().First(p => p.Id == 4);
            Assert.AreEqual(_repo.DeletePerson(delete), 1);
        }
    }
}
