using System.Collections.Generic;
using CerconeClient.Dtos;

namespace CerconeClient.Helpers
{
    public static class GrimoireHelper
    {
        public static GrimoireInfo? GetGrimoireInfo(List<string> rows)
        {
            var grimoire = new GrimoireInfo();
            grimoire.Z = rows[0];
            grimoire.NombreClase = rows[1];
            grimoire.NombreRama = rows[2];
            grimoire.Orden = rows[3];
            grimoire.Descripcion = rows[4];
            grimoire.Valores = rows[5];

            return grimoire;
        }

    }
}
