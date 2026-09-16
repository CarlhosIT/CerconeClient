namespace CerconeClient.Dtos
{
    public class PjsInfo
    {
        public string? Personaje { get; set; }
        public string? ID { get; set; }
        public DataGeneral DataGeneral { get; set; } = new();
        public string? HP { get; set; }
        public string? Mag { get; set; }
        public string? Def { get; set; }
        public string? Ataque { get; set; }
        public string[] Valkens { get; set; } = [];
        public HabilidadesCombatientes HabilidadesCombatientes { get; set; } = new();
        public HabilidadesNOCombatientes HabilidadesNOCombatientes { get; set; } = new();
        public TitulosNobiliarios TitulosNobiliarios { get; set; } = new();

    }

    public class DataGeneral
    {
        public string? Clase { get; set; }
        public string? Raza { get; set; }
        public string? Nacimiento { get; set; }
        public string? FechaConvercion { get; set; }
        public string? Sire { get; set; }
        public string? Condicion { get; set; }
        public string? NCasaNobiliaria { get; set; }
        public string? EspCasaNobiliaria { get; set; }
        public string? TituloNobiliario { get; set; }
        public string? Rango { get; set; }
        public string? Profesion { get; set; }
        public string? Arma { get; set; }
        public string? Armadura { get; set; }
    }
    public class HabilidadesCombatientes
    {
        public string? EspCasaNobiliaria { get; set; }
        public string[] Linaje { get; set; } = [];
        public string[] ArteDeGuerra { get; set; } = [];
        public string[] LeccionesClase { get; set; } = [];
    }
    public class HabilidadesNOCombatientes
    {
        public string[] Exploracion { get; set; } = [];
        public string[] Investigacion { get; set; } = [];
        public string[] InutilizarM { get; set; } = [];
        public string[] Sigilo { get; set; } = [];
        public string[] Persuacion { get; set; } = [];
        public string[] Intimidacion { get; set; } = [];
        public string[] Voluntad { get; set; } = [];
        public string[] Percepcion { get; set; } = [];
        public string[] Fuerza { get; set; } = [];
    }

    public class TitulosNobiliarios
    {
        public string? Lord { get; set; }
        public string? Baron { get; set; }
        public string? Vizconde { get; set; }
        public string? Conde { get; set; }
        public string? Marques { get; set; }
        public string? Duque { get; set; }
    }
}
