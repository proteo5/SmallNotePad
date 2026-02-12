using System.Windows;

namespace SmallNotePad
{
    public partial class FindWindow : Window
    {
        public string SearchTerm { get; private set; }

        public FindWindow(string initialSearchTerm = "")
        {
            InitializeComponent();
            SearchTermTextBox.Text = initialSearchTerm;
            SearchTermTextBox.Focus();
            SearchTermTextBox.SelectAll();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTerm = SearchTermTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
