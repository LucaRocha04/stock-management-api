# Configuración de MySQL para Sistema de Ventas

## Opción 1: Instalar MySQL Community Server

1. **Descarga MySQL:**
   - Ve a: https://dev.mysql.com/downloads/mysql/
   - Selecciona "MySQL Community Server"
   - Descarga la versión Windows (x64)

2. **Instalación:**
   - Ejecuta el instalador
   - Elige "Custom" o "Server only"
   - Configura la contraseña del usuario root (puede ser vacía o "123456")
   - Puerto: 3306 (predeterminado)

3. **Verificar instalación:**
   ```bash
   mysql -u root -p
   ```

## Opción 2: Usar XAMPP (Recomendado para desarrollo)

1. **Descarga XAMPP:**
   - Ve a: https://www.apachefriends.org/download.html
   - Descarga la versión para Windows

2. **Instalación:**
   - Instala en C:\xampp
   - Ejecuta XAMPP Control Panel
   - Inicia el servicio "MySQL"

3. **Configuración automática:**
   - Usuario: root
   - Contraseña: (vacía)
   - Puerto: 3306

## Configurar la cadena de conexión

### Si NO tienes contraseña (configuración predeterminada):
```csharp
var connectionString = "server=localhost;database=sistema_ventas;user=root;password=;";
```

### Si tienes contraseña (ejemplo: 123456):
```csharp
var connectionString = "server=localhost;database=sistema_ventas;user=root;password=123456;";
```

## Crear la base de datos automáticamente

Una vez que MySQL esté funcionando:

1. **Opción A: Con migraciones (recomendado):**
   ```bash
   dotnet ef database update
   ```

2. **Opción B: Ejecutar la aplicación:**
   ```bash
   dotnet run
   ```
   La aplicación creará la base de datos automáticamente al iniciar.

3. **Opción C: Usar el script SQL:**
   - Ejecuta el archivo `database_setup.sql` en MySQL Workbench o phpMyAdmin

## Verificar que todo funciona

1. **Compilar el proyecto:**
   ```bash
   dotnet build
   ```

2. **Ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

3. **Probar funcionalidades:**
   - Registrar productos
   - Realizar ventas
   - Ver gráficos
   - Consultar historial

## Solución de problemas comunes

### Error: "Access denied for user 'root'@'localhost'"
- Verifica que MySQL esté ejecutándose
- Verifica usuario y contraseña en la cadena de conexión
- Prueba conectar con MySQL Command Line Client

### Error: "Unable to connect to any of the specified MySQL hosts"
- Verifica que MySQL esté ejecutándose (puerto 3306)
- En XAMPP: verifica que el servicio MySQL esté iniciado
- Verifica que no haya firewall bloqueando la conexión

### La base de datos no se crea
- Ejecuta manualmente: `dotnet ef database update`
- O usa el script SQL proporcionado en `database_setup.sql`