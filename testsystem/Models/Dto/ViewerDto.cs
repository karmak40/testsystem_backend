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
        public string Number { get; set; }

        [JsonProperty]
        public int PositionId { get; set; }

        [JsonProperty]
        public long InvitationDate { get; set; }


    }
}
