using CerconeClient.Dtos;
using CerconeClient.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CerconeClient.Services
{
    public class CerconeData
    {
        public async Task UpdatePsjDataAsync(string path)
        {
            using HttpClient client = new HttpClient();
            string[] sheets =
            [
            "https://sheets.googleapis.com/v4/spreadsheets/1RY3WbHMMKznrKheDQYYrbnCIfk9ukOigpAR84cuUHIk/values/ROSTER?key=AIzaSyDbgaqwB_8Yt5FQdZdYg7_iLv2__1mmRtc",
            "https://sheets.googleapis.com/v4/spreadsheets/1RY3WbHMMKznrKheDQYYrbnCIfk9ukOigpAR84cuUHIk/values/GRIMORIO?key=AIzaSyDbgaqwB_8Yt5FQdZdYg7_iLv2__1mmRtc",
            "https://sheets.googleapis.com/v4/spreadsheets/1RY3WbHMMKznrKheDQYYrbnCIfk9ukOigpAR84cuUHIk/values/Misiones?key=AIzaSyDbgaqwB_8Yt5FQdZdYg7_iLv2__1mmRtc"
            ];

            string[] json = await Task.WhenAll(sheets.Select(url => client.GetStringAsync(url)));

            var dto         = JsonSerializer.Deserialize<GoogleSheetData>(json[0]);
            var grimoireDto = JsonSerializer.Deserialize<GoogleSheetData>(json[1]);
            var missionDto  = JsonSerializer.Deserialize<GoogleSheetData>(json[2]);

            if (dto is null || grimoireDto is null || missionDto is null)
                throw new InvalidOperationException("No se pudo interpretar la respuesta de Google Sheets.");

            CreateFilesDtos(dto, grimoireDto,missionDto, path);
        }
        private void CreateFilesDtos(GoogleSheetData dto, GoogleSheetData grimoireDto, GoogleSheetData missionDto, string path)
        {
            var errores = new List<string>();
            var rosterRows  = dto.values ?? throw new InvalidOperationException("La hoja ROSTER no devolvió datos.");
            var grimRows    = grimoireDto.values ?? throw new InvalidOperationException("La hoja GRIMORIO no devolvió datos.");
            var missionRows = missionDto.values ?? throw new InvalidOperationException("La hoja Misiones no devolvió datos.");

            var pjs = new List<PjsInfo>();
            var grimoire = new List<GrimoireInfo>();
            var missions = new List<MissionInfo>();

            if(rosterRows.Count < 3) throw new InvalidOperationException("La hoja ROSTER llegó vacia.");
            rosterRows.RemoveAt(0);
            rosterRows.RemoveAt(0);

            if(grimRows.Count < 2) throw new InvalidOperationException("La hoja GRIMORIO llegó vacia.");
            grimRows.RemoveAt(0);

            if(missionRows.Count < 2) throw new InvalidOperationException("La hoja Misiones llegó vacia.");
            missionRows.RemoveAt(0);

            foreach (var row in rosterRows)
            {
                if (row.Count == 0 || row[0] == "") continue;
                try
                {
                    var pj = PjHelper.GetPjInfo(row);
                    if (pj != null) pjs.Add(pj);
                } catch(Exception ex)
                {
                    errores.Add($"ROSTER - \"{row[0]}\": {ex.Message}");
                }
            }

            foreach (var row in missionRows)
            {
                if (row.Count == 0 || row[0] == "") continue;
                try
                {
                    var mission = MissionHelper.GetMissionInfo(row);
                    if (mission != null) missions.Add(mission);
                } catch(Exception ex)
                {
                    errores.Add($"Misiones - \"{row[0]}\": {ex.Message}");
                }
            }

            foreach (var row in grimRows)
            {   
                if (row.Count == 0 || row == null || row[0] == "") continue;
                try{
                    var grimoireInfo = GrimoireHelper.GetGrimoireInfo(row);
                    if (grimoireInfo != null) grimoire.Add(grimoireInfo);
                }
                catch(Exception ex)
                {
                    errores.Add($"GRIMORIO - \"{row[0]}\": {ex.Message}");
                }
            }

            ShowErrorsSummary(errores);
            BuildLuaData(pjs, grimoire, missions, path);
        }

        private void BuildLuaData(List<PjsInfo> pjs, List<GrimoireInfo> grimoire, List<MissionInfo> missions,string path)
        {
            var luaPjs = ConvertPjsToLua(pjs);
            var luaGrimorio = ConvertGrimToLua(grimoire);
            var luaMisiones = ConvertMissionToLua(missions);
            var endpoint = Directory.Exists(path) ? path : Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";

            File.WriteAllText(Path.Combine(endpoint, "CerconePjData.lua"), luaPjs);
            File.WriteAllText(Path.Combine(endpoint, "CerconeGrimData.lua"), luaGrimorio);
            File.WriteAllText(Path.Combine(endpoint, "CerconeTablonMisiones.lua"), luaMisiones);
        }
        private string ConvertPjsToLua(List<PjsInfo> pjs)
        {
            StringBuilder luaStringBuilder = new StringBuilder();

            luaStringBuilder.AppendLine("ValkadianPjData = {");
            foreach (var pj in pjs)
            {
                luaStringBuilder.AppendLine($"    {{");
                luaStringBuilder.AppendLine($"        Personaje=\"{LuaStr(pj.Personaje)}\",");
                luaStringBuilder.AppendLine($"        ID=\"{LuaStr(pj.ID)}\",");
                luaStringBuilder.AppendLine("        DataGeneral={");
                luaStringBuilder.AppendLine($"            Clase=\"{LuaStr(pj.DataGeneral.Clase)}\",");
                luaStringBuilder.AppendLine($"            Raza=\"{LuaStr(pj.DataGeneral.Raza)}\",");
                luaStringBuilder.AppendLine($"            Nacimiento=\"{LuaStr(pj.DataGeneral.Nacimiento)}\",");
                luaStringBuilder.AppendLine($"            FechaConvercion=\"{LuaStr(pj.DataGeneral.FechaConvercion)}\",");
                luaStringBuilder.AppendLine($"            Sire=\"{LuaStr(pj.DataGeneral.Sire)}\",");
                luaStringBuilder.AppendLine($"            Condicion=\"{LuaStr(pj.DataGeneral.Condicion)}\",");
                luaStringBuilder.AppendLine($"            NombreCasaNobiliaria=\"{LuaStr(pj.DataGeneral.NCasaNobiliaria)}\",");
                luaStringBuilder.AppendLine($"            EspecializacionCasaNobiliaria=\"{LuaStr(pj.DataGeneral.EspCasaNobiliaria)}\",");
                luaStringBuilder.AppendLine($"            TituloNobiliario=\"{LuaStr(pj.DataGeneral.TituloNobiliario)}\",");
                luaStringBuilder.AppendLine($"            Rango=\"{LuaStr(pj.DataGeneral.Rango)}\",");
                luaStringBuilder.AppendLine($"            Profesion=\"{LuaStr(pj.DataGeneral.Profesion)}\",");
                luaStringBuilder.AppendLine($"            Arma=\"{LuaStr(pj.DataGeneral.Arma)}\",");
                luaStringBuilder.AppendLine($"            Armadura=\"{LuaStr(pj.DataGeneral.Armadura)}\",");
                luaStringBuilder.AppendLine("        },");
                luaStringBuilder.AppendLine($"        HP={LuaNum(pj.HP)},");
                luaStringBuilder.AppendLine($"        Defensa={LuaNum(pj.Def)},");
                luaStringBuilder.AppendLine($"        Magicka={LuaNum(pj.Mag)},");
                luaStringBuilder.AppendLine($"        Ataque=\"{LuaStr(pj.Ataque)}\",");
                luaStringBuilder.AppendLine("        Valkens={");
                luaStringBuilder.AppendLine($"           Gastados={LuaNum(pj.Valkens[0])},");
                luaStringBuilder.AppendLine($"           Total={LuaNum(pj.Valkens[1])},");
                luaStringBuilder.AppendLine("        },");
                luaStringBuilder.AppendLine("        HabilidadesCombatientes={");
                luaStringBuilder.AppendLine("            EspCasaNob={");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.EspCasaNobiliaria)}\",");
                luaStringBuilder.AppendLine("            },");
                luaStringBuilder.AppendLine("            Linaje={");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.Linaje[0])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.Linaje[1])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.Linaje[2])}\",");
                luaStringBuilder.AppendLine("            },");
                luaStringBuilder.AppendLine("            ArteDeGuerra={");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.ArteDeGuerra[0])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.ArteDeGuerra[1])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.ArteDeGuerra[2])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.ArteDeGuerra[3])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.ArteDeGuerra[4])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.ArteDeGuerra[5])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.ArteDeGuerra[6])}\",");
                luaStringBuilder.AppendLine("            },");
                luaStringBuilder.AppendLine("            LeccionesClase={");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[0])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[1])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[2])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[3])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[4])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[5])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[6])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[7])}\",");
                luaStringBuilder.AppendLine($"                              \"{LuaStr(pj.HabilidadesCombatientes.LeccionesClase[8])}\",");
                luaStringBuilder.AppendLine("            },");
                luaStringBuilder.AppendLine("        },");
                luaStringBuilder.AppendLine("        HabilidadesNOCombatientes={");
                luaStringBuilder.AppendLine($"            Exploracion={LuaNum(pj.HabilidadesNOCombatientes.Exploracion[1])},");
                luaStringBuilder.AppendLine($"            Investigacion={LuaNum(pj.HabilidadesNOCombatientes.Investigacion[1])},");
                luaStringBuilder.AppendLine($"            InutilizarM={LuaNum(pj.HabilidadesNOCombatientes.InutilizarM[1])},");
                luaStringBuilder.AppendLine($"            Sigilo={LuaNum(pj.HabilidadesNOCombatientes.Sigilo[1])},");
                luaStringBuilder.AppendLine($"            Persuacion={LuaNum(pj.HabilidadesNOCombatientes.Persuacion[1])},");
                luaStringBuilder.AppendLine($"            Intimidacion={LuaNum(pj.HabilidadesNOCombatientes.Intimidacion[1])},");
                luaStringBuilder.AppendLine($"            Voluntad={LuaNum(pj.HabilidadesNOCombatientes.Voluntad[1])},");
                luaStringBuilder.AppendLine($"            Percepcion={LuaNum(pj.HabilidadesNOCombatientes.Percepcion[1])},");
                luaStringBuilder.AppendLine($"            Fuerza={LuaNum(pj.HabilidadesNOCombatientes.Fuerza[1])},");
                luaStringBuilder.AppendLine("        },");
                luaStringBuilder.AppendLine("        TitulosNobiliarios={");
                luaStringBuilder.AppendLine($"                      \"{LuaStr(pj.TitulosNobiliarios.Lord)}\",");
                luaStringBuilder.AppendLine($"                      \"{LuaStr(pj.TitulosNobiliarios.Baron)}\",");
                luaStringBuilder.AppendLine($"                      \"{LuaStr(pj.TitulosNobiliarios.Vizconde)}\",");
                luaStringBuilder.AppendLine($"                      \"{LuaStr(pj.TitulosNobiliarios.Conde)}\",");
                luaStringBuilder.AppendLine($"                      \"{LuaStr(pj.TitulosNobiliarios.Marques)}\",");
                luaStringBuilder.AppendLine($"                      \"{LuaStr(pj.TitulosNobiliarios.Duque)}\",");
                luaStringBuilder.AppendLine("        }");
                luaStringBuilder.AppendLine("    },");
            }

            luaStringBuilder.AppendLine("}");

            return luaStringBuilder.ToString();
        }

        private static string ConvertGrimToLua(List<GrimoireInfo> grimoire)
        {
            StringBuilder luaStringBuilder = new StringBuilder();

            luaStringBuilder.AppendLine("CerconeGrimoireData = {");
            foreach (var data in grimoire)
            {
                luaStringBuilder.AppendLine($"    {{");
                luaStringBuilder.AppendLine($"        Z=\"{LuaStr(data.Z)}\",");
                luaStringBuilder.AppendLine($"        Nombre=\"{LuaStr(data.NombreClase)}\",");
                luaStringBuilder.AppendLine($"        NombreRama=\"{LuaStr(data.NombreRama)}\",");
                luaStringBuilder.AppendLine($"        Orden=\"{LuaStr(data.Orden)}\",");
                luaStringBuilder.AppendLine($"        Descripcion=\"{LuaStr(data.Descripcion)}\",");
                luaStringBuilder.AppendLine($"        Valores=\"{LuaStr(data.Valores)}\",");
                luaStringBuilder.AppendLine("    },");
            }

            luaStringBuilder.AppendLine("}");

            return luaStringBuilder.ToString();
        }

        private static string ConvertMissionToLua(List<MissionInfo> missions)
        {
            StringBuilder luaStringBuilder = new StringBuilder();

            luaStringBuilder.AppendLine("CerconeTablonMisiones = {");
            foreach (var data in missions)
            {
                luaStringBuilder.AppendLine($"    {{");
                luaStringBuilder.AppendLine($"        Pagina={LuaNum(data.Pagina)},");
                luaStringBuilder.AppendLine($"        Slot={LuaNum(data.Slot)},");
                luaStringBuilder.AppendLine($"        Estilo=\"{data.PergaminoImg?.Replace("\n", " ") ?? string.Empty}\",");
                luaStringBuilder.AppendLine($"        Titulo=\"{data.Titulo?.Replace("\n", " ") ?? string.Empty}\",");
                luaStringBuilder.AppendLine($"        Texto=\"{data.Texto?.Replace("\n", "\\n") ?? string.Empty}\",");
                luaStringBuilder.AppendLine($"        Requisitos=\"{data.Requisitos?.Replace("\n", "\\n") ?? string.Empty}\",");
                luaStringBuilder.AppendLine("    },");
            }

            luaStringBuilder.AppendLine("}");

            return luaStringBuilder.ToString();
        }

        // Escapa un texto para que sea un string valido en Lua
        private static string LuaStr(string? v) =>
            (v ?? "")
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "")
                .Replace("\n", "\\n");

        // Convierete a numero de Lua; si la celda esta vacia o rota, devuelve 0
        private static string LuaNum(string? v) =>
            int.TryParse(v, out var n) ? n.ToString() : "0";

        private static void ShowErrorsSummary(List<string> errores)
        {
            if (errores.Count == 0) return;

            var detalle = string.Join("\n", errores.Take(10));
            if (errores.Count > 10) detalle += $"\n... y {errores.Count - 10} más. ";

            MessageBox.Show($"Se omitieron {errores.Count} fila(s) con problemas:\n\n{detalle}",
                            "Avisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
