using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiagriMicroService.Models
{
    public class PlaylistResponse
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("playlist")]
        public Playlist Playlist { get; set; }
    }

    public class Playlist
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("songs")]
        public List<Song> Songs { get; set; }
    }

    public class Song
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("singers")]
        public List<Singer> Singers { get; set; }
    }

    public class Singer
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}