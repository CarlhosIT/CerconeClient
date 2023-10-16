using System.Collections.Generic;

namespace CerconeClient.Dtos
{
    public class GoogleSheetData
    {
        public string range { get; set; }
        public string majorDimension { get; set; }
        public List<List<string>> values { get; set; }
    }
    
}
