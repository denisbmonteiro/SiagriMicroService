using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SiagriMicroService.Enums;
using SiagriMicroService.Helpers;
using SiagriMicroService.Models;

namespace SiagriMicroService.Services
{
    public class PlaylistService
    {
        private static string URL_AUTH = "https://accounts.spotify.com/api/token";
        private static string CLIENT_ID = "OWZlOTViZmQzMzM5NGZkNzkxYjY1MmZiODAwNGIxMWI6N2VmMWM5MWQ2YjkwNDI2MThjN2ZjYzk5NjZiOTQ2NDE=";

        private static string URL_PLAYLIST = "https://api.spotify.com/v1/playlists/";
        private static string PARAM_DEFAULT = "/tracks?market=BR&fields=items(track(name%2Cartists(name)))%2Ctotal&limit=10&offset=0";
        
        private static string TOKEN = "";

        private static async Task<bool> GetAuthTokenAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", CLIENT_ID);

                    var dictionary = new Dictionary<string, string> { { "grant_type", "client_credentials" } };
                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, URL_AUTH) { Content = new FormUrlEncodedContent(dictionary) };
                    var response = await httpClient.SendAsync(requestMessage);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var responseModel = JsonConvert.DeserializeObject<SpotifyAuthResponse>(responseString);

                        TOKEN = responseModel.AccessToken;

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception)
            {
                return false;

                //TODO: LOG THE EXCEPTIONS
            }
        }

        public static async Task<SpotifyPlaylistResponse> GetPlaylistAsync(PlaylistEnum playlistEnum)
        {
            if (string.IsNullOrEmpty(TOKEN))
            {
                if (!await GetAuthTokenAsync())
                {
                    return null;
                }
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);

                    var response = await httpClient.GetAsync(URL_PLAYLIST + playlistEnum.GetDescription() + PARAM_DEFAULT);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var responseModel = JsonConvert.DeserializeObject<SpotifyPlaylistResponse>(responseString);

                        return responseModel;
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                return null;

                //TODO: LOG THE EXCEPTIONS
            }
        }
    }
}