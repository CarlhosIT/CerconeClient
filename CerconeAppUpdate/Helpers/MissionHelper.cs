using System.Collections.Generic;
using CerconeClient.Dtos;

namespace CerconeClient.Helpers
{
    public static class MissionHelper
    {
        public static MissionInfo? GetMissionInfo(List<string> rows)
        {
            var mission = new MissionInfo();
            mission.Pagina = rows[0];
            mission.Slot = rows[1];
            mission.Estilo = rows.Count > 2 ? rows[2] ?? "" : "";
            mission.Titulo = rows.Count > 3 ? rows[3] ?? "" : "";
            mission.Texto = rows.Count > 4 ? rows[4] ?? "" : "";
            mission.Requisitos = rows.Count > 5 ? rows[5] ?? "" : "";

            return mission;
        }
    }
}
