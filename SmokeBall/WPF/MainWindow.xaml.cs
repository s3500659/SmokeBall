using System.ComponentModel;
using System.Windows;

namespace WPF
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const int MIN_LIMIT = 1;
        private const int MAX_LIMIT = 100;
        private int _searchLimit = MAX_LIMIT;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int SearchLimit
        {
            get { return _searchLimit; }
            set
            {
                _searchLimit = value;
                OnPropertyChanged(nameof(SearchLimit));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            tbResults.Text = string.Empty;

            string keyword = tbKeywords.Text;
            string searchLimit = tbSearchLimit.Text;
            bool? isGoogle = rbGoogle.IsChecked;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                keyword = "Conveyancing Software";
            }

            if (!int.TryParse(searchLimit, out int limit))
            {
                return;
            }

            if (limit < MIN_LIMIT || limit > MAX_LIMIT)
            {
                return;
            }

            if (isGoogle == null)
            {
                isGoogle = true;
            }

            SearchInputModel searchInput = new SearchInputModel()
            {
                Keyword = keyword,
                SearchLimit = limit,
                Engine = isGoogle == true ? SearchEngine.Google : SearchEngine.Google
            };

            var results = await SearchEngineService.SearchAsync(searchInput);

            tbResults.Text = results;
        }
    }
}
