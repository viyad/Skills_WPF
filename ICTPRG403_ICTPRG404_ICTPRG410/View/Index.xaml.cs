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
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        /// <summary>
        /// Store for the _repo property, the connection string.
        /// </summary>
        private Repository _repo;
        public Index(Repository repo)
        {
            _repo = repo;
            InitializeComponent();

            //assign the collection of People objects return from the repository
            //as the data source for the DataGrid (dgPeople)
            dgPeople.ItemsSource = _repo.GetPeople();
        }

        /// <summary>
        /// Button_Click - an event handler for the button click, it gets activated when the button is clicked
        /// </summary>
        /// <param name="sender">The button itself</param>
        /// <param name="e">RoutedEventArgs</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //add the required logic for instantiating and navigating to a new instance of the Edit or Delete view.
            //Be sure to pass in the selected Person object and repository as arguments for the constructor.
            //TIP: the related Person instance can be accessed via the RoutedEventArgs 

            //edit or delete
            string action = (sender as Button).Content.ToString();

            Person person = (Person)dgPeople.SelectedItem;

            if (action == "Edit")
            {
                this.NavigationService.Navigate(new Update(_repo, person));
            }
            else if (action == "Delete")
            {
                this.NavigationService.Navigate(new Delete(_repo, person));
            }
        }    
    }
}
