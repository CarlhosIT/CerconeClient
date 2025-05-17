namespace CerconeClient.Dtos
{
    public class PjsInfo
    {
        public string? Personaje { get; set; }
        public string? ID { get; set; }
        public DataGeneral? DataGeneral { get; set; }
        public string[]? ProfLevel { get; set; }
        public string? HP { get; set; }
        public string? Magicka { get; set; }
        public string? Ataque { get; set; }
        public string? Defensa { get; set; }
        public MeritosInfo? Meritos { get; set; }
        public string? EliteOrden { get; set; }
        public HabilidadesCombatientes? HabilidadesCombatientes { get; set; }
        public HabilidadesNOCombatientes? HabilidadesNOCombatientes { get; set; }
        public Insignias? Insignias { get; set; }

    }
    public class MeritosInfo
    {
        public string? PorPorCampana { get; set; }
        public string? PorTaberna { get; set; }
        public string? PorMisiones { get; set; }
        public string? Otros { get; set; }
        public string? MeritosGastados { get; set; }
        public string? TotalMeritos { get; set; }
    }
    public class DataGeneral
    {
        public string? Clase { get; set; }
        public string? Raza { get; set; }
        public string? Nacimiento { get; set; }
        public string? FechaConvercion { get; set; }
        public string? Sire { get; set; }
        public string? Armadura { get; set; }
        public string? Rango { get; set; }
        public string? Orden { get; set; }
        public string? Arma { get; set; }
        public string? Profesion { get; set; }
    }
    public class HabilidadesCombatientes
    {
        public string[]? LinajeCercone { get; set; }
        public string[]? ArteDeGuerra { get; set; }
        public string[]? LeccionesClase { get; set; }
    }
    public class HabilidadesNOCombatientes
    {
        public string? Exploracion { get; set; }
        public string? Investigacion { get; set; }
        public string? InutilizarM { get; set; }
        public string? Sigilo { get; set; }
        public string? Persuacion { get; set; }
        public string? Intimidacion { get; set; }
        public string? Engano { get; set; }
        public string? Voluntad { get; set; }
        public string? Percepcion { get; set; }
        public string? Fuerza { get; set; }
    }
    public class Insignias
    {
        public string? Inteligencia { get; set; }
        public string? Pericia { get; set; }
        public string? Discrecion { get; set; }
        public string? Precision { get; set; }
        public string? Fervor { get; set; }
        public string? Expiacion { get; set; }
        public string? Liderazgo { get; set; }
        public string? Valentia { get; set; }
    }
}
