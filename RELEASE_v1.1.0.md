# SmallNotePad v1.1.0 Release Notes

## 🎉 What's New

SmallNotePad v1.1.0 introduces dark mode support and improves file association handling, making your text editing experience more comfortable and convenient.

---

## ✨ New Features

### 🌙 Dark Mode
- **Toggle Dark Theme**: Switch between light and dark modes from `View → Dark Mode`
- **Eye-Friendly Colors**: Carefully selected dark background (#1E1E1E) with light text for comfortable reading in low-light environments
- **Persistent Preference**: Your dark mode choice is automatically saved and restored when you reopen the application
- **Simplified Design**: Menu stays in native Windows style while the editor adopts the dark theme

### 🖱️ File Association Fix
- **Double-Click Support**: Fixed the issue where double-clicking .txt files in Windows Explorer would open SmallNotePad but not load the file
- **Command-Line Arguments**: Application now properly handles file paths passed as command-line arguments
- **Seamless Integration**: Works perfectly with Windows file associations configured during installation

---

## 🔧 Improvements

- Enhanced application startup to handle command-line arguments
- Improved settings persistence with separate settings file
- Better theme application logic
- Cleaner codebase with simplified dark mode implementation

---

## 📦 Installation

### Using the Installer (Recommended)
1. Download `SmallNotePad-Setup.exe` from the [releases page](https://github.com/proteo5/SmallNotePad/releases/tag/v1.1.0)
2. Run the installer
3. Choose your preferred options:
   - Create desktop shortcut
   - Add context menu entry ("Open with SmallNotePad")
   - Set as default application for .txt files
4. Launch SmallNotePad from Start Menu or desktop

### Manual Installation
1. Download the .zip file from the releases page
2. Extract to your preferred location
3. Run `SmallNotePad.exe`

---

## 🐛 Bug Fixes

- **Fixed**: Files not loading when double-clicking .txt files in Windows Explorer
- **Fixed**: Command-line arguments not being processed correctly on application startup

---

## 💡 Usage Tips

### Dark Mode
1. Open SmallNotePad
2. Go to `View → Dark Mode` 
3. Click to toggle the checkbox
4. Your preference will be saved automatically for next time

### Opening Files
- **Method 1**: Use `File → Open` (Ctrl+O)
- **Method 2**: Double-click any .txt file in Windows Explorer (after installation)
- **Method 3**: Right-click a file and select "Open with SmallNotePad" (if context menu was enabled during installation)

---

## 📋 System Requirements

- **Operating System**: Windows 10 or later
- **.NET Runtime**: .NET 10.0
- **Architecture**: x64

---

## 🔗 Links

- **Download**: [v1.1.0 Release](https://github.com/proteo5/SmallNotePad/releases/tag/v1.1.0)
- **Source Code**: [GitHub Repository](https://github.com/proteo5/SmallNotePad)
- **Report Issues**: [Issue Tracker](https://github.com/proteo5/SmallNotePad/issues)
- **Documentation**: [README](https://github.com/proteo5/SmallNotePad#readme)

---

## 🙏 Acknowledgments

Thank you to everyone who provided feedback and suggestions for this release!

---

## 📝 Full Changelog

### Added
- Dark mode toggle in View menu
- Persistent dark mode preference using settings file
- Command-line argument handling for opening files
- `LoadFileFromCommandLine()` method in MainWindow
- `OnStartup()` override in App.xaml.cs

### Changed
- Updated version from 1.0.0 to 1.1.0 in project files
- Updated installer script to version 1.1.0
- Simplified dark mode implementation (menu stays native)

### Fixed
- Files not loading when opened via double-click in Windows Explorer
- Command-line arguments not being processed

---

**Enjoy SmallNotePad v1.1.0! 🎊**

If you find this useful, please ⭐ star the repository on GitHub!
