using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testsystem.Models.Dto
{
    public class RatingDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Number { get; set; }

        [JsonProperty]
        public int Grade { get; set; }

        [JsonProperty]
        public int ViewerId { get; set; }

        [JsonProperty]
        public int AnswerId { get; set; }
    }
}
