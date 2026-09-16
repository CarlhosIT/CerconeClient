using System.Collections.Generic;
using ValkClient.Dtos;

namespace ValkClient.Helpers
{
    public static class MissionHelper
    {
        public static MissionInfo? GetMissionInfo(List<string> rows)
        {
            var mission = new MissionInfo
            {
                Pagina          = rows[0],
                Slot            = rows[1],
                PergaminoImg    = rows.Count > 2 ? rows[2] ?? "" : "",
                Titulo          = rows.Count > 3 ? rows[3] ?? "" : "",
                Texto           = rows.Count > 4 ? rows[4] ?? "" : "",
                Requisitos      = rows.Count > 5 ? rows[5] ?? "" : ""
            };

            return mission;
        }
    }
}
