using System.Collections.Generic;
using ValkClient.Dtos;

namespace ValkClient.Helpers
{
    public static class GrimoireHelper
    {
        public static GrimoireInfo? GetGrimoireInfo(List<string> rows)
        {
            var grimoire = new GrimoireInfo
            {
                Z           = Col(rows, 0),
                NombreClase = Col(rows, 1),
                NombreRama  = Col(rows, 2),
                Orden       = Col(rows, 3),
                Descripcion = Col(rows, 4),
                Valores     = Col(rows, 5)
            };

            return grimoire;
        }

        private static string Col(List<string> rows, int i) => i < rows.Count ? rows[i] ?? "" : "";

    }
}
