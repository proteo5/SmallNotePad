using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace SmallNotePad
{
    public partial class MainWindow : Window
    {
        private string _currentFilePath = null;
        private bool _isModified = false;
        private const int MaxRecentFiles = 10;
        private List<string> _recentFiles;
        private string _recentFilesPath;
        private bool _isDarkMode = false;
        private string _settingsPath;

        public MainWindow()
        {
            InitializeComponent();
            _recentFilesPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "recentfiles.txt");
            _settingsPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "settings.txt");
            LoadRecentFiles();
            UpdateRecentFilesMenu();
            LoadDarkModePreference();
        }

        private void LoadDarkModePreference()
        {
            try
            {
                if (File.Exists(_settingsPath))
                {
                    var lines = File.ReadAllLines(_settingsPath);
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("DarkMode="))
                        {
                            _isDarkMode = bool.Parse(line.Split('=')[1]);
                            MenuViewDarkMode.IsChecked = _isDarkMode;
                            ApplyTheme();
                            break;
                        }
                    }
                }
            }
            catch
            {
                _isDarkMode = false;
                MenuViewDarkMode.IsChecked = false;
            }
        }

        private void SaveDarkModePreference()
        {
            try
            {
                File.WriteAllText(_settingsPath, $"DarkMode={_isDarkMode}");
            }
            catch { }
        }

        // Public method to load a file from command line arguments
        public void LoadFileFromCommandLine(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return;

            try
            {
                _currentFilePath = filePath;
                TextEditor.Text = File.ReadAllText(filePath);
                _isModified = false;
                UpdateTitle();
                AddRecentFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTitle()
        {
            string title = string.IsNullOrEmpty(_currentFilePath) ? "Untitled" : Path.GetFileName(_currentFilePath);
            Title = _isModified ? $"*{title} - Notepad" : $"{title} - Notepad";
        }

        private void TextEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isModified = true;
            UpdateTitle();
        }

        // Recent Files Management
        private void LoadRecentFiles()
        {
            _recentFiles = new List<string>();
            try
            {
                if (File.Exists(_recentFilesPath))
                {
                    var lines = File.ReadAllLines(_recentFilesPath);
                    _recentFiles = lines.Where(f => File.Exists(f)).ToList();
                }
            }
            catch
            {
                _recentFiles = new List<string>();
            }
        }

        private void SaveRecentFiles()
        {
            try
            {
                File.WriteAllLines(_recentFilesPath, _recentFiles);
            }
            catch { }
        }

        private void AddRecentFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return;

            _recentFiles.Remove(filePath);
            _recentFiles.Insert(0, filePath);

            if (_recentFiles.Count > MaxRecentFiles)
                _recentFiles = _recentFiles.Take(MaxRecentFiles).ToList();

            SaveRecentFiles();
            UpdateRecentFilesMenu();
        }

        private void UpdateRecentFilesMenu()
        {
            RecentFilesMenu.Items.Clear();

            if (_recentFiles.Count == 0)
            {
                var emptyItem = new MenuItem { Header = "(No recent files)", IsEnabled = false };
                RecentFilesMenu.Items.Add(emptyItem);
                return;
            }

            int counter = 1;
            foreach (var file in _recentFiles)
            {
                var menuItem = new MenuItem { Header = $"_{counter} {Path.GetFileName(file)}" };
                menuItem.Click += (s, e) => OpenRecentFile(file);
                menuItem.ToolTip = file;
                RecentFilesMenu.Items.Add(menuItem);
                counter++;
            }

            RecentFilesMenu.Items.Add(new Separator());
            var clearItem = new MenuItem { Header = "_Clear Recent Files" };
            clearItem.Click += (s, e) => ClearRecentFiles();
            RecentFilesMenu.Items.Add(clearItem);
        }

        private void OpenRecentFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"File not found: {filePath}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _recentFiles.Remove(filePath);
                SaveRecentFiles();
                UpdateRecentFilesMenu();
                return;
            }

            if (_isModified && !ConfirmDiscardChanges())
                return;

            try
            {
                _currentFilePath = filePath;
                TextEditor.Text = File.ReadAllText(filePath);
                _isModified = false;
                UpdateTitle();
                AddRecentFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearRecentFiles()
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to clear the recent files list?",
                "Clear Recent Files",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _recentFiles.Clear();
                SaveRecentFiles();
                UpdateRecentFilesMenu();
            }
        }

        // File Menu Commands
        private void MenuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            if (_isModified && !ConfirmDiscardChanges())
                return;

            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = ".txt"
            };

            if (openDialog.ShowDialog() == true)
            {
                try
                {
                    _currentFilePath = openDialog.FileName;
                    TextEditor.Text = File.ReadAllText(_currentFilePath);
                    _isModified = false;
                    UpdateTitle();
                    AddRecentFile(_currentFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                MenuFileSaveAs_Click(sender, e);
            }
            else
            {
                SaveFile(_currentFilePath);
            }
        }

        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = ".txt"
            };

            if (saveDialog.ShowDialog() == true)
            {
                _currentFilePath = saveDialog.FileName;
                SaveFile(_currentFilePath);
            }
        }

        private void MenuFileClose_Click(object sender, RoutedEventArgs e)
        {
            if (_isModified && !ConfirmDiscardChanges())
                return;

            TextEditor.Clear();
            _currentFilePath = null;
            _isModified = false;
            UpdateTitle();
        }

        private void SaveFile(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, TextEditor.Text);
                _isModified = false;
                UpdateTitle();
                AddRecentFile(filePath);
                MessageBox.Show("File saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Edit Menu Commands
        private void MenuEditUndo_Click(object sender, RoutedEventArgs e)
        {
            if (TextEditor.CanUndo)
                TextEditor.Undo();
        }

        private void MenuEditCut_Click(object sender, RoutedEventArgs e)
        {
            TextEditor.Cut();
        }

        private void MenuEditCopy_Click(object sender, RoutedEventArgs e)
        {
            TextEditor.Copy();
        }

        private void MenuEditPaste_Click(object sender, RoutedEventArgs e)
        {
            TextEditor.Paste();
        }

        private void MenuEditFind_Click(object sender, RoutedEventArgs e)
        {
            ShowFindDialog();
        }

        private void MenuEditFindNext_Click(object sender, RoutedEventArgs e)
        {
            FindNext();
        }

        private void MenuEditFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            FindPrevious();
        }

        private void MenuEditReplace_Click(object sender, RoutedEventArgs e)
        {
            ShowReplaceDialog();
        }

        private void MenuEditSelectAll_Click(object sender, RoutedEventArgs e)
        {
            TextEditor.SelectAll();
        }

        // View Menu Commands
        private void MenuViewWordWrap_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            TextEditor.TextWrapping = menuItem.IsChecked ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        private void MenuViewDarkMode_Click(object sender, RoutedEventArgs e)
        {
            _isDarkMode = MenuViewDarkMode.IsChecked;
            ApplyTheme();
            SaveDarkModePreference();
        }

        private void ApplyTheme()
        {
            if (_isDarkMode)
            {
                // Dark Mode Colors - Only for Window and TextEditor
                MainWindowElement.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 30, 30));
                MainDockPanel.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 30, 30));
                TextEditor.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 30, 30));
                TextEditor.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                TextEditor.CaretBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
            }
            else
            {
                // Light Mode Colors (Default) - Only for Window and TextEditor
                MainWindowElement.Background = System.Windows.Media.Brushes.White;
                MainDockPanel.Background = System.Windows.Media.Brushes.White;
                TextEditor.Background = System.Windows.Media.Brushes.White;
                TextEditor.Foreground = System.Windows.Media.Brushes.Black;
                TextEditor.CaretBrush = System.Windows.Media.Brushes.Black;
            }
        }

        // Find/Replace Dialog
        private string _lastSearchTerm = "";

        private void ShowFindDialog()
        {
            FindWindow findWindow = new FindWindow(_lastSearchTerm);
            if (findWindow.ShowDialog() == true)
            {
                _lastSearchTerm = findWindow.SearchTerm;
                FindFirst();
            }
        }

        private void ShowReplaceDialog()
        {
            ReplaceWindow replaceWindow = new ReplaceWindow(_lastSearchTerm);
            if (replaceWindow.ShowDialog() == true)
            {
                _lastSearchTerm = replaceWindow.SearchTerm;
                ReplaceAll(replaceWindow.SearchTerm, replaceWindow.ReplaceTerm);
            }
        }

        private void FindFirst()
        {
            if (string.IsNullOrEmpty(_lastSearchTerm))
                return;

            int index = TextEditor.Text.IndexOf(_lastSearchTerm, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                TextEditor.Select(index, _lastSearchTerm.Length);
                TextEditor.Focus();
            }
            else
            {
                MessageBox.Show($"Text not found: {_lastSearchTerm}", "Find", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void FindNext()
        {
            if (string.IsNullOrEmpty(_lastSearchTerm))
            {
                ShowFindDialog();
                return;
            }

            int startIndex = TextEditor.SelectionStart + TextEditor.SelectionLength;
            int index = TextEditor.Text.IndexOf(_lastSearchTerm, startIndex, StringComparison.OrdinalIgnoreCase);

            if (index < 0)
            {
                index = TextEditor.Text.IndexOf(_lastSearchTerm, 0, StringComparison.OrdinalIgnoreCase);
            }

            if (index >= 0)
            {
                TextEditor.Select(index, _lastSearchTerm.Length);
                TextEditor.Focus();
            }
            else
            {
                MessageBox.Show($"Text not found: {_lastSearchTerm}", "Find Next", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void FindPrevious()
        {
            if (string.IsNullOrEmpty(_lastSearchTerm))
            {
                ShowFindDialog();
                return;
            }

            int startIndex = TextEditor.SelectionStart - 1;
            if (startIndex < 0)
                startIndex = TextEditor.Text.Length - 1;

            int index = TextEditor.Text.LastIndexOf(_lastSearchTerm, startIndex, StringComparison.OrdinalIgnoreCase);

            if (index < 0)
            {
                index = TextEditor.Text.LastIndexOf(_lastSearchTerm, TextEditor.Text.Length - 1, StringComparison.OrdinalIgnoreCase);
            }

            if (index >= 0)
            {
                TextEditor.Select(index, _lastSearchTerm.Length);
                TextEditor.Focus();
            }
            else
            {
                MessageBox.Show($"Text not found: {_lastSearchTerm}", "Find Previous", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ReplaceAll(string searchTerm, string replaceTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return;

            int count = 0;
            int index = 0;
            while ((index = TextEditor.Text.IndexOf(searchTerm, index, StringComparison.OrdinalIgnoreCase)) >= 0)
            {
                count++;
                index += searchTerm.Length;
            }

            string newText = TextEditor.Text.Replace(searchTerm, replaceTerm);
            TextEditor.Text = newText;
            MessageBox.Show($"{count} occurrence(s) replaced.", "Replace", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Window Closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isModified && !ConfirmDiscardChanges())
            {
                e.Cancel = true;
            }
        }

        private bool ConfirmDiscardChanges()
        {
            MessageBoxResult result = MessageBox.Show(
                "You have unsaved changes. Do you want to save before closing?",
                "Unsaved Changes",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MenuFileSave_Click(null, null);
                return true;
            }

            return result == MessageBoxResult.No;
        }

        // Help Menu Commands
        private void MenuHelpTopics_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void MenuHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
    }
}