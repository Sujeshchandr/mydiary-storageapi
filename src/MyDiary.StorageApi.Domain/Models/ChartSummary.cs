using System.Collections.Generic;

namespace MyDiary.StorageApi.Domain.Models
{
    public class ChartSummary
    {
        public ChartType ChartType { get; set; }

        public IList<Chart> Charts { get; set; }
    }
}
