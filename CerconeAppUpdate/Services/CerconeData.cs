using CerconeClient.Dtos;
using CerconeClient.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace CerconeClient.Services
{
    public  class CerconeData
    {
        public void UpdatePsjData(string path)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://sheets.googleapis.com/v4/spreadsheets/1RY3WbHMMKznrKheDQYYrbnCIfk9ukOigpAR84cuUHIk/values/ROSTER?key=AIzaSyDbgaqwB_8Yt5FQdZdYg7_iLv2__1mmRtc").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            var dto = JsonSerializer.Deserialize<GoogleSheetData>(data,new JsonSerializerOptions() { });
            CreateFilesPsj(dto, path);
        }
        private void CreateFilesPsj(GoogleSheetData dto,string path)
        {
            var pjs = new List<PjsInfo>();
            dto.values.Remove(dto.values.First());
            dto.values.Remove(dto.values.First());
            foreach (var rows in dto.values)
            {
                if (rows.First() == "") continue;
                var pj=PjHelper.GetPjInfo(rows);
                if(pj!=null)pjs.Add(pj);
            }
            BuildLuaData(pjs, path);
        }
        private void BuildLuaData(List<PjsInfo> pjs,string path) 
        {
            var strindToSave=ConvertToLua(pjs);
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"CerconePjData.lua"), strindToSave);
        }
        private string ConvertToLua(List<PjsInfo> pjs)
        {
            StringBuilder luaStringBuilder = new StringBuilder();

            luaStringBuilder.AppendLine("CerconePjData = {");
            foreach (var pj in pjs)
            {
                luaStringBuilder.AppendLine($"    {{");
                luaStringBuilder.AppendLine($"        Personaje=\"{pj.Personaje}\",");
                luaStringBuilder.AppendLine($"        ID=\"{pj.ID}\",");
                luaStringBuilder.AppendLine("        DataGeneral={");
                luaStringBuilder.AppendLine($"            Raza=\"{pj.DataGeneral.Raza}\",");
                luaStringBuilder.AppendLine($"            Clase=\"{pj.DataGeneral.Clase}\",");
                luaStringBuilder.AppendLine($"            Nacimiento=\"{pj.DataGeneral.Nacimiento}\",");
                luaStringBuilder.AppendLine($"            FechaConvercion=\"{pj.DataGeneral.FechaConvercion}\",");
                luaStringBuilder.AppendLine($"            Sire=\"{pj.DataGeneral.Sire}\",");
                luaStringBuilder.AppendLine($"            Armadura=\"{pj.DataGeneral.Armadura}\",");
                luaStringBuilder.AppendLine($"            Rango=\"{pj.DataGeneral.Rango}\",");
                luaStringBuilder.AppendLine($"            Orden=\"{pj.DataGeneral.Orden}\",");
                luaStringBuilder.AppendLine($"            Especializacion=\"{pj.DataGeneral.Espeecializacion}\",");
                luaStringBuilder.AppendLine($"            Profesion=\"{pj.DataGeneral.Profesion}\"");
                luaStringBuilder.AppendLine("        },");
                luaStringBuilder.AppendLine($"        ProfLevel={pj.ProfLevel},");
                luaStringBuilder.AppendLine($"        HP={pj.HP},");
                luaStringBuilder.AppendLine($"        Magicka={pj.Magicka},");
                luaStringBuilder.AppendLine($"        Ataque=\"{pj.Ataque}\",");
                luaStringBuilder.AppendLine($"        Defensa={pj.Defensa},");
                luaStringBuilder.AppendLine("        Meritos={");
                luaStringBuilder.AppendLine($"            PorPorCampana=\"{pj.Meritos.PorPorCampana}\",");
                luaStringBuilder.AppendLine($"            PorTaberna=\"{pj.Meritos.PorTaberna}\",");
                luaStringBuilder.AppendLine($"            PorMisiones=\"{pj.Meritos.PorMisiones}\",");
                luaStringBuilder.AppendLine($"            Otros=\"{pj.Meritos.Otros}\",");
                luaStringBuilder.AppendLine($"            MeritosGastados=\"{pj.Meritos.MeritosGastados}\",");
                luaStringBuilder.AppendLine($"            TotalMeritos=\"{pj.Meritos.TotalMeritos}\",");
                luaStringBuilder.AppendLine($"            Misiones=\"{pj.Meritos.Misiones}\"");
                luaStringBuilder.AppendLine("        },");
                luaStringBuilder.AppendLine("        HabilidadesCombatientes={");
                luaStringBuilder.AppendLine($"            LinajeCercone={pj.HabilidadesCombatientes.LinajeCercone},");
                luaStringBuilder.AppendLine($"            ArteDeGuerra={pj.HabilidadesCombatientes.ArteDeGuerra},");
                luaStringBuilder.AppendLine($"            LeccionesClase={pj.HabilidadesCombatientes.LeccionesClase}");
                luaStringBuilder.AppendLine("        },");
                luaStringBuilder.AppendLine("        HabilidadesNOCombatientes={");
                luaStringBuilder.AppendLine($"            Exploracion={pj.HabilidadesNOCombatientes.Exploracion},");
                luaStringBuilder.AppendLine($"            Investigacion={pj.HabilidadesNOCombatientes.Investigacion},");
                luaStringBuilder.AppendLine($"            InutilizarM={pj.HabilidadesNOCombatientes.InutilizarM},");
                luaStringBuilder.AppendLine($"            Sigilo={pj.HabilidadesNOCombatientes.Sigilo},");
                luaStringBuilder.AppendLine($"            Persuacion={pj.HabilidadesNOCombatientes.Persuacion},");
                luaStringBuilder.AppendLine($"            Intimidacion={pj.HabilidadesNOCombatientes.Intimidacion},");
                luaStringBuilder.AppendLine($"            Engano={pj.HabilidadesNOCombatientes.Engano}");
                luaStringBuilder.AppendLine("        }");
                luaStringBuilder.AppendLine("    },");
            }

            luaStringBuilder.AppendLine("}");

            return luaStringBuilder.ToString();
        }
    }
}
