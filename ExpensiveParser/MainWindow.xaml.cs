using ExpensiveParser.Besplatka;
using ExpensiveParser.Parser;
using ExpensiveParser.Save;
using System.Collections.Generic;
using System.Windows;

namespace ExpensiveParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ParserWorker Worker = new ParserWorker();
        private List<BesplatkaDocumentModel> Model;
        public MainWindow()
        {
            InitializeComponent();
            Model = new List<BesplatkaDocumentModel>();
            Worker.OnComplete += OnComplete;
        }

        public void OnComplete(object obj)
        {
            MessageBox.Show("All works done!");
            StartBtn.IsEnabled = true;
            SaveExelBtn.Visibility = Visibility.Visible;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StartBtn.IsEnabled = false;
            Model = await Worker.Start();
        }

        private void Save_Exel(object sender, RoutedEventArgs e)
        {
            ISave save = new SaveExcel();
            save.Save(Model);
        }
    }
}
