using ValkClient.Dtos;
using System.Collections.Generic;

namespace ValkClient.Helpers
{
    public static class PjHelper
    {
    

        public static PjsInfo? GetPjInfo(List<string> rows)
        {

            var pj = new PjsInfo
            {
                DataGeneral = new DataGeneral(),
                HabilidadesCombatientes = new HabilidadesCombatientes(),
                HabilidadesNOCombatientes = new HabilidadesNOCombatientes(),
                TitulosNobiliarios = new TitulosNobiliarios(),

                Personaje   = Col(rows, 0),
                ID          = Col(rows, 1)
            };
            
            //Info General
            pj.DataGeneral.Clase                = Col(rows, 2);
            pj.DataGeneral.Raza                 = Col(rows, 3);
            pj.DataGeneral.Nacimiento           = Col(rows, 4);
            pj.DataGeneral.FechaConvercion      = Col(rows, 5);
            pj.DataGeneral.Sire                 = Col(rows, 6);
            pj.DataGeneral.Condicion            = Col(rows, 7);
            pj.DataGeneral.NCasaNobiliaria      = Col(rows, 8);
            pj.DataGeneral.EspCasaNobiliaria    = Col(rows, 9);
            pj.DataGeneral.TituloNobiliario     = Col(rows, 10);
            pj.DataGeneral.Rango                = Col(rows, 11);
            pj.DataGeneral.Profesion            = Col(rows, 12);
            pj.DataGeneral.Arma                 = Col(rows, 13);
            pj.DataGeneral.Armadura             = Col(rows, 14);
            pj.HP                               = Col(rows, 15);
            pj.Def                              = Col(rows, 16);
            pj.Mag                              = Col(rows, 17);
            pj.Valkens                          = [Col(rows, 18), Col(rows, 19)];

            //habilidades combatientes
            pj.HabilidadesCombatientes.EspCasaNobiliaria = Col(rows, 20);
            pj.HabilidadesCombatientes.Linaje            = [Col(rows, 21), Col(rows, 22), Col(rows, 23)];
            pj.HabilidadesCombatientes.ArteDeGuerra      = [Col(rows, 24), Col(rows, 25), Col(rows, 26), Col(rows, 27), Col(rows, 28), Col(rows, 29), Col(rows, 30)];
            pj.HabilidadesCombatientes.LeccionesClase    = [Col(rows, 31), Col(rows, 32), Col(rows, 33), Col(rows, 34), Col(rows, 35), Col(rows, 36), Col(rows, 37), Col(rows, 38), Col(rows, 39)];
            //No combate skills
            pj.HabilidadesNOCombatientes.Exploracion    = [Col(rows, 40), Col(rows, 41)];
            pj.HabilidadesNOCombatientes.Investigacion  = [Col(rows, 42), Col(rows, 43)];
            pj.HabilidadesNOCombatientes.InutilizarM    = [Col(rows, 44), Col(rows, 45)];
            pj.HabilidadesNOCombatientes.Sigilo         = [Col(rows, 46), Col(rows, 47)];
            pj.HabilidadesNOCombatientes.Persuacion     = [Col(rows, 48), Col(rows, 49)];
            pj.HabilidadesNOCombatientes.Intimidacion   = [Col(rows, 50), Col(rows, 51)];
            pj.HabilidadesNOCombatientes.Voluntad       = [Col(rows, 52), Col(rows, 53)];
            pj.HabilidadesNOCombatientes.Percepcion     = [Col(rows, 54), Col(rows, 55)];
            pj.HabilidadesNOCombatientes.Fuerza         = [Col(rows, 56), Col(rows, 57)];
            //Titulos Nobiliarios
            pj.TitulosNobiliarios.Lord      = Col(rows, 58);
            pj.TitulosNobiliarios.Baron     = Col(rows, 59);
            pj.TitulosNobiliarios.Vizconde  = Col(rows, 60);
            pj.TitulosNobiliarios.Conde     = Col(rows, 61);
            pj.TitulosNobiliarios.Marques   = Col(rows, 62);
            pj.TitulosNobiliarios.Duque     = Col(rows, 63);
            //DATA FINAL
            pj.Ataque = "1D20";
            return pj;
        }

        //Guardia por si las celdas estan completamente vacias, devuelve ""
        private static string Col(List<string> rows, int i) => i < rows.Count ? rows[i] ?? "" : "";

    }
}
