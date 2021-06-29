using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiagriMicroService.Enums;
using SiagriMicroService.Models;
using SiagriMicroService.Services;

namespace SiagriMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(double lat, double lon)
        {
            var weather = await WeatherService.GetWeatherAsync(lat, lon);

            if (weather?.Main == null)
            {
                return BadRequest();
            }

            var temperature = weather.Main.Temp;

            var response = new PlaylistResponse
            {
                City = weather.Name,
                Latitude = weather.Coord.Lat,
                Longitude = weather.Coord.Lon,
                Temperature = weather.Main.Temp,
                Playlist = new Playlist { Songs = new List<Song>() }
            };

            SpotifyPlaylistResponse spotifyPlaylist = null;

            if (temperature < 10)
            {
                response.Playlist.Type = PlaylistEnum.Classic.ToString();

                spotifyPlaylist = await PlaylistService.GetPlaylistAsync(PlaylistEnum.Classic);
            }

            if (temperature >= 10 && temperature < 15)
            {
                response.Playlist.Type = PlaylistEnum.Rock.ToString();

                spotifyPlaylist = await PlaylistService.GetPlaylistAsync(PlaylistEnum.Rock);
            }

            if (temperature >= 15 && temperature <= 30)
            {
                response.Playlist.Type = PlaylistEnum.Pop.ToString();

                spotifyPlaylist = await PlaylistService.GetPlaylistAsync(PlaylistEnum.Pop);
            }

            if (temperature > 30)
            {
                response.Playlist.Type = PlaylistEnum.Party.ToString();

                spotifyPlaylist = await PlaylistService.GetPlaylistAsync(PlaylistEnum.Party);
            }

            if (spotifyPlaylist == null)
            {
                return BadRequest();
            }

            foreach (var item in spotifyPlaylist.Items)
            {
                var song = new Song { Name = item.Track.Name, Singers = new List<Singer>()};
                
                foreach (var trackArtist in item.Track.Artists)
                {
                    var singer = new Singer { Name = trackArtist.Name };

                    song.Singers.Add(singer);
                }

                response.Playlist.Songs.Add(song);
            }

            return Ok(response);
        }
    }
}