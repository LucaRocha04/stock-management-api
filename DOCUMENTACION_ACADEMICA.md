# DOCUMENTACIÓN ACADÉMICA - SISTEMA DE VENTAS Y STOCK

## DATOS DEL PROYECTO

- **Asignatura**: Programación Avanzada / Desarrollo de Software
- **Tema**: Sistema de Gestión de Ventas y Control de Stock
- **Tecnologías**: C# .NET 8.0, Windows Forms, Entity Framework Core, SQLite
- **Fecha**: Octubre 2024
- **Tipo**: Trabajo Práctico Final

---

## 1. INTRODUCCIÓN Y OBJETIVOS

### 1.1 Descripción del Problema
El proyecto consiste en desarrollar un sistema integral de gestión comercial que permita a pequeñas y medianas empresas llevar un control efectivo de sus productos, ventas y stock, proporcionando herramientas de análisis mediante gráficos estadísticos.

### 1.2 Objetivos Generales
- Desarrollar un sistema completo de gestión comercial usando tecnologías .NET
- Implementar una base de datos relacional con Entity Framework Core
- Crear una interfaz gráfica intuitiva con Windows Forms
- Generar reportes visuales con gráficos estadísticos

### 1.3 Objetivos Específicos
- **Gestión de Productos**: CRUD completo con validaciones y control de stock
- **Sistema de Ventas**: Proceso completo de venta con carrito de compras
- **Reportes Gráficos**: Visualización de datos con gráficos de barras y torta
- **Historial de Transacciones**: Consulta y filtrado de ventas realizadas
- **Persistencia de Datos**: Base de datos relacional con integridad referencial

---

## 2. ANÁLISIS Y DISEÑO

### 2.1 Arquitectura del Sistema
El sistema utiliza una arquitectura en capas basada en el patrón **Model-View-Controller (MVC)** adaptado para Windows Forms:

```
┌─────────────────────────────────────────┐
│            CAPA DE PRESENTACIÓN         │
│         (Windows Forms - Views)         │
├─────────────────────────────────────────┤
│           CAPA DE LÓGICA                │
│        (Controllers/Services)           │
├─────────────────────────────────────────┤
│            CAPA DE DATOS                │
│     (Entity Framework Core - Models)    │
├─────────────────────────────────────────┤
│          BASE DE DATOS                  │
│            (SQLite)                     │
└─────────────────────────────────────────┘
```

### 2.2 Modelo de Datos

#### 2.2.1 Entidades Principales

**Producto**
```csharp
public class Producto
{
    public int Id { get; set; }
    public string Codigo { get; set; }      // PROD001, PROD002...
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Categoria { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Activo { get; set; }
}
```

**Venta**
```csharp
public class Venta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Cliente { get; set; }
    public string DocumentoCliente { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Impuesto { get; set; }    // 18% IVA
    public decimal Total { get; set; }
    public string FormaPago { get; set; }
    public string Observaciones { get; set; }
    public bool Activa { get; set; }
    public List<DetalleVenta> Detalles { get; set; }
}
```

**DetalleVenta**
```csharp
public class DetalleVenta
{
    public int Id { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Subtotal { get; set; }
    public Venta Venta { get; set; }
    public Producto Producto { get; set; }
}
```

#### 2.2.2 Diagrama Entidad-Relación

```
┌─────────────────┐      ┌─────────────────┐      ┌─────────────────┐
│    PRODUCTO     │      │  DETALLEVENTA   │      │     VENTA       │
├─────────────────┤      ├─────────────────┤      ├─────────────────┤
│ Id (PK)         │◄────►│ Id (PK)         │◄────►│ Id (PK)         │
│ Codigo          │      │ VentaId (FK)    │      │ Fecha           │
│ Nombre          │      │ ProductoId (FK) │      │ Cliente         │
│ Descripcion     │      │ Cantidad        │      │ DocumentoCliente│
│ Precio          │      │ PrecioUnitario  │      │ Subtotal        │
│ Stock           │      │ Descuento       │      │ Impuesto        │
│ Categoria       │      │ Subtotal        │      │ Total           │
│ FechaCreacion   │      └─────────────────┘      │ FormaPago       │
│ Activo          │                               │ Observaciones   │
└─────────────────┘                               │ Activa          │
                                                  └─────────────────┘
```

### 2.3 Casos de Uso

#### 2.3.1 Gestión de Productos
- **Actor**: Usuario del sistema
- **Flujo Principal**:
  1. Usuario accede al módulo de productos
  2. Sistema muestra lista de productos existentes
  3. Usuario puede agregar, editar, eliminar o buscar productos
  4. Sistema valida datos y actualiza la base de datos
  5. Sistema genera código automático para nuevos productos

#### 2.3.2 Proceso de Venta
- **Actor**: Vendedor
- **Flujo Principal**:
  1. Vendedor inicia nueva venta
  2. Selecciona productos del catálogo
  3. Sistema valida stock disponible
  4. Agrega productos al carrito de compras
  5. Sistema calcula totales e impuestos
  6. Vendedor confirma venta
  7. Sistema actualiza stock y registra transacción

---

## 3. IMPLEMENTACIÓN TÉCNICA

### 3.1 Tecnologías Utilizadas

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| .NET | 8.0 | Framework de desarrollo |
| Windows Forms | 8.0 | Interfaz gráfica de usuario |
| Entity Framework Core | 8.0 | ORM para acceso a datos |
| SQLite | 3.x | Base de datos local |
| System.Windows.Forms.DataVisualization | - | Gráficos estadísticos |

### 3.2 Estructura del Proyecto

```
SistemaVentas/
├── Models/                    # Entidades de negocio
│   ├── Producto.cs           # Entidad producto
│   └── Venta.cs              # Entidad venta con detalles
├── Data/                     # Capa de acceso a datos
│   └── VentasContext.cs      # Contexto de Entity Framework
├── Forms/                    # Interfaz de usuario
│   ├── FormPrincipal.cs      # Pantalla principal con navegación
│   ├── FormProductos.cs      # Gestión de productos
│   ├── FormVentas.cs         # Sistema de ventas
│   ├── FormHistorialVentas.cs # Consulta de ventas
│   ├── FormGraficos.cs       # Reportes visuales
│   └── FormDetalleVenta.cs   # Detalle de transacciones
├── Services/                 # Lógica de negocio (expandible)
├── Utils/                    # Utilidades del sistema (expandible)
└── Program.cs                # Punto de entrada de la aplicación
```

### 3.3 Características Técnicas Implementadas

#### 3.3.1 Patrón Repository
- Separación clara entre lógica de negocio y acceso a datos
- Entity Framework Core como ORM principal
- Contexto unificado para todas las operaciones

#### 3.3.2 Validaciones
- **Cliente**: Validación de campos obligatorios en formularios
- **Servidor**: Validación de integridad en Entity Framework
- **Negocio**: Validación de stock antes de ventas

#### 3.3.3 Manejo de Transacciones
- Transacciones automáticas de Entity Framework
- Rollback automático en caso de errores
- Consistencia de datos garantizada

---

## 4. FUNCIONALIDADES DESARROLLADAS

### 4.1 Módulo de Productos ✅

**Características Implementadas:**
- CRUD completo (Crear, Leer, Actualizar, Eliminar)
- Generación automática de códigos (PROD001, PROD002...)
- Validación de campos obligatorios
- Búsqueda en tiempo real
- Control de stock
- Categorización de productos
- Eliminación lógica (soft delete)

**Validaciones:**
- Código único por producto
- Precio mayor a cero
- Stock no negativo
- Campos obligatorios completados

### 4.2 Sistema de Ventas ✅

**Características Implementadas:**
- Carrito de compras con múltiples productos
- Validación de stock en tiempo real
- Cálculo automático de impuestos (18% IVA)
- Autocompletado de clientes
- Múltiples formas de pago
- Aplicación de descuentos por producto
- Actualización automática de stock

**Flujo de Venta:**
1. Selección de productos con validación de stock
2. Configuración de cantidades y descuentos
3. Cálculo automático de subtotales, impuestos y total
4. Registro de datos del cliente
5. Confirmación y procesamiento de la venta

### 4.3 Historial de Ventas ✅

**Características Implementadas:**
- Consulta de todas las ventas realizadas
- Filtros por fecha (desde/hasta)
- Filtro por cliente con autocompletado
- Búsqueda en tiempo real
- **Persistencia de filtros** (problema resuelto)
- Visualización detallada de cada venta
- Función de anulación de ventas
- Restauración automática de stock al anular

### 4.4 Reportes Gráficos ✅

**Gráficos Implementados:**
- **Gráfico de Barras**: Ventas mensuales del año actual
- **Gráfico de Torta**: Productos más vendidos (top 10)
- Actualización automática de datos
- Interfaz visual atractiva

### 4.5 Interfaz de Usuario ✅

**Mejoras de UX/UI:**
- Pantalla principal con diseño de tarjetas
- Navegación intuitiva con botones de "Volver al Inicio"
- Formularios responsivos y validados
- Mensajes informativos y de confirmación
- Diseño moderno y profesional

---

## 5. PRUEBAS Y VALIDACIÓN

### 5.1 Tipos de Pruebas Realizadas

#### 5.1.1 Pruebas Funcionales
- ✅ Creación, edición y eliminación de productos
- ✅ Proceso completo de venta
- ✅ Validación de stock
- ✅ Cálculos de impuestos y totales
- ✅ Filtros de historial de ventas
- ✅ Generación de gráficos

#### 5.1.2 Pruebas de Validación
- ✅ Campos obligatorios
- ✅ Formato de datos (precios, fechas)
- ✅ Integridad referencial
- ✅ Validación de stock negativo
- ✅ Prevención de códigos duplicados

#### 5.1.3 Pruebas de Interfaz
- ✅ Navegación entre formularios
- ✅ Persistencia de filtros
- ✅ Autocompletado de clientes
- ✅ Actualización de datos en tiempo real

### 5.2 Casos de Prueba Documentados

| ID | Caso de Prueba | Resultado |
|----|----------------|-----------|
| CP01 | Crear producto con código automático | ✅ Exitoso |
| CP02 | Venta con múltiples productos | ✅ Exitoso |
| CP03 | Validación de stock insuficiente | ✅ Exitoso |
| CP04 | Filtros de historial persistentes | ✅ Exitoso |
| CP05 | Anulación de venta con restauración de stock | ✅ Exitoso |
| CP06 | Generación de gráficos estadísticos | ✅ Exitoso |

---

## 6. MANUAL DE USUARIO

### 6.1 Instalación

**Requisitos del Sistema:**
- Windows 10/11
- .NET 8.0 Runtime
- 100MB de espacio en disco
- 4GB RAM recomendado

**Pasos de Instalación:**
1. Ejecutar `ejecutar.bat` para compilación automática
2. O manualmente: `dotnet restore`, `dotnet build`, `dotnet run`

### 6.2 Uso del Sistema

#### 6.2.1 Pantalla Principal
- **Tarjetas de Navegación**: Acceso directo a cada módulo
- **Reloj en Tiempo Real**: Visualización de fecha y hora
- **Navegación Intuitiva**: Botones para volver al inicio desde cualquier pantalla

#### 6.2.2 Gestión de Productos
1. Clic en "Gestión de Productos"
2. **Nuevo Producto**: Completar formulario (código se genera automáticamente)
3. **Editar**: Seleccionar producto y clic en "Editar"
4. **Eliminar**: Seleccionar producto y confirmar eliminación
5. **Buscar**: Usar la caja de búsqueda para filtrar

#### 6.2.3 Realizar Ventas
1. Clic en "Nueva Venta"
2. **Seleccionar Productos**: Elegir del combo box y especificar cantidad
3. **Agregar al Carrito**: Validación automática de stock
4. **Datos del Cliente**: Completar información (autocompletado disponible)
5. **Procesar Venta**: Confirmar para finalizar

#### 6.2.4 Consultar Historial
1. Clic en "Historial de Ventas"
2. **Filtrar por Fecha**: Seleccionar rango de fechas
3. **Filtrar por Cliente**: Usar dropdown o búsqueda
4. **Ver Detalle**: Doble clic en cualquier venta
5. **Anular Venta**: Seleccionar y confirmar anulación

#### 6.2.5 Ver Reportes
1. Clic en "Reportes y Gráficos"
2. **Ventas Mensuales**: Gráfico de barras automático
3. **Productos Populares**: Gráfico de torta de los más vendidos

---

## 7. ASPECTOS TÉCNICOS AVANZADOS

### 7.1 Optimizaciones Implementadas

#### 7.1.1 Performance
- **Lazy Loading**: Carga bajo demanda de relaciones en Entity Framework
- **Búsqueda con Delay**: Timer de 500ms para evitar consultas excesivas
- **Filtros Persistentes**: Evita recargas innecesarias de datos

#### 7.1.2 Experiencia de Usuario
- **Autocompletado Inteligente**: Sugerencias de clientes basadas en historial
- **Validación en Tiempo Real**: Feedback inmediato al usuario
- **Confirmaciones Intuitivas**: Diálogos claros para acciones críticas

### 7.2 Patrones de Diseño Utilizados

#### 7.2.1 Model-View-Controller (MVC)
- **Models**: Entidades de negocio (`Producto`, `Venta`)
- **Views**: Windows Forms (`FormProductos`, `FormVentas`, etc.)
- **Controllers**: Lógica en code-behind de formularios

#### 7.2.2 Repository Pattern
- Abstracción del acceso a datos
- Entity Framework como implementación
- Preparado para inyección de dependencias

#### 7.2.3 Observer Pattern
- Eventos de Windows Forms
- Actualización automática de interfaces
- Notificaciones de cambios de estado

---

## 8. CONCLUSIONES Y APRENDIZAJES

### 8.1 Objetivos Cumplidos

✅ **Sistema Completo**: Desarrollo exitoso de todas las funcionalidades requeridas  
✅ **Base de Datos**: Implementación correcta con Entity Framework Core  
✅ **Interfaz Gráfica**: Windows Forms con diseño moderno y usable  
✅ **Reportes Visuales**: Gráficos estadísticos funcionales  
✅ **Validaciones**: Sistema robusto de validación de datos  
✅ **Persistencia**: Datos almacenados correctamente con integridad referencial  

### 8.2 Desafíos Superados

1. **Migración de MySQL a SQLite**: Necesaria por compatibilidad
2. **Filtros Persistentes**: Implementación de estado en formularios
3. **Carrito de Compras**: Manejo de múltiples productos por venta
4. **Validación de Stock**: Control en tiempo real durante ventas
5. **Generación Automática de Códigos**: Implementación de secuencia auto-incremental

### 8.3 Tecnologías Dominadas

- **C# Avanzado**: Manejo de events, delegates, LINQ
- **Entity Framework Core**: Migrations, relaciones, consultas
- **Windows Forms**: Controles avanzados, validación, UX
- **Patrones de Diseño**: MVC, Repository, Observer
- **Base de Datos**: Diseño relacional, integridad referencial

### 8.4 Posibles Mejoras Futuras

- [ ] Sistema de usuarios y permisos
- [ ] Reportes en PDF exportables
- [ ] API REST para integraciones
- [ ] Módulo de inventario avanzado
- [ ] Backup automático de datos
- [ ] Impresión de facturas
- [ ] Dashboard ejecutivo con KPIs

---

## 9. ANEXOS

### 9.1 Código Fuente Principal

El proyecto incluye los siguientes archivos principales:
- `Models/Producto.cs` - Entidad de productos
- `Models/Venta.cs` - Entidad de ventas con detalles
- `Data/VentasContext.cs` - Contexto de Entity Framework
- `Forms/FormPrincipal.cs` - Interfaz principal
- `Forms/FormProductos.cs` - Gestión de productos
- `Forms/FormVentas.cs` - Sistema de ventas
- `Forms/FormHistorialVentas.cs` - Consulta de ventas
- `Forms/FormGraficos.cs` - Reportes visuales

### 9.2 Base de Datos

**Script de Creación Automática**: La aplicación crea automáticamente la base de datos SQLite al ejecutarse por primera vez.

**Estructura de Tablas**:
```sql
-- Tabla Productos
CREATE TABLE Productos (
    Id INTEGER PRIMARY KEY,
    Codigo TEXT UNIQUE,
    Nombre TEXT NOT NULL,
    Descripcion TEXT,
    Precio DECIMAL(10,2),
    Stock INTEGER,
    Categoria TEXT,
    FechaCreacion DATETIME,
    Activo BOOLEAN
);

-- Tabla Ventas
CREATE TABLE Ventas (
    Id INTEGER PRIMARY KEY,
    Fecha DATETIME,
    Cliente TEXT,
    DocumentoCliente TEXT,
    Subtotal DECIMAL(10,2),
    Impuesto DECIMAL(10,2),
    Total DECIMAL(10,2),
    FormaPago TEXT,
    Observaciones TEXT,
    Activa BOOLEAN
);

-- Tabla DetallesVenta
CREATE TABLE DetallesVenta (
    Id INTEGER PRIMARY KEY,
    VentaId INTEGER REFERENCES Ventas(Id),
    ProductoId INTEGER REFERENCES Productos(Id),
    Cantidad INTEGER,
    PrecioUnitario DECIMAL(10,2),
    Descuento DECIMAL(10,2),
    Subtotal DECIMAL(10,2)
);
```

### 9.3 Capturas de Pantalla

**Pantalla Principal**: Diseño de tarjetas con navegación intuitiva  
**Gestión de Productos**: CRUD completo con códigos automáticos  
**Sistema de Ventas**: Carrito de compras con validación de stock  
**Historial**: Filtros persistentes y consultas avanzadas  
**Gráficos**: Reportes visuales de ventas y productos  

---

## 10. BIBLIOGRAFÍA Y REFERENCIAS

- Microsoft Documentation: .NET 8.0 Windows Forms
- Entity Framework Core Documentation
- Design Patterns: Elements of Reusable Object-Oriented Software
- Clean Code: A Handbook of Agile Software Craftsmanship
- Microsoft C# Programming Guide

---

**Fecha de Elaboración**: Octubre 2024  
**Estado del Proyecto**: Completado ✅  
**Funcionalidades**: 100% Operativas ✅