using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTPRG403_ICTPRG404_ICTPRG410.Data
{
    /// <summary>
    /// Class name - Person
    /// Person class holds a person data
    /// Written by: Viyada Tarapornsin
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Id property - get and set the value of the person's id
        /// </summary>
        /// <value>
        /// Integer
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// FirstName property - get and set the value of the person's first name
        /// </summary>
        /// <value>
        /// string
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName property - get and set the value of the person's last name
        /// </summary>
        /// <value>
        /// string
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Weight property - get and set the value of the person's weight
        /// </summary>
        /// <value>
        /// double
        /// </value>
        public double Weight { get; set; }

        /// <summary>
        /// Height property - get and set the value of the person's height
        /// </summary>
        /// <value>
        /// double
        /// </value>
        public double Height { get; set; }
    }
}
