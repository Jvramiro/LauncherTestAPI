using LauncherTestAPI.Models;
using LauncherTestAPI.Services;
using System.Collections.Generic;

namespace LauncherTestAPI.Data {
    public class LauncherContext {

        private readonly List<Launcher> _launchers;
        public LauncherContext() {
            _launchers = new List<Launcher>();
            FillContext().GetAwaiter().GetResult();
        }

        public async Task FillContext() {
            await LauncherService.ImportLaunchers(_launchers);
        }

        public IEnumerable<Launcher> GetAllLaunchers() {
            return _launchers;
        }

        public Launcher GetLauncherById(int id) {
            return _launchers.FirstOrDefault(l => l.Id == id);
        }

        public void AddLauncher(Launcher launcher) {
            _launchers.Add(launcher);
        }

        public void UpdateLauncher(Launcher request) {
            var launcher = _launchers.FirstOrDefault(l => l.Id == request.Id);
            if (launcher != null) {
                launcher = request;
            }
        }

        public void DeleteLauncher(int id) {
            var launcher = _launchers.FirstOrDefault(l => l.Id == id);
            if (launcher != null) {
                _launchers.Remove(launcher);
            }
        }
    }
}
