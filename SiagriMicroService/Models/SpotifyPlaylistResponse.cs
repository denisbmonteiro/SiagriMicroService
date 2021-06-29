using Newtonsoft.Json;

namespace SiagriMicroService.Models
{
    public class SpotifyPlaylistResponse
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public class Item
    {
        [JsonProperty("track")]
        public Track Track { get; set; }
    }

    public class Track
    {
        [JsonProperty("artists")]
        public Artist[] Artists { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}