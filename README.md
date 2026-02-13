# SmallNotePad

**📚 [Leer en Español](README.es.md) | Read in Spanish**

A lightweight, feature-rich text editor built with WPF and .NET 10. SmallNotePad is a modern take on the classic Windows Notepad with essential editing features, dark mode support, and a clean, intuitive interface.

---

## 🚀 Quick Download

**[⬇️ Download SmallNotePad v1.1.0](https://github.com/proteo5/SmallNotePad/releases/tag/v1.1.0)**

> Download the installer from our latest release and start using SmallNotePad today!

---

## ✨ Features

- 📝 **Simple Text Editing** - Clean and minimal interface for distraction-free writing
- 📂 **File Management** - Open, Save, and Save As functionality for .txt files
- 📋 **Recent Files** - Quick access to last 10 opened files
- ✏️ **Edit Operations** - Undo, Cut, Copy, Paste, and Select All
- 🔍 **Find & Replace** - Powerful search with Find, Find Next, Find Previous, and Replace All
- 📄 **Word Wrap** - Toggle word wrapping on/off via the View menu
- 🌙 **Dark Mode** - Eye-friendly dark theme for low-light environments with persistent preference
- 🖱️ **File Association** - Open .txt files directly by double-clicking them in Windows Explorer
- ⌨️ **Keyboard Shortcuts** - Standard Windows shortcuts for common operations
- 💾 **Unsaved Changes Detection** - Asterisk (*) in title bar indicates unsaved changes
- 🚨 **Smart Exit** - Prompts to save changes before closing

## ⌨️ Keyboard Shortcuts

| Shortcut | Action |
|----------|--------|
| `Ctrl+O` | Open file |
| `Ctrl+S` | Save file |
| `Ctrl+Shift+S` | Save As |
| `Ctrl+W` | Close file |
| `Ctrl+Z` | Undo |
| `Ctrl+X` | Cut |
| `Ctrl+C` | Copy |
| `Ctrl+V` | Paste |
| `Ctrl+F` | Find |
| `Ctrl+H` | Replace |
| `F3` | Find Next |
| `Shift+F3` | Find Previous |
| `Ctrl+A` | Select All |
| `Alt+F4` | Exit |

## 📋 Requirements

- .NET 10
- Windows (WPF framework)
- Visual Studio 2022 or later (for development)

## 🚀 Installation

### From Source

1. Clone the repository:
    ```bash
    git clone https://github.com/proteo5/SmallNotePad.git
    cd SmallNotePad
    ```

2. Open the solution in Visual Studio:
    ```bash
    start SmallNotePad.sln
    ```

3. Build and run:
   - Press `F5` or click the Run button in Visual Studio

## 💻 Usage

1. **Open a file**: Use `File → Open` (Ctrl+O) to open a .txt file
2. **Edit text**: Type or paste your content
3. **Save changes**: Use `File → Save` (Ctrl+S)
4. **Find text**: Use `Edit → Find` (Ctrl+F) to search
5. **Replace text**: Use `Edit → Replace` (Ctrl+H) to find and replace
6. **Toggle word wrap**: Use `View → Word Wrap` to enable/disable text wrapping
7. **Switch to dark mode**: Use `View → Dark Mode` to enable/disable dark theme
8. **Open files from Explorer**: Double-click .txt files in Windows Explorer to open in SmallNotePad

## 📁 Project Structure

```
SmallNotePad/
├── App.xaml                 # Application configuration
├── App.xaml.cs             # Application code-behind
├── MainWindow.xaml         # Main window UI
├── MainWindow.xaml.cs      # Main window logic
├── FindWindow.xaml         # Find dialog UI
├── FindWindow.xaml.cs      # Find dialog logic
├── ReplaceWindow.xaml      # Replace dialog UI
└── ReplaceWindow.xaml.cs   # Replace dialog logic
```

## 🛠️ Technology Stack

- **Language**: C# 14.0
- **Framework**: .NET 10
- **UI Framework**: WPF (Windows Presentation Foundation)
- **IDE**: Visual Studio 2022

## 📖 Features in Detail

### File Operations
- **Open**: Browse and open any .txt file
- **Save**: Save current file with confirmation if unsaved changes exist
- **Save As**: Save with a new filename or location
- **Close**: Close current file and return to blank document
- **Recent Files**: Access last 10 opened files from File → Recent Files menu. You can also clear the recent files list.
- **File Association**: Open .txt files directly by double-clicking them in Windows Explorer (requires installer setup)

### Editing Features
- **Undo**: Revert last action
- **Cut/Copy/Paste**: Standard clipboard operations
- **Select All**: Select all text (Ctrl+A)

### Search & Replace
- **Find**: Search text with case-insensitive matching
- **Find Next**: Navigate to next occurrence (F3)
- **Find Previous**: Navigate to previous occurrence (Shift+F3)
- **Replace All**: Replace all occurrences of search term

### View Options
- **Word Wrap**: Toggle text wrapping for better readability
- **Dark Mode**: Switch between light and dark themes. Your preference is automatically saved and restored on next launch

### User Experience
- **Title Bar Updates**: Shows filename and unsaved changes indicator (*)
- **Unsaved Changes Warning**: Prompts to save before closing
- **Standard Fonts**: Uses Consolas 12pt for comfortable reading
- **Persistent Preferences**: Dark mode setting is remembered between sessions

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👤 Author

Created by [proteo5](https://github.com/proteo5)

## 🙏 Acknowledgments

- Inspired by the classic Windows Notepad
- Built with WPF for a modern Windows experience
- **App Icon**: [Notepad icons](https://www.flaticon.com/free-icons/notepad) created by [logisstudio](https://www.flaticon.com/authors/logisstudio) - [Flaticon](https://www.flaticon.com)
- **Installer**: Built with [Inno Setup](https://jrsoftware.org/isinfo.php) by Jordan Russell and Martijn Laan

---

**Star ⭐ this repository if you find it useful!**