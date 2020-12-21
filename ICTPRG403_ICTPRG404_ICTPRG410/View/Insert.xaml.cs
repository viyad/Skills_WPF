using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICTPRG403_ICTPRG404_ICTPRG410.Data;

namespace ICTPRG403_ICTPRG404_ICTPRG410.View
{
    /// <summary>
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class Insert : Page
    {
        /// <summary>
        /// Store for the _repo property, the connection string.
        /// </summary>
        private Repository _repo;

        /// <summary>
        /// Insert method - to insert a person
        /// </summary>
        /// <param name="repo">The connection to the database</param>
        public Insert(Repository repo)
        {
            _repo = repo;
            InitializeComponent();
            //instantiate a new instance of a Person object and assign it 
            //to the View's DataContext property
            Person newPerson = new Person();
            DataContext = newPerson;
        }

        /// <summary>
        /// Button_Click - an event handler for the button click, it gets activated when the button is clicked
        /// </summary>
        /// <param name="sender">The button itself</param>
        /// <param name="e">RoutedEventArgs</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // i. Invoke the repository InsertPerson method passing in the Person object (from DataContext)
                _repo.InsertPerson((Person)DataContext);

                // ii. Instantiate a new Index view object and navigate to it using the NavigationService property
                this.NavigationService.Navigate(new Index(_repo));
            }
            catch (Exception exp)
            {    // iii. Ensure all logic is nested in a try/catch block incase an exception is raised whilst attempting to perform a data driven operation
                 // iiii. Add the logic required to display the message of any exception that might be raised using a MessageBox in the catch block
                MessageBox.Show(exp.Message);
            }
        }
    }
}
