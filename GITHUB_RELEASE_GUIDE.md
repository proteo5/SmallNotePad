# GitHub Release Instructions

## Para crear un Release en GitHub con SmallNotePad v1.0.0

### Paso 1: Preparar el instalador

1. En Visual Studio, abre Inno Setup Compiler
2. Abre el archivo `SmallNotePad/SmallNotePad.iss`
3. Presiona `Ctrl+F9` o click en "Compile"
4. Espera a que se complete la compilación
5. El archivo `SmallNotePad-Setup.exe` se generará en `SmallNotePad/Installers/`

### Paso 2: Crear el Release en GitHub

1. Ve a https://github.com/proteo5/SmallNotePad/releases
2. Click en "Create a new release" o "Draft a new release"
3. Completa los siguientes campos:

#### Tag version
```
v1.0.0
```

#### Release title
```
SmallNotePad v1.0.0 - First Stable Release
```

#### Description
Copia y pega el contenido de `RELEASE_NOTES.md` o usa este texto:

```markdown
🎉 **SmallNotePad v1.0.0 - First Stable Release**

We're excited to announce the first stable release of SmallNotePad, a lightweight yet feature-rich text editor built with .NET 10 and WPF.

## ✨ Features

- 📝 Simple text editing with clean interface
- 📂 File operations (Open, Save, Save As, Close)
- 📋 Recent Files menu - access last 10 files
- 🔍 Find & Replace functionality
- ✏️ Edit operations (Undo, Cut, Copy, Paste, Select All)
- 📄 Word Wrap toggle
- 💾 Unsaved changes detection
- 🚨 Smart exit with save prompts
- 📚 Bilingual Help (English/Spanish)
- 🎯 Professional installer

## 🚀 Installation

Download `SmallNotePad-Setup.exe` below and run the installer.

**System Requirements:**
- Windows 10 or later
- .NET 10 Runtime (included in installer)

## 📖 Documentation

- [README.md](https://github.com/proteo5/SmallNotePad/blob/main/README.md) - Full documentation
- [README.es.md](https://github.com/proteo5/SmallNotePad/blob/main/README.es.md) - Spanish version
- [CHANGELOG.md](https://github.com/proteo5/SmallNotePad/blob/main/CHANGELOG.md) - Complete changelog

## 🔄 What's New

This is the inaugural release featuring:
- Complete text editing suite
- Modern WPF interface
- Smart file management
- Comprehensive documentation
- Professional installer
- Bilingual support

## 📊 Technical Details

- **Language:** C# 14.0
- **Framework:** .NET 10
- **UI:** WPF (Windows Presentation Foundation)
- **License:** MIT
- **Platform:** Windows 64-bit (self-contained)

## 🙏 Credits

- **Icon:** Notepad icons by logisstudio (Flaticon)
- **Installer:** Inno Setup by Jordan Russell and Martijn Laan

## 📞 Support

Found a bug? Have a suggestion? Visit the [Issues page](https://github.com/proteo5/SmallNotePad/issues).

Thank you for using SmallNotePad! ⭐ Please consider giving us a star if you like this project.
```

### Paso 3: Subir archivos (Assets)

1. En la sección "Attach binaries by dropping them here or selecting them"
2. Click en el área o arrastra estos archivos:
   - `SmallNotePad/Installers/SmallNotePad-Setup.exe` ⭐ (Principal)
   - `SmallNotePad/SmallNotePad.iss` (Script del instalador)

### Paso 4: Opciones finales

- ✅ **"Set as the latest release"** - Dejar marcado
- ⚪ **"This is a pre-release"** - Dejar desmarcado (es una versión estable)

### Paso 5: Publicar

1. Click en **"Publish release"**
2. ¡Listo! Tu release está publicado en GitHub

---

## Comandos Git para crear el tag

Si prefieres usar la línea de comandos:

```bash
# Crear el tag local
git tag -a v1.0.0 -m "SmallNotePad v1.0.0 - First Stable Release"

# Hacer push del tag a GitHub
git push origin v1.0.0

# O hacer push de todos los tags
git push origin --tags
```

---

## Después del Release

### Comunicar el lanzamiento

1. 📱 Comparte en redes sociales
2. 💬 Publica en comunidades de desarrolladores (Reddit, Dev.to, etc.)
3. 📧 Notifica a tu red profesional
4. ⭐ Pide a usuarios que den una estrella al repositorio

### Monitorear

- 👀 Observa los Issues para bugs reportados
- 💬 Responde comentarios y sugerencias
- 📊 Sigue las estadísticas de descargas

### Próximas versiones

- 📋 Etiqueta como `milestone` en GitHub Projects
- 🐛 Crea issues para nuevas features
- 🗺️ Actualiza el roadmap en el README

---

## Template para Release Notes futuras

Para versiones futuras, usa esta estructura:

```markdown
# v[VERSION] - [TITLE]

**Release Date:** [DATE]
**Status:** [Stable/Beta/Alpha]

## 🎉 [Feature Name]
- Feature 1
- Feature 2

## 🐛 Bug Fixes
- Fix 1
- Fix 2

## 📋 Known Issues
- Issue 1

## 🙏 Credits
- Contributors

**Download:** [Installers below]
```

---

**¡Felicidades por tu primer release! 🎊**
