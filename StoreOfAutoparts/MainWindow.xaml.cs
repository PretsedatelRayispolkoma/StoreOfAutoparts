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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace StoreOfAutoparts
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var autoparts = db.Autopart.ToList();

            var application = new Excel.Application();

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            Excel.Worksheet worksheet = application.Worksheets.Item[1];

            worksheet.Name = "Запчасти";

            worksheet.Cells[1][1] = "Номер запчасти";
            worksheet.Cells[2][1] = "Производитель";
            worksheet.Cells[3][1] = "Страна-производитель";
            worksheet.Cells[4][1] = "Категория";

            int rowCount = 2;
            for(int i = 0; i < autoparts.Count(); ++i)
            {
                worksheet.Cells[1][rowCount] = autoparts[i].PartNumber;
                worksheet.Cells[2][rowCount] = autoparts[i].ManufacturerID;
                worksheet.Cells[3][rowCount] = autoparts[i].ProducingCountryID;
                worksheet.Cells[4][rowCount] = autoparts[i].CategoryID;

                rowCount++;
            }


            application.Visible = true;
        }

        private void WordExportBtn_Click(object sender, RoutedEventArgs e)
        {
            var autoparts = db.Autopart.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph paragraph = document.Paragraphs.Add();

            Word.Range tableRange = paragraph.Range;

            Word.Table table = document.Tables.Add(tableRange, autoparts.Count()+1, 4);

            Word.Range cellRange;

            cellRange = table.Cell(1, 1).Range;
            cellRange.Text = "Номер запчасти";
            cellRange = table.Cell(1, 2).Range;
            cellRange.Text = "Производитель";
            cellRange = table.Cell(1, 3).Range;
            cellRange.Text = "Страна-производитель";
            cellRange = table.Cell(1, 4).Range;
            cellRange.Text = "Категория";


        }
    }
}
