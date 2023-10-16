namespace CerconeClient.Dtos
{
    public class PjsInfo
    {
        public string Personaje { get; set; }
        public string ID { get; set; }
        public DataGeneral DataGeneral { get; set; }
        public int ProfLevel { get; set; }
        public int HP { get; set; }
        public int Magicka { get; set; }
        public string Ataque { get; set; }
        public int Defensa { get; set; }
        public MeritosInfo Meritos { get; set; }
        public HabilidadesCombatientes HabilidadesCombatientes { get; set; }
        public HabilidadesNOCombatientes HabilidadesNOCombatientes { get; set; }

    }
    public class MeritosInfo
    {
        public string PorPorCampana { get; set; }
        public string PorTaberna { get; set; }
        public string PorMisiones { get; set; }
        public string Otros { get; set; }
        public string MeritosGastados { get; set; }
        public string TotalMeritos { get; set; }
        public string Misiones { get; set; }
    }
    public class DataGeneral
    {
        public string Clase { get; set; }
        public string Raza { get; set; }
        public string Nacimiento { get; set; }
        public string FechaConvercion { get; set; }
        public string Sire { get; set; }
        public string Armadura { get; set; }
        public string Rango { get; set; }
        public string Orden { get; set; }
        public string Espeecializacion { get; set; }
        public string Profesion { get; set; }
    }
    public class HabilidadesCombatientes
    {
        public int LinajeCercone { get; set; }
        public int ArteDeGuerra { get; set; }
        public int LeccionesClase { get; set; }
    }
    public class HabilidadesNOCombatientes
    {
        public int Exploracion { get; set; }
        public int Investigacion { get; set; }
        public int InutilizarM { get; set; }
        public int Sigilo { get; set; }
        public int Persuacion { get; set; }
        public int Intimidacion { get; set; }
        public int Engano { get; set; }
    }
}
