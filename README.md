# Conversor de DataSheet para el Clan Cercone Addon

Este programa descarga la información del DataSheet alojado en Google Drive y la convierte en un objeto en formato **Lua**, que puede ser leído por el **Clan Cercone Addon** para *The Elder Scrolls Online*.

## 🛠️ Compilación

Para compilar el proyecto, utiliza el siguiente comando:

```bash
dotnet publish -r win-x64 -c Release --self-contained false
