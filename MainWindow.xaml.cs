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

namespace Proiect_Iosib_Alexandra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource produseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("produseViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // produseViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource clientiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clientiViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource furnizoriViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("furnizoriViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // furnizoriViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource comenziClientiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("comenziClientiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // comenziClientiViewSource.Source = [generic data source]
        }
    }
}
