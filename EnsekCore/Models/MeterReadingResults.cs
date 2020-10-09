using System.Collections.Generic;

namespace EnsekCore.Models
{
    public class MeterReadingResults
    {
        public List<MeterReadingModel> MeterReadings { get; set; }
        public int Successful { get; set; }
        public int Failed { get; set; }
    }
}