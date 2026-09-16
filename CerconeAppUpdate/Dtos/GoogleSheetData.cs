using System.Collections.Generic;

namespace ValkClient.Dtos
{
    public class GoogleSheetData
    {
        public string? range { get; set; }
        public string? majorDimension { get; set; }
        public List<List<string>>? values { get; set; }
    }
    
}
