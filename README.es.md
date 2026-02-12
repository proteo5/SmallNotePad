# SmallNotePad

Un editor de texto ligero y rico en funcionalidades construido con WPF y .NET 10. SmallNotePad es una versión moderna del clásico Bloc de notas de Windows con características de edición esenciales e interfaz limpia e intuitiva.

---

## 🚀 Descarga Rápida

**[⬇️ Descargar SmallNotePad v1.0.0](https://github.com/proteo5/SmallNotePad/releases/tag/v1.0.0)**

> ¡Descarga el instalador de nuestro último release y comienza a usar SmallNotePad hoy!

---

## ✨ Características

- 📝 **Edición de texto simple** - Interfaz limpia y minimalista para escribir sin distracciones
- 📂 **Gestión de archivos** - Funcionalidad Abrir, Guardar y Guardar como para archivos .txt
- 📋 **Archivos recientes** - Acceso rápido a los últimos 10 archivos abiertos
- ✏️ **Operaciones de edición** - Deshacer, Cortar, Copiar, Pegar y Seleccionar todo
- 🔍 **Buscar y reemplazar** - Búsqueda potente con Buscar, Buscar siguiente, Buscar anterior y Reemplazar todo
- 📄 **Ajuste de línea** - Activar/desactivar el ajuste de línea desde el menú Ver
- ⌨️ **Atajos de teclado** - Atajos estándar de Windows para operaciones comunes
- 💾 **Detección de cambios sin guardar** - Un asterisco (*) en la barra de título indica cambios sin guardar
- 🚨 **Salida inteligente** - Solicita guardar cambios antes de cerrar la aplicación

## ⌨️ Atajos de teclado

| Atajo | Acción |
|-------|--------|
| `Ctrl+O` | Abrir archivo |
| `Ctrl+S` | Guardar archivo |
| `Ctrl+Shift+S` | Guardar como |
| `Ctrl+W` | Cerrar archivo |
| `Ctrl+Z` | Deshacer |
| `Ctrl+X` | Cortar |
| `Ctrl+C` | Copiar |
| `Ctrl+V` | Pegar |
| `Ctrl+F` | Buscar |
| `Ctrl+H` | Reemplazar |
| `F3` | Buscar siguiente |
| `Shift+F3` | Buscar anterior |
| `Ctrl+A` | Seleccionar todo |
| `Alt+F4` | Salir |

## 📋 Requisitos

- .NET 10
- Windows (framework WPF)
- Visual Studio 2022 o posterior (para desarrollo)

## 🚀 Instalación

### Desde la fuente

1. Clona el repositorio:
```bash
git clone https://github.com/proteo5/SmallNotePad.git
cd SmallNotePad
```

2. Abre la solución en Visual Studio:
```bash
start SmallNotePad.sln
```

3. Compila y ejecuta:
   - Presiona `F5` o haz clic en el botón Ejecutar en Visual Studio

## 💻 Uso

1. **Abrir un archivo**: Usa `Archivo → Abrir` (Ctrl+O) para abrir un archivo .txt
2. **Editar texto**: Escribe o pega tu contenido
3. **Guardar cambios**: Usa `Archivo → Guardar` (Ctrl+S)
4. **Buscar texto**: Usa `Editar → Buscar` (Ctrl+F) para buscar
5. **Reemplazar texto**: Usa `Editar → Reemplazar` (Ctrl+H) para buscar y reemplazar
6. **Activar ajuste de línea**: Usa `Ver → Ajuste de línea` para activar/desactivar el ajuste de texto

## 📁 Estructura del proyecto

```
SmallNotePad/
├── App.xaml                 # Configuración de la aplicación
├── App.xaml.cs             # Código base de la aplicación
├── MainWindow.xaml         # UI de la ventana principal
├── MainWindow.xaml.cs      # Lógica de la ventana principal
├── FindWindow.xaml         # UI del diálogo Buscar
├── FindWindow.xaml.cs      # Lógica del diálogo Buscar
├── ReplaceWindow.xaml      # UI del diálogo Reemplazar
├── ReplaceWindow.xaml.cs   # Lógica del diálogo Reemplazar
├── AboutWindow.xaml        # UI del diálogo Acerca de
├── AboutWindow.xaml.cs     # Lógica del diálogo Acerca de
├── HelpWindow.xaml         # UI del diálogo Ayuda
└── HelpWindow.xaml.cs      # Lógica del diálogo Ayuda
```

## 🛠️ Stack tecnológico

- **Lenguaje**: C# 14.0
- **Framework**: .NET 10
- **UI Framework**: WPF (Windows Presentation Foundation)
- **IDE**: Visual Studio 2022

## 📖 Características en detalle

### Operaciones de archivo
- **Abrir**: Examina y abre cualquier archivo .txt
- **Guardar**: Guarda el archivo actual con confirmación si hay cambios sin guardar
- **Guardar como**: Guarda con un nuevo nombre o ubicación
- **Cerrar**: Cierra el archivo actual y vuelve a un documento en blanco
- **Archivos recientes**: Accede a los últimos 10 archivos abiertos desde el menú Archivo → Archivos recientes. También puedes limpiar la lista de archivos recientes.

### Características de edición
- **Deshacer**: Revierte la última acción
- **Cortar/Copiar/Pegar**: Operaciones estándar del portapapeles
- **Seleccionar todo**: Selecciona todo el texto del documento (Ctrl+A)

### Búsqueda y reemplazo
- **Buscar**: Busca texto con coincidencia insensible a mayúsculas/minúsculas
- **Buscar siguiente**: Ve a la siguiente aparición (F3)
- **Buscar anterior**: Ve a la aparición anterior (Shift+F3)
- **Reemplazar**: Abre el diálogo Reemplazar. Introduce el texto a buscar y el texto de reemplazo, luego haz clic en 'Reemplazar todo'

### Experiencia del usuario
- **Actualización de la barra de título**: Muestra el nombre del archivo e indicador de cambios sin guardar (*)
- **Advertencia de cambios sin guardar**: Solicita guardar antes de cerrar
- **Fuentes estándar**: Usa Consolas 12pt para una lectura cómoda

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Siéntete libre de enviar un Pull Request.

1. Haz un fork del repositorio
2. Crea una rama para tu función (`git checkout -b feature/MiCaracteristica`)
3. Realiza commit de tus cambios (`git commit -m 'Agregar MiCaracteristica'`)
4. Envía push a la rama (`git push origin feature/MiCaracteristica`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está licenciado bajo la Licencia MIT - consulta el archivo LICENSE para más detalles.

## 👤 Autor

Creado por [proteo5](https://github.com/proteo5)

## 🙏 Reconocimientos

- Inspirado en el clásico Bloc de notas de Windows
- Construido con WPF para una experiencia moderna en Windows
- **Icono de la aplicación**: [Iconos de bloc de notas](https://www.flaticon.com/free-icons/notepad) creados por [logisstudio](https://www.flaticon.com/authors/logisstudio) - [Flaticon](https://www.flaticon.com)
- **Instalador**: Construido con [Inno Setup](https://jrsoftware.org/isinfo.php) de Jordan Russell y Martijn Laan

---

**¡Dale una estrella ⭐ a este repositorio si te resulta útil!**
