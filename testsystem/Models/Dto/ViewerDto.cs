﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace testsystem.Models.Dto
{
    public class ViewerDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Email { get; set; }

        [JsonProperty]
        public long InvitationDate { get; set; }

        [JsonProperty]
        public Position Positon { get; set; }
    }
}
