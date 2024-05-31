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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string keyword = tbKeywords.Text;
            string searchLimit = tbSearchLimit.Text;
            bool? isGoogle = rbGoogle.IsChecked;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                keyword = "Conveyancing Software";
            }

            if (string.IsNullOrWhiteSpace(searchLimit))
            {
                searchLimit = "100";
            }

            if (isGoogle == null)
            {
                isGoogle = true;
            }

            SearchInputModel searchInput = new SearchInputModel()
            {
                Keyword = keyword,
                SearchLimit = searchLimit,
                Engine = isGoogle == true ? SearchEngine.Google : SearchEngine.Google
            };

            var results = await SearchEngineService.SearchAsync(searchInput);

            tbResults.Text = results;

        }
    }
}
