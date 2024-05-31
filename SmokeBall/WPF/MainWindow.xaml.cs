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

namespace WPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string keywords = tbKeywords.Text;
            string searchLimit = tbSearchLimit.Text;
            bool? isGoogle = rbGoogle.IsChecked;

            if (string.IsNullOrWhiteSpace(keywords))
            {
                keywords = "Conveyancing Software";
            }

            if (string.IsNullOrWhiteSpace(searchLimit))
            {
                searchLimit = "100";
            }

            if (isGoogle == null)
            {
                isGoogle = true;
            }


            string results = SearchEngineService.Search(keywords, searchLimit, SearchEngine.Google);

        }
    }
}
