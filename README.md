# Conversor de DataSheet para el Valk Addon

Descarga la información del DataSheet en Google Sheets y la convierte en tablas **Lua** que el addon lee dentro de *The Elder Scrolls Online*

## Requisitos

- [.NET 10 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (solo para ejecutar)
- .NET 10 SDK (solo para compilar)

## Compilación

Para compilar el proyecto, utiliza el siguiente comando:

```bash
dotnet publish -r win-x64 -c Release --self-contained false
```

## Uso
Ejecutar `CerconeAppUpdate.exe` y persionar **Actualizar**. Genera tres archivos junto al ejecutable (o la carpeta seleccionada).

- `CerconePjData.lua` - fichas de personaje
- `CerconeGrimData.lua` - grimorio
- `CerconeTablonMisiones.lua` - tablón de misiones