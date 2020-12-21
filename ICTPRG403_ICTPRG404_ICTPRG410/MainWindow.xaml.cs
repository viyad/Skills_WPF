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
using System.Windows.Shapes;
using ICTPRG403_ICTPRG404_ICTPRG410.Data;
using ICTPRG403_ICTPRG404_ICTPRG410.View;

namespace ICTPRG403_ICTPRG404_ICTPRG410
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Store for the _repo property, the connection string.
        /// </summary>
        private Repository _repo;

        /// <summary>
        /// MainWindow method - the starting point of the program
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _repo = new Repository(); 
            frame.Navigate(new Index(_repo));
        }

        /// <summary>
        /// Button_Click - an event handler for the button click, it gets activated when the button is clicked
        /// </summary>
        /// <param name="sender">The button itself</param>
        /// <param name="e">RoutedEventArgs</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Insert(_repo));
        }
    }
}
