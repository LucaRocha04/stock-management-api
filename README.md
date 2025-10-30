# Sistema de Ventas y Stock

Este es un sistema completo de gestión de ventas y stock desarrollado en C# con Windows Forms, Entity Framework Core, MySQL y gráficos integrados.

## Características

### 🏪 Gestión de Productos
- Registro completo de productos con código, nombre, descripción, precio, stock y categoría
- Búsqueda y filtrado de productos en tiempo real
- Validación de datos y gestión de categorías
- Eliminación lógica de productos

### 💰 Sistema de Ventas
- Interfaz intuitiva para crear nuevas ventas
- Selección de productos con validación de stock
- Aplicación de descuentos por producto
- Cálculo automático de impuestos (18% IVA)
- Múltiples formas de pago (Efectivo, Tarjeta, Transferencia)
- Gestión de clientes y documentos

### 📊 Reportes y Gráficos
- Gráficos de ventas mensuales (barras)
- Gráficos de productos más vendidos (torta)
- Estadísticas detalladas de ventas
- Análisis de tendencias y rendimiento

### 📋 Historial y Consultas
- Historial completo de ventas con filtros por fecha y cliente
- Visualización detallada de cada venta
- Capacidad de anular ventas con restauración de stock
- Búsqueda avanzada por múltiples criterios

## Tecnologías Utilizadas

- **Framework**: .NET 8.0 Windows Forms
- **Base de Datos**: MySQL con Entity Framework Core
- **ORM**: Entity Framework Core 8.0
- **Gráficos**: System.Windows.Forms.DataVisualization.Charting
- **Arquitectura**: Patrón Repository con separación de responsabilidades

## Estructura del Proyecto

```
SistemaVentas/
├── Models/           # Entidades de base de datos
│   ├── Producto.cs
│   ├── Venta.cs
│   └── DetalleVenta.cs
├── Data/            # Contexto de Entity Framework
│   └── VentasContext.cs
├── Forms/           # Formularios de la aplicación
│   ├── FormPrincipal.cs
│   ├── FormProductos.cs
│   ├── FormVentas.cs
│   ├── FormHistorialVentas.cs
│   ├── FormGraficos.cs
│   └── FormDetalleVenta.cs
├── Services/        # Lógica de negocio
└── Utils/          # Utilidades y helpers
```

## Requisitos del Sistema

- **Sistema Operativo**: Windows 10/11
- **Framework**: .NET 8.0 Runtime
- **Base de Datos**: MySQL Server 8.0 o superior
- **Memoria RAM**: Mínimo 4GB recomendado
- **Espacio en Disco**: 100MB para la aplicación

## Configuración de Base de Datos

1. **Instalar MySQL Server**
2. **Crear base de datos**:
   ```sql
   CREATE DATABASE sistema_ventas;
   ```
3. **Configurar cadena de conexión** en `VentasContext.cs`:
   ```csharp
   var connectionString = "server=localhost;database=sistema_ventas;user=root;password=tu_password;";
   ```

## Instalación y Ejecución

1. **Clonar el repositorio**:
   ```bash
   git clone [url-del-repositorio]
   cd sistema-ventas
   ```

2. **Restaurar dependencias**:
   ```bash
   dotnet restore
   ```

3. **Compilar el proyecto**:
   ```bash
   dotnet build
   ```

4. **Ejecutar la aplicación**:
   ```bash
   dotnet run
   ```

## Funcionalidades Principales

### Módulo de Productos
- ✅ CRUD completo de productos
- ✅ Validación de campos obligatorios
- ✅ Gestión de stock en tiempo real
- ✅ Categorización de productos
- ✅ Búsqueda y filtros avanzados

### Módulo de Ventas
- ✅ Interfaz de ventas intuitiva
- ✅ Cálculo automático de totales e impuestos
- ✅ Validación de stock disponible
- ✅ Soporte para múltiples productos por venta
- ✅ Gestión de descuentos

### Módulo de Reportes
- ✅ Gráficos de ventas mensuales
- ✅ Análisis de productos más vendidos
- ✅ Estadísticas de rendimiento
- ✅ Exportación de datos

### Módulo de Historial
- ✅ Consulta de ventas por período
- ✅ Filtros por cliente y fecha
- ✅ Detalle completo de cada venta
- ✅ Función de anulación de ventas

## Arquitectura de la Aplicación

### Patrón de Diseño
- **Model-View-Controller (MVC)** adaptado para Windows Forms
- **Repository Pattern** para acceso a datos
- **Dependency Injection** para gestión de dependencias

### Estructura de Datos
```sql
-- Tabla Productos
Productos: Id, Codigo, Nombre, Descripcion, Precio, Stock, Categoria, FechaCreacion, Activo

-- Tabla Ventas
Ventas: Id, Fecha, Cliente, DocumentoCliente, Subtotal, Impuesto, Total, FormaPago, Observaciones, Activa

-- Tabla DetallesVenta
DetallesVenta: Id, VentaId, ProductoId, Cantidad, PrecioUnitario, Descuento, Subtotal
```

## Características Técnicas

### Validaciones
- Validación de entrada en todos los formularios
- Controles de integridad referencial
- Validación de stock antes de ventas
- Formato automático de moneda y números

### Seguridad
- Transacciones de base de datos para integridad
- Validación de datos en cliente y servidor
- Manejo de errores robusto
- Logs de actividad del sistema

### Rendimiento
- Consultas optimizadas con Entity Framework
- Carga lazy de datos relacionados
- Índices en campos de búsqueda frecuente
- Paginación en listas grandes

## Datos de Prueba

El sistema incluye datos semilla para testing:
- 3 productos de ejemplo en diferentes categorías
- Configuración inicial de categorías
- Estructura de base de datos lista para uso

## Próximas Mejoras

- [ ] Módulo de inventario avanzado
- [ ] Reportes en PDF
- [ ] Backup automático de base de datos
- [ ] Sistema de usuarios y permisos
- [ ] Integración con impresoras fiscales
- [ ] API REST para integraciones
- [ ] Versión web complementaria

## Soporte y Contacto

Para soporte técnico o consultas sobre el sistema:
- Crear un issue en el repositorio
- Consultar la documentación técnica
- Revisar los logs de la aplicación

## Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

---

**Desarrollado con ❤️ usando C# y Windows Forms**