using System;
using System.Text.Json.Serialization;

namespace LeagueOFLegendsAPI.Model
{
    public class Campeoes
    {
        [JsonPropertyName("Key")]
        public string Id { get; set; } // "id" no JSON
        public string Name { get; set; } // "name" no JSON
        public string Title { get; set; } // "title" no JSON

        [JsonPropertyName("Blurb")]
        public string Historia { get; set; } // "blurb" no JSON

        public PropriedadesCampeoes Stats { get; set; }
    }
}
