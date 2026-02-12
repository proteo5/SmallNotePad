# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2024-12-19

### Added
- **File Operations**
  - Open files (Ctrl+O)
  - Save files (Ctrl+S)
  - Save As with new filename (Ctrl+Shift+S)
  - Close file without exiting app (Ctrl+W)
  - Recent Files menu - quick access to last 10 opened files
  - Clear Recent Files option

- **Edit Operations**
  - Undo (Ctrl+Z)
  - Cut (Ctrl+X)
  - Copy (Ctrl+C)
  - Paste (Ctrl+V)
  - Select All (Ctrl+A)

- **Search & Replace**
  - Find text (Ctrl+F) with case-insensitive matching
  - Find Next (F3)
  - Find Previous (Shift+F3)
  - Replace All (Ctrl+H)

- **View Options**
  - Word Wrap toggle (View menu)

- **User Interface**
  - Clean, minimalist design
  - Title bar shows filename and unsaved changes indicator (*)
  - Professional About dialog
  - Comprehensive Help dialog with all shortcuts documented
  - Keyboard shortcuts displayed in menu items

- **User Experience**
  - Unsaved changes warning before closing
  - Recent files list persistence
  - Support for tabs and line breaks in documents
  - Consolas 12pt font for comfortable reading

- **Installation**
  - Inno Setup installer script
  - Optional desktop shortcut during installation
  - Optional Start menu integration
  - Optional context menu integration ("Open with SmallNotePad")
  - Optional default handler for .txt files

- **Documentation**
  - Comprehensive README.md in English
  - Full README.es.md in Spanish
  - Language selection link in main README
  - Help Topics accessible via F1
  - About dialog with version and license info

### Technical Details
- Built with C# 14.0
- .NET 10 target framework
- WPF (Windows Presentation Foundation) UI framework
- Self-contained Windows 64-bit publication
- MIT License

### Fixed
- Correct counter display for Replace All operations
- File existence validation for recent files

### Notes
- First stable release
- Tested on Windows 10/11 with .NET 10
- All core Notepad features implemented and working
- Ready for production use
