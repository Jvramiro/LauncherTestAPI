using LauncherTestAPI.Data;
using LauncherTestAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LauncherTestAPI.Services {
    public static class LauncherService {

        private static string apiUrl = "https://lldev.thespacedevs.com/2.2.0/launcher/?limit=2000";
        public static async Task ImportLaunchers(List<Launcher> data) {

            var httpClient = new HttpClient();

            // Fazer a chamada à API
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var results = JObject.Parse(content)["results"];
                var launchers = JsonConvert.DeserializeObject<List<Launcher>>(results.ToString());

                data.AddRange(launchers);
            }

        }
    }
}
