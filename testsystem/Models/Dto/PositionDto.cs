using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace testsystem.Models.Dto
{
    public class PositionDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public long OpenDate { get; set; }

        public long CloseDate { get; set; }

        [JsonProperty]
        public string Status { get; set; }

        [JsonProperty]
        public string Number { get; set; }

        [JsonProperty]
        public string About { get; set; }

        [JsonProperty]
        public string CompanyInfo { get; set; }

        [JsonProperty]
        public string Instruction { get; set; }

        [JsonProperty]
        public List<TestDto> Tests { get; set; }

        [JsonProperty]
        public List<CandidatDto> Candidats { get; set; }

        [JsonProperty]
        public List<ViewerDto> Viewers { get; set; }

    }
}
