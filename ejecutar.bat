@echo off
echo Compilando y ejecutando Sistema de Ventas...
echo.

cd /d "C:\Users\BANGHOI7\proyecto profe facu"

echo Restaurando dependencias...
dotnet restore SistemaVentas.csproj

echo.
echo Compilando proyecto...
dotnet build SistemaVentas.csproj

echo.
echo Ejecutando aplicacion...
dotnet run --project SistemaVentas.csproj

pause