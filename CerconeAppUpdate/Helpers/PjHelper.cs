using CerconeClient.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CerconeClient.Helpers
{
    public static class PjHelper
    {
        public static PjsInfo? GetPjInfo(List<string> rows)
        {
            var lengthRows=rows.Count; 

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
            pj.HabilidadesCombatientes.LinajeCercone = CountX(25, 27, rows);
            pj.HabilidadesCombatientes.ArteDeGuerra = CountX(28, 34, rows);
            pj.HabilidadesCombatientes.LeccionesClase = CountX(35, 43, rows);
            //prof skills
            pj.ProfLevel = CountX(22, 24, rows);
            //No combate skills
            // pj.HabilidadesNOCombatientes.Exploracion= CountX(44, 45, rows);
            // pj.HabilidadesNOCombatientes.Investigacion= CountX(46, 47, rows);
            // pj.HabilidadesNOCombatientes.InutilizarM= CountX(48, 49, rows);
            // pj.HabilidadesNOCombatientes.Sigilo= CountX(50, 51, rows);
            // pj.HabilidadesNOCombatientes.Persuacion= CountX(52, 53, rows);
            // pj.HabilidadesNOCombatientes.Intimidacion= CountX(54, 55, rows);
            // pj.HabilidadesNOCombatientes.Voluntad= CountX(56, 67, rows);
            // pj.HabilidadesNOCombatientes.Percepcion= CountX(68, 69, rows);
            // pj.HabilidadesNOCombatientes.Fuerza= CountX(70, 71, rows);
            pj.HabilidadesNOCombatientes.Exploracion= rows[45];
            pj.HabilidadesNOCombatientes.Investigacion= rows[47];
            pj.HabilidadesNOCombatientes.InutilizarM= rows[49];
            pj.HabilidadesNOCombatientes.Sigilo= rows[51];
            pj.HabilidadesNOCombatientes.Persuacion= rows[53];
            pj.HabilidadesNOCombatientes.Intimidacion= rows[55];
            pj.HabilidadesNOCombatientes.Voluntad= rows[57];
            pj.HabilidadesNOCombatientes.Percepcion= rows[59];
            pj.HabilidadesNOCombatientes.Fuerza= rows[61];
            // pj.HabilidadesNOCombatientes.Engano= CountX(58, 60, rows);
            // pj.HabilidadesNOCombatientes.Voluntad= CountX(61, 63, rows);

            //DATA FINAL

            pj.Ataque = "1D20";
            // pj.Defensa = 10;
            // pj.Magicka = 10;
            // pj.HP = ObtenerHP(pj.DataGeneral.Rango);
            // if (pj.DataGeneral.Armadura.Equals("Pesada"))
            // {
            //     pj.Defensa = pj.Defensa + 6;
            // }
            // if (pj.DataGeneral.Armadura.Equals("Ligera"))
            // {
            //     pj.Defensa = pj.Defensa + 3;
            //     pj.Magicka = pj.Magicka + 3;
            // }

            pj=AddProfesionStatus(pj);
            return pj;
        }
        private static int CountX(int start,int end, List<string> rows)
        {
            int count = 0;
            var newStart = Math.Max(Math.Min(start, rows.Count - 1), 0);
            var newEnd = Math.Min(end, rows.Count - 1);
            if (newStart < start) return count;
            for (int i = newStart; i <= newEnd; i++)
            {
                var value= rows[i];
                if (value.Equals("x"))
                {
                    count++;
                }
            }
            return count;
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
        public static PjsInfo AddProfesionStatus(PjsInfo pj)
        {
            // Obtenemos la profesión desde DataGeneral
            string profesion = pj.DataGeneral.Profesion;

            if (profesion.Contains("Herrería"))
            {
                int nivel = pj.ProfLevel;

                // Validamos el nivel y hacemos los ajustes correspondientes
                if (nivel == 1)
                {
                    // pj.Defensa++; // Sumamos uno a la defensa
                }
                else if (nivel == 2)
                {
                    // pj.Defensa++; // Sumamos uno a la defensa
                    // pj.HabilidadesNOCombatientes.Fuerza++; // Sumamos uno a Intimidación
                }
                else
                {
                    // Otro caso si es necesario
                }
            }
            else if (profesion == "Sastrería")
            {
                int nivel = pj.ProfLevel; 

                // Validamos el nivel y hacemos los ajustes correspondientes
                if (nivel == 1)
                {
                    // pj.Defensa++; // Sumamos uno a la defensa
                }
                else if (nivel == 3)
                {
                    // pj.Defensa++; // Sumamos uno a la defensa
                    // pj.HabilidadesNOCombatientes.Persuacion++; // Sumamos uno a Persuasión
                }
                else
                {
                    // Otro caso si es necesario
                }
            }
            else if (profesion == "Ingeniería")
            {
                int nivel = pj.ProfLevel;
                // Validamos el nivel y hacemos los ajustes correspondientes
                if (nivel >= 1)
                {
                    // pj.HabilidadesNOCombatientes.InutilizarM++; // Sumamos uno a la defensa
                }
                else if (nivel == 3)
                {
                }
                else
                {
                    // Otro caso si es necesario
                }
            }
            return pj;
        }



    }
}
