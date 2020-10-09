using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Threading.Tasks;

namespace EnsekCore.Models
{
    public class MeterReadingModel
    {
        public int AccountId { get; set; }
        public string MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }
        public bool Successful { get; set; }

    }
}
