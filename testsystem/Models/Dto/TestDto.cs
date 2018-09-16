using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Entities;

namespace testsystem.Models.Dto
{
    public class TestDto
    {

        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Number { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public long Time { get; set; }

        [JsonProperty]
        public string Answer { get; set; }

        [JsonProperty]
        public int PositionId { get; set; }

        [JsonProperty]
        public List<RatingDto> Rating { get; set; } = new List<RatingDto>();

    }
}
