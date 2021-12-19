using StoreOfAutoparts.DataBase;
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

namespace StoreOfAutoparts
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static AutoPartsStoreEntities db = new AutoPartsStoreEntities();

        public MainWindow()
        {
            InitializeComponent();
            ProvidersLB.ItemsSource = db.Provider.ToList();
            ProvidersLB.DisplayMemberPath = "NameOfProvider";
        }

        private void ProvidersLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {         
                var selectedProvider = ProvidersLB.SelectedItem as Provider;
                ConsignmentDG.ItemsSource = db.Consignment.Where(c => c.ProviderID == selectedProvider.ID).ToList();
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"{ex}");
            }

        }
    }
}
