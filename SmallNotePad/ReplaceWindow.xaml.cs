using System.Windows;

namespace SmallNotePad
{
    public partial class ReplaceWindow : Window
    {
        public string SearchTerm { get; private set; }
        public string ReplaceTerm { get; private set; }

        public ReplaceWindow(string initialSearchTerm = "")
        {
            InitializeComponent();
            SearchTermTextBox.Text = initialSearchTerm;
            SearchTermTextBox.Focus();
            SearchTermTextBox.SelectAll();
        }

        private void ReplaceAllButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTerm = SearchTermTextBox.Text;
            ReplaceTerm = ReplaceTermTextBox.Text;
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
