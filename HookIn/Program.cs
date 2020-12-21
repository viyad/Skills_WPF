using ICTPRG403_ICTPRG404_ICTPRG410.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanitate a new instance of Repository (ensure the connection string field has been initialised in the constructor as instructed in Task 1)
            var repo = new Repository();

            // Reset database
            repo.ResetDatabase();

            // Get all existing people records from the database
            var people = repo.GetPeople();
            List<Person> peopleList = (List<Person>)people;
            Console.WriteLine("There are " + peopleList.Count.ToString() + " records in the people table.");

            // Insert a new row in the dbo.People database table
            var insert = new Person { FirstName = "John", LastName = "Grey", Height = 5.8, Weight = 71 };
            int rowsAffected = repo.InsertPerson(insert);
            Console.WriteLine("There is " + rowsAffected.ToString() + " row inserted.");
            
            // Update an existing record in the dbo.People database table
            var update = repo.GetPeople().First(p => p.Id == 1);
            update.FirstName = "Joseph";
            update.LastName = "Green";
            update.Height = 6.1;
            update.Weight = 79;
            rowsAffected = repo.UpdatePerson(update);
            Console.WriteLine("There is " + rowsAffected.ToString() + " row updated.");

            // Delete and existing record from the dbo.People database table
            var delete = repo.GetPeople().First(p => p.Id == 3);
            rowsAffected = repo.DeletePerson(delete);
            Console.WriteLine("There is " + rowsAffected.ToString() + " row deleted.");

            Console.ReadLine();
        }
    }
}
