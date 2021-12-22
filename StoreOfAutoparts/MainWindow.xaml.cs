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

            AutopartsLB.ItemsSource = db.Autopart.ToList();
            AutopartsLB.DisplayMemberPath = "PartNumber";
        }

        private void ProvidersLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProvider = ProvidersLB.SelectedItem as Provider;
            var consList = db.Consignment.Where(c => c.ProviderID == selectedProvider.ID).ToList();
            //ConsignmentDG.ItemsSource = consList;

            foreach(var i in consList)
            {
                i.Amount = i.CountOfUnits * i.PricePerUnit;
            }

            ConsignmentDG.ItemsSource = consList;
        }

        private void AutopartsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAutopart = AutopartsLB.SelectedItem as Autopart;
            var consList = db.Consignment.Where(c => c.AutopartID == selectedAutopart.ID).ToList();

            foreach (var i in consList)
            {
                i.Amount = i.CountOfUnits * i.PricePerUnit;
            }

            ConsignmentAP_DG.ItemsSource = consList;
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            var consList = db.Consignment.ToList();

            foreach (var i in consList)
            {
                i.Amount = i.CountOfUnits * i.PricePerUnit;
            }

            ConsignmentALL_DG.ItemsSource = consList;
        }
    }
}
