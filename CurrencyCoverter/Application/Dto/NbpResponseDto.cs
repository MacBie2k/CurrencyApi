using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class NbpResponseDto
    {
        [JsonPropertyName("table")]
        public string Table { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("rates")]
        public List<NbpResponseRatesDto> Rates { get; set; }

    }
    public class NbpResponseRatesDto
    {
        [JsonPropertyName("no")]
        public string No { get; set; }
        [JsonPropertyName("effectiveDate")]
        public string EffectiveDate { get; set; }
        [JsonPropertyName("mid")]
        public double Mid { get; set; }
    }
}
