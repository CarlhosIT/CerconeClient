using CerconeClient.Dtos;
using System.Collections.Generic;

namespace CerconeClient.Helpers
{
    public static class PjHelper
    {
        public static PjsInfo? GetPjInfo(List<string> rows)
        {
            var pj = new PjsInfo();
            pj.DataGeneral = new DataGeneral();
            pj.Meritos = new MeritosInfo();
            pj.HabilidadesCombatientes = new HabilidadesCombatientes();
            pj.HabilidadesNOCombatientes = new HabilidadesNOCombatientes();

            //Info General
            pj.Personaje = rows[0];
            pj.ID = rows[1];
            pj.DataGeneral.Raza = rows[3];
            pj.DataGeneral.Clase = rows[2];
            pj.DataGeneral.Nacimiento = rows[4];
            pj.DataGeneral.FechaConvercion = rows[5];
            pj.DataGeneral.Sire = rows[6];
            pj.DataGeneral.Armadura = rows[7];
            pj.DataGeneral.Rango = rows[8];
            pj.DataGeneral.Orden = rows[9];
            pj.DataGeneral.Arma = rows[10];
            pj.DataGeneral.Profesion = rows[11];
            pj.HP = rows[12];
            pj.Defensa = rows[13];
            pj.Magicka = rows[14];
            pj.Meritos.PorPorCampana = rows[15];
            pj.Meritos.PorTaberna = rows[16];
            pj.Meritos.PorMisiones = rows[17];
            pj.Meritos.Otros = rows[18];
            pj.Meritos.MeritosGastados = rows[19];
            pj.Meritos.TotalMeritos = rows[20];
            pj.Meritos.Misiones = rows[21];

            //habilidades combatientes
            // pj.HabilidadesCombatientes.LinajeCercone = CountX(25, 27, rows);
            // pj.HabilidadesCombatientes.ArteDeGuerra = CountX(28, 34, rows);
            // pj.HabilidadesCombatientes.LeccionesClase = CountX(35, 43, rows);
            pj.HabilidadesCombatientes.LinajeCercone = new string[] { rows[25], rows[26], rows[27] };
            pj.HabilidadesCombatientes.ArteDeGuerra = new string[] { rows[28], rows[29], rows[30], rows[31], rows[32], rows[33], rows[34] };
            pj.HabilidadesCombatientes.LeccionesClase = new string[] { rows[35], rows[36], rows[37], rows[38], rows[39], rows[40], rows[41], rows[42], rows[43] };
            //prof skills
            // pj.ProfLevel = CountX(22, 24, rows);
            pj.ProfLevel = new string[] { rows[22], rows[23], rows[24] };
            //No combate skills
            pj.HabilidadesNOCombatientes.Exploracion= rows[45];
            pj.HabilidadesNOCombatientes.Investigacion= rows[47];
            pj.HabilidadesNOCombatientes.InutilizarM= rows[49];
            pj.HabilidadesNOCombatientes.Sigilo= rows[51];
            pj.HabilidadesNOCombatientes.Persuacion= rows[53];
            pj.HabilidadesNOCombatientes.Intimidacion= rows[55];
            pj.HabilidadesNOCombatientes.Voluntad= rows[57];
            pj.HabilidadesNOCombatientes.Percepcion= rows[59];
            pj.HabilidadesNOCombatientes.Fuerza= rows[61];

            //DATA FINAL
            pj.Ataque = "1D20";
            return pj;
        }
        public static int ObtenerHP(string rango)
        {
            Dictionary<string, int> hpPorRango = new Dictionary<string, int>()
            {
                {"Iniciado", 10},
                {"Vástago", 12},
                {"Vasallo", 14},
                {"Ejecutor", 16},
                {"Veterano", 18},
                {"Adalid", 20},
                {"Primogenito", 20},
                {"Regente", 20},
                {"Sanguinaris", 16},
                {"Recluta", 14}
            };

            if (hpPorRango.ContainsKey(rango))
            {
                return hpPorRango[rango];
            }
            else
            {
                // Manejo de caso no encontrado, puedes devolver un valor predeterminado o lanzar una excepción
                return 10;
            }
        }
    }
}
