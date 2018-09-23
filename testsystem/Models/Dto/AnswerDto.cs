using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using testsystem.Models.Entities;

namespace testsystem.Models.Dto
{
    public class AnswerDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public int CandidatId { get; set; }

        [JsonProperty]
        public int TestId { get; set; }

        [JsonProperty]
        public string Test { get; set; }

        [JsonProperty]
        public List<RatingDto> Ratings { get; set; }

        [JsonProperty]
        public Guid Reference { get; set; }

        [JsonProperty]
        public string Content { get; set; }
    }
}
