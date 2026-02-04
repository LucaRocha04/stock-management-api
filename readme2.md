# 🚀 Sistema de Ventas y Stock - Instalación y Ejecución

## 📋 **GUÍA DE INSTALACIÓN Y EJECUCIÓN**

Este documento proporciona las instrucciones paso a paso para instalar y ejecutar el Sistema de Ventas y Stock en cualquier computadora con Windows.

---

## 🖥️ **REQUISITOS DEL SISTEMA**

### **Requisitos Mínimos:**
- **Sistema Operativo**: Windows 10 o superior
- **Memoria RAM**: 4 GB mínimo (8 GB recomendado)
- **Espacio en Disco**: 500 MB libres
- **Resolución de Pantalla**: 1024x768 mínimo (1920x1080 recomendado)
- **Procesador**: Intel Core i3 o equivalente

### **Software Requerido:**
- **.NET 8.0 Desktop Runtime** (se descarga automáticamente)
- **Windows Forms** (incluido en .NET 8.0)

---

## 📥 **INSTALACIÓN DEL PROGRAMA**

### **Opción 1: Instalación Automática (Recomendada)**

1. **Descargar el programa:**
   - Descarga la carpeta completa `proyecto profe facu`
   - Guárdala en una ubicación fácil de recordar (ej: `C:\Programas\SistemaVentas`)

2. **Ejecutar instalación automática:**
   ```bash
   # Hacer doble clic en el archivo:
   ejecutar.bat
   ```
   
   Este archivo automáticamente:
   - ✅ Verifica si .NET 8.0 está instalado
   - ✅ Descarga e instala .NET 8.0 si es necesario
   - ✅ Compila el programa
   - ✅ Ejecuta la aplicación

### **Opción 2: Instalación Manual**

#### **Paso 1: Instalar .NET 8.0**
1. **Verificar si ya está instalado:**
   - Abrir **Símbolo del sistema** (cmd)
   - Escribir: `dotnet --version`
   - Si aparece un número como `8.0.x`, ya está instalado ✅

2. **Si no está instalado:**
   - Ir a: https://dotnet.microsoft.com/download/dotnet/8.0
   - Descargar **".NET 8.0 Desktop Runtime"** para Windows
   - Ejecutar el instalador descargado
   - Seguir las instrucciones del asistente

#### **Paso 2: Preparar el programa**
1. **Abrir PowerShell como Administrador:**
   - Clic derecho en el botón Inicio → "Windows PowerShell (Admin)"

2. **Navegar a la carpeta del programa:**
   ```powershell
   cd "C:\ruta\donde\guardaste\proyecto profe facu"
   ```

3. **Compilar el programa:**
   ```powershell
   dotnet build "proyecto profe facu.sln"
   ```

---

## ▶️ **EJECUCIÓN DEL PROGRAMA**

### **Método 1: Ejecución Rápida**
```powershell
# En PowerShell, dentro de la carpeta del proyecto:
dotnet run --project "SistemaVentas.csproj"
```

### **Método 2: Archivo Batch (Más Fácil)**
1. Hacer **doble clic** en `ejecutar.bat`
2. El programa se iniciará automáticamente

### **Método 3: Desde Visual Studio (Para Desarrollo)**
1. Abrir `proyecto profe facu.sln` en Visual Studio
2. Presionar **F5** o clic en "▶ Iniciar"

---

## 🎯 **PRIMERA EJECUCIÓN**

### **Al Iniciar por Primera Vez:**
1. **El programa creará automáticamente:**
   - 📁 Base de datos SQLite (`sistemaventas.db`)
   - 📊 Estructura de tablas (Productos, Ventas, DetallesVenta)
   - 🔧 Configuración inicial

2. **Pantalla de Bienvenida:**
   - Verás 4 tarjetas de colores:
     - 📦 **PRODUCTOS** (Verde)
     - 💰 **VENTAS** (Azul)  
     - 📊 **REPORTES** (Morado)
     - 📋 **HISTORIAL** (Rojo)

3. **Datos de Prueba:**
   - El sistema incluye algunos productos de ejemplo
   - Puedes agregar, modificar o eliminar según necesites

---

## 🛠️ **SOLUCIÓN DE PROBLEMAS COMUNES**

### **Error: "dotnet no se reconoce como comando"**
**Solución:**
1. Instalar .NET 8.0 Desktop Runtime
2. Reiniciar la computadora
3. Intentar nuevamente

### **Error: "No se puede encontrar el archivo"**
**Solución:**
1. Verificar que estés en la carpeta correcta
2. Usar comillas en la ruta: `cd "proyecto profe facu"`

### **Error de permisos**
**Solución:**
1. Ejecutar PowerShell como Administrador
2. O mover el programa a una carpeta sin restricciones (ej: `C:\Temp`)

### **El programa no abre**
**Solución:**
1. Verificar que Windows esté actualizado
2. Instalar Visual C++ Redistributable 2022
3. Desactivar temporalmente el antivirus

### **Base de datos corrupta**
**Solución:**
1. Eliminar el archivo `sistemaventas.db`
2. Reiniciar el programa (creará una nueva base de datos)

---

## 📁 **ESTRUCTURA DE ARCHIVOS**

```
proyecto profe facu/
├── 📄 ejecutar.bat                  ← Archivo de ejecución rápida
├── 📄 SistemaVentas.csproj         ← Configuración del proyecto
├── 📄 Program.cs                   ← Punto de entrada del programa
├── 📂 Forms/                       ← Pantallas de la aplicación
├── 📂 Models/                      ← Estructura de datos
├── 📂 Data/                        ← Base de datos
└── 📂 bin/Debug/                   ← Archivos compilados
```

---

## 🔒 **SEGURIDAD Y RESPALDO**

### **Respaldo de Datos:**
- **Archivo importante**: `sistemaventas.db`
- **Ubicación**: Carpeta `Data/` del proyecto
- **Recomendación**: Hacer copia de seguridad diaria

### **Restaurar Datos:**
1. Copiar el archivo `sistemaventas.db` de respaldo
2. Pegarlo en la carpeta `Data/`
3. Reiniciar el programa

---

## 📞 **SOPORTE TÉCNICO**

### **Para Problemas de Instalación:**
1. **Verificar requisitos del sistema**
2. **Revisar la sección de solución de problemas**
3. **Contactar al desarrollador con pantalla de error**

### **Para Problemas de Uso:**
- Consultar la **Guía de Usuario** (GUIA_DEFENSA_PROYECTO.md)
- Revisar la documentación técnica (DOCUMENTACION_ACADEMICA.md)

---

## 🚀 **COMANDOS ÚTILES**

### **Compilar el programa:**
```powershell
dotnet build "proyecto profe facu.sln"
```

### **Ejecutar el programa:**
```powershell
dotnet run --project "SistemaVentas.csproj"
```

### **Compilar para distribución:**
```powershell
dotnet publish -c Release -o ./Publicacion
```

### **Verificar .NET instalado:**
```powershell
dotnet --info
```

---

## 📋 **LISTA DE VERIFICACIÓN PRE-ENTREGA**

### **Antes de Ejecutar:**
- [ ] ✅ Windows 10/11 actualizado
- [ ] ✅ .NET 8.0 Desktop Runtime instalado
- [ ] ✅ Carpeta del proyecto completa
- [ ] ✅ Permisos de administrador disponibles

### **Durante la Ejecución:**
- [ ] ✅ El programa compila sin errores
- [ ] ✅ La ventana principal se abre correctamente
- [ ] ✅ Las 4 secciones funcionan (Productos, Ventas, Reportes, Historial)
- [ ] ✅ Los gráficos se muestran correctamente

### **Funcionalidades a Demostrar:**
- [ ] ✅ Agregar un producto nuevo
- [ ] ✅ Realizar una venta completa
- [ ] ✅ Consultar el historial de ventas
- [ ] ✅ Visualizar gráficos estadísticos
- [ ] ✅ Navegación entre categorías de productos

---

## 🎯 **PARA LA PRESENTACIÓN**

### **Demostración Recomendada:**
1. **Mostrar instalación rápida** (ejecutar.bat)
2. **Navegar por la interfaz principal**
3. **Crear un producto de ejemplo**
4. **Realizar una venta completa**
5. **Mostrar gráficos actualizados**
6. **Revisar historial de ventas**

### **Puntos a Destacar:**
- ✨ **Instalación simple**: Solo doble clic
- ✨ **Interfaz intuitiva**: Cualquier persona puede usarlo
- ✨ **Sin dependencias externas**: No necesita internet ni servidores
- ✨ **Datos seguros**: Base de datos local SQLite
- ✨ **Gráficos automáticos**: Estadísticas actualizadas en tiempo real

---

**🎉 ¡SISTEMA LISTO PARA PRESENTACIÓN!**

**Fecha de Entrega**: 1 de Noviembre de 2025  
**Desarrollado por**: [Tu Nombre]  
**Proyecto**: Sistema de Ventas y Stock  
**Tecnología**: C# .NET 8.0 + Windows Forms + SQLite

---

*Este README garantiza una instalación y ejecución exitosa del Sistema de Ventas y Stock para cualquier evaluador o usuario final.*