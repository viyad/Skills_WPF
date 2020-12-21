using ICTPRG403_ICTPRG404_ICTPRG410.Data;
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

namespace ICTPRG403_ICTPRG404_ICTPRG410.View
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Page
    {
        /// <summary>
        /// Store for the _repo property, the connection string.
        /// </summary>
        private Repository _repo;

        /// <summary>
        /// Update method - to delete a person
        /// </summary>
        /// <param name="repo">The connection to the database</param>
        /// <param name="p">A Person object, holds the person's data</param>
        public Update(Repository repo, Person p)
        {
            _repo = repo;
            InitializeComponent();
            //assign the Person instance passed in as a constructor argument
            //to the View's DataContext property
            DataContext = p;
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
                // i. Invoke the repository UpdatePerson method passing in the updated Person object (from DataContext)
                _repo.UpdatePerson((Person)DataContext);
                
                // ii. Instantiate a new Index view object and navigate to it using the NavigationService property
                this.NavigationService.Navigate(new Index(_repo));
            }
            catch (Exception exp)
            {   // iii. Ensure all logic is nested in a try/catch block incase an exception is raised whilst attempting to perform a data driven operation
                // iiii. Add the logic required to display the message of any exception that might be raised using a MessageBox in the catch block
                MessageBox.Show(exp.Message);
            }
        }
    }
}
