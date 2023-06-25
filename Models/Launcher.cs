using System.Net.Sockets;
using System.Reflection;

namespace LauncherTestAPI.Models {
    public class Launcher {
        public int Id { get; set; }
        public string Url { get; set; }
        public int LaunchLibraryId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Net { get; set; }
        public DateTime WindowEnd { get; set; }
        public DateTime WindowStart { get; set; }
        public bool Inhold { get; set; }
        public bool Tbdtime { get; set; }
        public bool Tbddate { get; set; }
        public int Probability { get; set; }
        public string HoldReason { get; set; }
        public string FailReason { get; set; }
        public string Hashtag { get; set; }
        public LaunchServiceProvider LaunchServiceProvider { get; set; }
        public Rocket Rocket { get; set; }
        public Mission Mission { get; set; }
        public Pad Pad { get; set; }
        public bool WebcastLive { get; set; }
        public string Image { get; set; }
        public string Infographic { get; set; }
        public string[] Program { get; set; }
    }
}
