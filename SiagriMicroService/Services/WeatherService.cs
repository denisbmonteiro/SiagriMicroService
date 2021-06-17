using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SiagriMicroService.Models;
using SiagriMicroService.Data;

namespace SiagriMicroService.Services
{
    public class WeatherService
    {
        private static string BASE_URL = "https://api.openweathermap.org/data/2.5/weather?";
        private static string PARAM_LATITUDE = "lat=";
        private static string PARAM_LONGITUDE = "lon=";
        private static string PARAM_UNITS = "units=metric";
        private static string PARAM_APPID = "appid=" + Tokens.OpenWeatherApi;

        public static async Task<OpenWeatherMapReponse> GetWeatherAsync(double lat, double lon)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = BASE_URL + PARAM_LATITUDE + lat + "&" + PARAM_LONGITUDE + lon + "&" + PARAM_UNITS + "&" + PARAM_APPID;

                    var response = await httpClient.GetAsync(url);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var temp = JsonConvert.DeserializeObject<OpenWeatherMapReponse>(responseString);

                        return temp;
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