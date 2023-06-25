using LauncherTestAPI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Net.Sockets;
using System.Reflection;

namespace LauncherTestAPI.Models {
    public class Launcher {
        public int Id { get; set; }
        public string Url { get; set; }

        [JsonProperty("flight_proven")]
        public bool FlightProven { get; set; }

        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; }

        [JsonProperty("is_placeholder")]
        public bool IsPlaceholder { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }

        [JsonProperty("launcher_config")]
        public LauncherConfig LauncherConfig { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        public int Flights { get; set; }

        [JsonProperty("last_launch_date")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime LastLaunchDate { get; set; }

        [JsonProperty("first_launch_date")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime FirstLaunchDate { get; set; }
    }
}
